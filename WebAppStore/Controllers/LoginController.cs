using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppStore.Controllers
{
    public class LoginController : Controller
    {
        StoreDbContext db = new StoreDbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Login(string Username, string Password)
        {
                if (ModelState.IsValid)
                {
                var userInfo = db.Users.FirstOrDefault(a => a.Username == Username && a.Password == Password);
                if (userInfo != null)
                {
                    if(userInfo.Role_Id == 1)
                    {
                        Session.Add("userName", userInfo.Username.ToString());
                        Session.Timeout = 60;
                        return RedirectToAction("Index", "Home");
                    }
                    else if(userInfo.Role_Id == 2)
                    {
                        Session.Add("userName", userInfo.Username.ToString());
                        Session.Timeout = 60;
                        return RedirectToAction("Product", "Product");
                    }
                }
                return View("Index");
                }
            return View("Index");
        }


        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Users.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {

                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }
    }
}