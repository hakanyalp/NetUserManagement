using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NetUserManagement.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(User u)
        {
            Context c = new Context();
            User _user = c.Users.FirstOrDefault(x => x.Username == u.Username && x.Password == u.Password);

            if (_user != null)
            {
                FormsAuthentication.SetAuthCookie(_user.Username, false);
                Session["Username"] = _user.Username;
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("UserLogin", "Login");
            }
        }
    }
}