using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PeopleTable.Identity;
using PeopleTable.Models;
using PeopleTable.ViewModels;

namespace PeopleTable.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<PeopleUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                PeopleUser user = userManager.Find(model.Login, model.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = model.RememberMe }, ident);
                    return Redirect("/Home/People");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }


        public ActionResult Register()
        {
            return View();
        }


        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<PeopleUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                var user = new PeopleUser()
                { UserName = model.Login, Name = model.Name };
                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    var ident = userManager.CreateIdentity(user,
                          DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(
                        new AuthenticationProperties { IsPersistent = true }, ident);
                    return Redirect("/Home/People");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Authentication");
        }
    }
}