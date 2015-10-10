using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var users = MainRepository.Users;

            var model = new TimeManagerModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(NewCase newCase)
        {
            if (ModelState.IsValid)
            {
                var caseItem = new Case()
                {
                    Category = new Category() {Name = newCase.CategoryName},
                    ShortDescription = newCase.ShortDescription,
                    Description = newCase.Description,
                    StartDate = newCase.StartDate,
                    EndDate = newCase.EndDate,
                    Priority = newCase.Priority
                };
                var model = new TimeManagerModel();
                bool haveNewCategory = true;
                foreach (var category in model.Categories)
                {
                    if (category.Name == caseItem.Category.Name)
                    {
                        haveNewCategory = false;
                    }
                }
                if (haveNewCategory) model.Categories.Add(caseItem.Category);
                model.Cases.Add(caseItem);
                model.NewCase = new NewCase();
                return View(model);
            }
            var model1 = new TimeManagerModel();
            model1.NewCase = newCase;
            return View(model1);
        }

        [HttpGet]
        public ActionResult Users()
        {
            MainRepository.AddUser(new User()
            {
                Name = "User",
                AboutMe = "About Me",
                Email = "almark.ua@gmail.com",
                Password = "password",
                UserImage = "mimi.jpg"
            });
            return View(MainRepository.Users);
        }
    }
}