using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Owin;

using TimeManager.App_Start;
using TimeManager.Models;

namespace TimeManager.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public void Index()
        {
            RedirectToAction("SignIn");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignIn(LoginViewModel loginViewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(loginViewModel.UserName, loginViewModel.Password);
                if (user != null)
                {
                    SignIn(user, true);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError("", "E-mail і/або пароль невірні");
            }
            loginViewModel = new LoginViewModel() {UserName = loginViewModel.UserName};
            ModelState["Password"].Value = null;
            return View(loginViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public string SignInAjax(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    SignIn(user, true);
                    return JsonConvert.SerializeObject(ModelState);
                }
                ModelState.AddModelError("CustomErrors", "E-mail і/або пароль невірні");
            }
            return JsonConvert.SerializeObject(ModelState);
        }

        public ActionResult Authorized()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("SignIn");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.RePassword)
                {
                    var user = new User() { UserName = model.Email, Email = model.Email };
                    IdentityResult result = UserManager.Create(user, model.Password);
                    if (result.Succeeded)
                    {
                        SignIn(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error);
                        }
                }
                ModelState.AddModelError("Password","Паролі не співпадають!");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.FindByName(model.Email);
                if (user != null)
                {
                    //TODO : Restore Password
                    string code = UserManager.GeneratePasswordResetToken(user.Id);
                    var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                    await UserManager.SendEmailAsync(user.Id, "Відновлення пароля", "Ви можете відновити свій пароль за <a href=\"" + callbackUrl + "\">посиланням</a>");
                    return RedirectToAction("ForgotPasswordConfirmation", "Account");
                }
                ModelState.AddModelError("","Користувача із такою електронною адресою не знайдено!");
            }
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            if (code != null)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "No user found.");
                    return View();
                }
                IdentityResult result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("ResetPasswordConfirmation", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }



        private void SignIn(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, user.GenerateUserIdentity(UserManager));
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


    }
}