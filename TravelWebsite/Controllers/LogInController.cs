using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelWebsite.Models.Classes;

namespace TravelWebsite.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        Context c = new Context();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin a)
        {
            var lgn = c.Admins.FirstOrDefault(x => x.User == a.User && x.Password == a.Password);
            if (lgn != null)
            {
                FormsAuthentication.SetAuthCookie(lgn.User, false);
                Session["User"] = lgn.User.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
           
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","LogIn");
        }
    }
}