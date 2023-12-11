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
    public class RequestJoin_TblController : Controller
    {
        private SportsDbEntities db = new SportsDbEntities();

        // GET: RequestJoin_Tbl
        public ActionResult Index()
        {
            var requestJoin_Tbl = db.RequestJoin_Tbl.Include(r => r.Category_Tbl);
            return View(requestJoin_Tbl.ToList());
        }

        // GET: RequestJoin_Tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestJoin_Tbl requestJoin_Tbl = db.RequestJoin_Tbl.Find(id);
            if (requestJoin_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(requestJoin_Tbl);
        }

        // GET: RequestJoin_Tbl/Create
        public ActionResult Create()
        {
            ViewBag.Cat_Fid = new SelectList(db.Category_Tbl, "Cat_id", "Cat_Name");
            return View();
        }

        // POST: RequestJoin_Tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Req_Id,Req_name,Req_Dept,Req_Age,Cat_Fid")] RequestJoin_Tbl requestJoin_Tbl)
        {
            if (ModelState.IsValid)
            {
                db.RequestJoin_Tbl.Add(requestJoin_Tbl);
                db.SaveChanges();
           
                ViewBag.SuccessMessage = "Request successfully sent!";
                return RedirectToAction("Create");
            }

            ViewBag.Cat_Fid = new SelectList(db.Category_Tbl, "Cat_id", "Cat_Name", requestJoin_Tbl.Cat_Fid);
            return View(requestJoin_Tbl);
        }

        

        // GET: RequestJoin_Tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestJoin_Tbl requestJoin_Tbl = db.RequestJoin_Tbl.Find(id);
            if (requestJoin_Tbl == null)
            {
                return HttpNotFound();
            }
            return View(requestJoin_Tbl);
        }

        // POST: RequestJoin_Tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestJoin_Tbl requestJoin_Tbl = db.RequestJoin_Tbl.Find(id);
            db.RequestJoin_Tbl.Remove(requestJoin_Tbl);
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
