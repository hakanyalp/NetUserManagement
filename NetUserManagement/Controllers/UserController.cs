using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetUserManagement.Controllers
{
    public class UserController : Controller
    {
        UserManager userManager = new UserManager();

        public ActionResult Index()
        {
            var users = userManager.GetAll();
            return View(users);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User u)
        {
            userManager.AddUserBL(u);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            User u = userManager.FindUser(id);
            return View(u);
        }
        [HttpPost]
        public ActionResult EditUser(User u)
        {
            userManager.EditUserBL(u);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteUser(int id)
        {
            userManager.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}