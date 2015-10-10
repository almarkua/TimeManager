using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    public class PublicCategoriesController : BaseController
    {
        // GET: PublicCategories
        public ActionResult Index()
        {
            MainRepository.AddPublicCategory(new PublicCategory() {Name = "Category 1", Description = "Description for category 1"});
            MainRepository.AddPublicCategory(new PublicCategory() { Name = "Category 2", Description = "Description for category 2" });
            MainRepository.AddPublicCategory(new PublicCategory() { Name = "Category 3", Description = "Description for category 3" });
            return View(MainRepository.PublicCategories);
        }
    }
}