using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            UserManager userManager = new UserManager(new EfUserDal());
            User _user = userManager.GetUserByLogin(u.Username, u.Password);

            if (_user != null)
            {
                FormsAuthentication.SetAuthCookie(_user.Username, false);
                Session["Username"] = _user.Username;
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index", "User");
            }
            else
            {
                _user = userManager.GetUserByLogin(u.Username, u.Password);
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