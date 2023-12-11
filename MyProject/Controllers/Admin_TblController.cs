using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class Admin_TblController : Controller
    {
        private SportsDbEntities db = new SportsDbEntities();

        // GET: Admin_Tbl
        public ActionResult Index()
        {
            return View(db.Admin_Tbl.ToList());
        }

    
        public ActionResult Register()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Admin_Id,Admin_Username,Admin_Password")] Admin_Tbl admin_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Admin_Tbl.Add(admin_Tbl);
                db.SaveChanges();
                return RedirectToAction("Login","Admin_Tbl");
            }

            return View(admin_Tbl);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin_Tbl a)
        {
            int abc = db.Admin_Tbl.Where(x => x.Admin_Username == a.Admin_Username && x.Admin_Password == a.Admin_Password).Count();


            if (abc > 0)
            {
                Session["IsLoggedIn"] = true;
                return RedirectToAction("Admin", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password. Please try again.";
                return View();
            }
        
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}
