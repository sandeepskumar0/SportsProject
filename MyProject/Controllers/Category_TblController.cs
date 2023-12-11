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
    public class Category_TblController : Controller
    {
        private SportsDbEntities db = new SportsDbEntities();

        // GET: Category_Tbl
        public ActionResult Index()
        {
            return View(db.Category_Tbl.ToList());
        }

        // GET: Category_Tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Tbl category_Tbl = db.Category_Tbl.Find(id);
            if (category_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(category_Tbl);
        }

        // GET: Category_Tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cat_id,Cat_Name")] Category_Tbl category_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Category_Tbl.Add(category_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_Tbl);
        }

        // GET: Category_Tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Tbl category_Tbl = db.Category_Tbl.Find(id);
            if (category_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(category_Tbl);
        }

        // POST: Category_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cat_id,Cat_Name")] Category_Tbl category_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_Tbl);
        }

        // GET: Category_Tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Tbl category_Tbl = db.Category_Tbl.Find(id);
            if (category_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(category_Tbl);
        }

        // POST: Category_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_Tbl category_Tbl = db.Category_Tbl.Find(id);
            db.Category_Tbl.Remove(category_Tbl);
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
