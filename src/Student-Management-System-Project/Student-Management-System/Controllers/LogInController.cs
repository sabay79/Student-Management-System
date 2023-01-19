using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class LogInController : Controller
    {
        Student_DBEntities db = new Student_DBEntities();

        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        // POST: LogIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User model)
        {
            if(ModelState.IsValid) 
            {
                using(Student_DBEntities db = new Student_DBEntities()) 
                {
                    var user = db.Users.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                    if (user != null)
                    {
                        Session["UserID"] = user.ID.ToString();
                        Session["UserName"] = user.Name.ToString();
                        return RedirectToAction("Index", "Registration");
                    }
                    else
                    {
                        ModelState.AddModelError("","Email or Password Incorrect");
                    }
                }
            }
            return View(model);
        }
        public ActionResult LogOut() 
        {
            Session.Clear();
            return RedirectToAction("Index", "LogIn");
        }
    }
}