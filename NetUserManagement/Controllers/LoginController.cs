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
        UserManager userManager = new UserManager(new EfUserDal());
        public LoginController()
        {
            User u = userManager.GetUserByUsername("admin");
            if (u == null)
            {
                userManager.AddUser(new User()
                {
                    Username = "admin",
                    Password = "123qwe",
                    Name = "Admin",
                    Surname = "System",
                    Mail = "admin@avansas.com",
                    PhoneNumber = "2163657802",
                    Role = Role.Admin
                });
            }
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public JsonResult UserLogin(User u)
        {
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