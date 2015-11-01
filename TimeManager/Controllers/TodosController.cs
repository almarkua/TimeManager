using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    [Authorize]
    public class TodosController : BaseController
    {
        // GET: Todo
        public ActionResult Index()
        {
            TodosModel todos = new TodosModel();

            var todaysTodos = from category in CurrentUser.Categories
                              from todo in category.Todos
                              where todo.StartDate.Date.Equals(DateTime.Today.Date)
                              select todo;
            var futureTodos = from category in CurrentUser.Categories
                              from todo in category.Todos
                              where todo.StartDate.Date > DateTime.Today.Date
                              select todo;
            todos.TodaysTodos.AddRange(todaysTodos);
            todos.FutureTodos.AddRange(futureTodos);
            return View(todos);
        }

        public ActionResult Add()
        {
            var model = new AddOrEditTodoViewModel();
            model.Categories = GetCategories();
            model.Priorities = GetPriorities();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddOrEditTodoViewModel model)
        {
            if (ModelState.IsValid) {
                var category = CurrentUser.Categories.First(cat => cat.CategoryId == Int32.Parse(model.CategoryId));
                var endDate = DateTime.Now.AddDays(1);
                if (model.EndDate.HasValue)
                {
                    endDate = model.EndDate.GetValueOrDefault();
                }
                MainRepository.AddTodo(category,
                    new Todo()
                    {
                        ShortDescription = model.ShortDescription,
                        Description = model.Description,
                        StartDate = model.StartDate,
                        EndDate = endDate,
                        IsDone = model.IsDone,
                        Priority = Int32.Parse(model.Priotiry)
                    });
                return RedirectToAction("Index");
            }
            model.Categories = GetCategories();
            model.Priorities = GetPriorities();
            return View(model);
        }

        public ActionResult Detailed(int? id)
        {
            if (id.HasValue)
            {
                var todo = (from category in CurrentUser.Categories
                    from tmpTodo in category.Todos
                    where tmpTodo.TodoId == id
                    select tmpTodo).FirstOrDefault();
                if (todo != null)
                {
                    return View(todo);
                }
            }
            return View();
        }

        [HttpPost]
        public string AddAjax(AddTodoAjaxViewModel addTodoAjaxViewModelModel)
        {
            if (ModelState.IsValid)
            {
                var category = CurrentUser.Categories.First(cat => cat.Name == addTodoAjaxViewModelModel.CategoryName);
                var endDate = DateTime.Now.AddDays(1);
                if (addTodoAjaxViewModelModel.EndDate.HasValue)
                {
                    endDate = addTodoAjaxViewModelModel.EndDate.GetValueOrDefault();
                }
                MainRepository.AddTodo(category,new Todo() { ShortDescription = addTodoAjaxViewModelModel.ShortDescription, Description = addTodoAjaxViewModelModel.Description, StartDate = addTodoAjaxViewModelModel.StartDate, EndDate = endDate, IsDone = addTodoAjaxViewModelModel.IsDone, Priority = addTodoAjaxViewModelModel.Priority });
                ModelState.AddModelError("IsValid", "true");
                return JsonConvert.SerializeObject(ModelState);
            }
            return JsonConvert.SerializeObject(ModelState);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var todo = (from category in CurrentUser.Categories
                    from tmpTodo in category.Todos
                    where tmpTodo.TodoId == id
                    select tmpTodo).FirstOrDefault();
                AddOrEditTodoViewModel viewModel = new AddOrEditTodoViewModel()
                {
                    TodoId = id.Value,
                    ShortDescription = todo.ShortDescription,
                    Description = todo.Description,
                    StartDate = todo.StartDate,
                    IsDone = todo.IsDone,
                    EndDate = todo.EndDate,
                    CategoryId = todo.Category.CategoryId.ToString(),
                    Priotiry = todo.Priority.ToString(),
                    Categories = GetCategories(),
                    Priorities = GetPriorities()
                };
                return View(viewModel);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(AddOrEditTodoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var todo=CurrentUser.Categories.First(x => x.CategoryId == Int32.Parse(viewModel.CategoryId))
                        .Todos.First(t => t.TodoId == viewModel.TodoId);
                var newTodo = new Todo()
                {
                    TodoId = todo.TodoId,
                    ShortDescription = viewModel.ShortDescription,
                    Description = viewModel.Description,
                    StartDate = viewModel.StartDate,
                    IsDone = viewModel.IsDone,
                    EndDate = viewModel.EndDate.Value,
                    Category = CurrentUser.Categories.First(x => x.CategoryId == Int32.Parse(viewModel.CategoryId)),
                    Priority = Int32.Parse(viewModel.Priotiry)
                };
                
                MainRepository.UpdateTodo(CurrentUser,todo,newTodo);
                return RedirectToAction("Index");
            }
            viewModel.Categories = GetCategories();
            viewModel.Priorities = GetPriorities();
            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var todo = (from category in CurrentUser.Categories
                    from tmpTodo in category.Todos
                    where tmpTodo.TodoId == id
                    select tmpTodo).First();
                MainRepository.RemoveTodo(todo);
            }
            return RedirectToAction("Index");
        }

        private SelectList GetCategories()
        {
            return new SelectList(from category in CurrentUser.Categories
                           select new
                           {
                               CategoryName = category.Name,
                               CategoryId = category.CategoryId.ToString(),

                           }, "CategoryId", "CategoryName");
        }

        private SelectList GetPriorities()
        {
            return new SelectList(from number in Enumerable.Range(1, 5)
                           select new
                           {
                               Text = number.ToString(),
                               Priority = number.ToString()
                           }, "Priority", "Text");
        }
    }
}