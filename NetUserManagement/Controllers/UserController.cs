using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NetUserManagement.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserManager userManager = new UserManager(new EfUserDal());

        public ActionResult Index()
        {
            User sessionUser = userManager.GetUserByUsername(Session["Username"].ToString());
            var users = userManager.GetList();
            ViewBag.Role = sessionUser.Role;
            return View(users);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            User sessionUser = userManager.GetUserByUsername(Session["Username"].ToString());
            ViewBag.UserRole = sessionUser.Role;
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User u)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(u);
            // User dbUser = userManager.GetUserByUsername(u.Username);  // TODO : Dbde aynı isimde kullanıcı var mı kontrolü eklenebilir (Fluent)

            if (results.IsValid)
            {
                userManager.AddUser(u);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin")]    // TODO : enum
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            User u = userManager.FindUser(id);
            return View(u);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditUser(User u)
        {
            UserValidator userValidator = new UserValidator();
            ValidationResult results = userValidator.Validate(u);
            if (results.IsValid)
            {
                userManager.UpdateUser(u);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteUser(int id)
        {
            User _user = userManager.FindUser(id);
            userManager.DeleteUser(_user);
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("UserLogin", "Login");
        }
    }
}