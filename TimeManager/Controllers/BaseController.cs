using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IRepository MainRepository { get; set; }
    }
}