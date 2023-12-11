using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class User_TblController : Controller
    {
        private SportsDbEntities db = new SportsDbEntities();

      
        public ActionResult Index()
        {
            return View(db.User_Tbl.ToList());
        }

    
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Tbl user_Tbl = db.User_Tbl.Find(id);
            if (user_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_Tbl);
        }

        
        public ActionResult Signup()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "User_Id,User_Name,User_Email,User_Password,User_Dept")] User_Tbl user_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.User_Tbl.Add(user_Tbl);
                db.SaveChanges();
                return RedirectToAction("Login","User_Tbl");
            }

            return View(user_Tbl);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User_Tbl u )
        {
            int abc = db.User_Tbl.Where(x => x.User_Email == u.User_Email && x.User_Password == u.User_Password).Count();

            if (abc == 1)
            {
                Session["IsLoggedIn"] = true;
           
                return RedirectToAction("Userdashboard", "Home");
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
            return RedirectToAction("Index","Home");
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Tbl user_Tbl = db.User_Tbl.Find(id);
            if (user_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(user_Tbl);
        }

        // POST: User_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Tbl user_Tbl = db.User_Tbl.Find(id);
            db.User_Tbl.Remove(user_Tbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
