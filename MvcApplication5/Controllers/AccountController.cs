using MemberShip.Models;
using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication5.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        flowofdocumentEntities db = new flowofdocumentEntities();

        //
        // GET: /Account/
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        if(MyRoleProvider.Role(model.UserName, new string[] {"Admin"}))
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        if (MyRoleProvider.Role(model.UserName, new string[] { "signer","author" }))
                        {
                            return RedirectToAction("Index", "Worker");
                        }
                    }
                }
            }

            // Появление этого сообщения означает наличие ошибки; повторное отображение формы
            ModelState.AddModelError("", "Имя пользователя или пароль указаны неверно.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        [Authorize]
        public ActionResult Details(string username)
        {
            Employee user = db.Employee.Find(username);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
    }
}
