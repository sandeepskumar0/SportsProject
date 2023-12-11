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
    public class TeamList_TblController : Controller
    {
        private SportsDbEntities db = new SportsDbEntities();

        // GET: TeamList_Tbl
        public ActionResult Index()
        {
            var teamList_Tbl = db.TeamList_Tbl.Include(t => t.Category_Tbl);
            return View(teamList_Tbl.ToList());
        }

        // GET: TeamList_Tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamList_Tbl teamList_Tbl = db.TeamList_Tbl.Find(id);
            if (teamList_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(teamList_Tbl);
        }

        // GET: TeamList_Tbl/Create
        public ActionResult Create()
        {
            ViewBag.Cat_Bid = new SelectList(db.Category_Tbl, "Cat_id", "Cat_Name");
            return View();
        }

        // POST: TeamList_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "team_id,member_name,member_batch,member_dept,other_info,Cat_Bid")] TeamList_Tbl teamList_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.TeamList_Tbl.Add(teamList_Tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cat_Bid = new SelectList(db.Category_Tbl, "Cat_id", "Cat_Name", teamList_Tbl.Cat_Bid);
            return View(teamList_Tbl);
        }

        // GET: TeamList_Tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamList_Tbl teamList_Tbl = db.TeamList_Tbl.Find(id);
            if (teamList_Tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cat_Bid = new SelectList(db.Category_Tbl, "Cat_id", "Cat_Name", teamList_Tbl.Cat_Bid);
            return View(teamList_Tbl);
        }

        // POST: TeamList_Tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "team_id,member_name,member_batch,member_dept,other_info,Cat_Bid")] TeamList_Tbl teamList_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamList_Tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cat_Bid = new SelectList(db.Category_Tbl, "Cat_id", "Cat_Name", teamList_Tbl.Cat_Bid);
            return View(teamList_Tbl);
        }

        // GET: TeamList_Tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamList_Tbl teamList_Tbl = db.TeamList_Tbl.Find(id);
            if (teamList_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(teamList_Tbl);
        }

        // POST: TeamList_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamList_Tbl teamList_Tbl = db.TeamList_Tbl.Find(id);
            db.TeamList_Tbl.Remove(teamList_Tbl);
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
