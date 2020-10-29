using System.Web;
using System.Web.Mvc;
using ItAcademy.Project.Music.Client.App_Start.Core;
using ItAcademy.Project.Music.Client.Models;
using ItAcademy.Project.Music.Domain.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ItAcademy.Project.Music.Client.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        [HttpGet]
        public virtual ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Main");
            }

            ViewBag.ReturnUrl = returnUrl;

            return View(new LoginViewModel());
        }

        [HttpGet]
        public virtual ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Main");
            }

            return View(new RegisterViewModel());
        }

        [HttpPost]
        public virtual ActionResult Login(LoginViewModel loginView, string returnUrl)
        {
            // validate
            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            ApplicationUser user = userManager.Find(loginView.Nickname, loginView.Password);
            if (user != null)
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                if (!string.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Main");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "No user found");
                return View(loginView);
            }
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel regView)
        {
            if (!ModelState.IsValid)
            {
                return View(regView);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            var newUser = new ApplicationUser
            {
                Email = regView.Email,
                UserName = regView.Nickname
            };

            userManager.Create(newUser, regView.Password);

            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<ApplicationRole>>();
            const string roleName = "User";

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new ApplicationRole { Name = roleName });
            }

            var newUserDb = userManager.Find(regView.Nickname, regView.Password);
            userManager.AddToRole(newUserDb.Id, roleName);

            return RedirectToAction("Index", "Main");
        }

        public virtual ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Main");
        }
    }
}