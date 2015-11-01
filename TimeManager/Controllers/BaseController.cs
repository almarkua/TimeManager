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
        public User CurrentUser {
            get {  return MainRepository.Users.FirstOrDefault(us => us.UserName == HttpContext.GetOwinContext().Authentication.User.Identity.Name); }
        }

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public BaseController()
        {
            var context = System.Web.HttpContext.Current.GetOwinContext();
            UserManager = context.GetUserManager<ApplicationUserManager>();
            
            ViewBag.IsAuthorized = context.Authentication.User.Identity.IsAuthenticated;
        }
    }
}