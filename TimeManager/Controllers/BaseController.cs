using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Ninject;
using TimeManager.App_Start;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IRepository MainRepository { get; set; }

        public ApplicationUserManager UserManager { get; set; }
        
        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public BaseController()
        {
            UserManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            UserManager.Create(new User {UserName = "1221", Password = "1221"});
        }
    }
}