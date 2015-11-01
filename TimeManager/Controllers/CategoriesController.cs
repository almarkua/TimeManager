using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            return View(CurrentUser.Categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new AddOrEditCategoryViewModel());
        }

        [HttpPost]
        public ActionResult Add(AddOrEditCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MainRepository.AddCategory(CurrentUser,
                    new Category() {Name = viewModel.Name, Description = viewModel.Description});
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var category = CurrentUser.Categories.First(x => x.CategoryId == id);
                return View(new AddOrEditCategoryViewModel() {CategoryId =  category.CategoryId, Name = category.Name, Description = category.Description});
            }
            return View();
        }

        [HttpPost]
        public ActionResult Edit(AddOrEditCategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MainRepository.UpdateCategory(CurrentUser, new Category(){CategoryId = viewModel.CategoryId, Name = viewModel.Name, Description = viewModel.Description});
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                MainRepository.DeleteCategory(CurrentUser, CurrentUser.Categories.First(x => x.CategoryId == id));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public string GetCurrentUserCategoriesAjax()
        {
            return JsonConvert.SerializeObject(CurrentUser.Categories.Select(x => new {x.CategoryId,x.Name}));
        }

        
    }
}