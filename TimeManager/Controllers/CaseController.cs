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
    public class CaseController : BaseController
    {
        // GET: Case
        public ActionResult Index()
        {
            return View();
        }

        public string AddCaseAjax(NewCase newCaseModel)
        {
            if (ModelState.IsValid)
            {
                var category = CurrentUser.PrivateCategories.FirstOrDefault(cat => cat.Name == newCaseModel.CategoryName);
                if (category == null)
                {
                    category = CurrentUser.PrivateCategories.FirstOrDefault(cat => cat.Name == newCaseModel.CategoryName);
                }
                
            }
            return JsonConvert.SerializeObject(ModelState);
        }
    }
}