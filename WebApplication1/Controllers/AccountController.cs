using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

         [HttpPost]
        public ActionResult Login(User user)
        {
            using (FormDBEntities db = new FormDBEntities())
            {
                var result= db.userids.Where(x => x.Username == user.UserName && x.PasswordHash == user.Password);
                if (result.Count() != 0)
                {
              //      FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    TempData["msg"] = "Incorrect user or password";
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
           // FormsAuthentication.SignOut();
            return View();
        }
    }
}