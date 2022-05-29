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
        public JsonResult UserLogin(User u)
        {
            Context c = new Context();
            User _user = c.Users.FirstOrDefault(x => x.Username == u.Username && x.Password == u.Password);

            if (_user != null)
            {
                FormsAuthentication.SetAuthCookie(_user.Username, false);
                Session["Username"] = _user.Username;
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "User");
            }
            else
            {
                _user = c.Users.FirstOrDefault(x => x.Username == u.Username);
                if (_user != null)
                {
                    return Json(new { Success = false, Error = "Şifreniz hatalıdır " }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Success = false, Error = "Kullanıcı bulunamadı " }, JsonRequestBehavior.AllowGet);
                }
                //return RedirectToAction("UserLogin", "Login");
            }
        }
    }
}