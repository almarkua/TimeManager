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
            return View(MainRepository.PublicCategories);
        }
    }
}