using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movie.Models;

namespace Movie.Areas.Admin.Controllers
{
    public class About_UsController : BaseController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/About_Us
        public ActionResult Index()
        {
            return View(db.About_Us.ToList());
        }

        // GET: Admin/About_Us/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Us about_Us = db.About_Us.Find(id);
            if (about_Us == null)
            {
                return HttpNotFound();
            }
            return View(about_Us);
        }

        // GET: Admin/About_Us/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/About_Us/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Map,Address,Phone,Email,Socical,Status,CreateDate,CreateBy")] About_Us about_Us)
        {
            if (ModelState.IsValid)
            {
                if (about_Us.CreateDate == null)
                {
                    about_Us.CreateDate = DateTime.Now;
                }
                db.About_Us.Add(about_Us);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about_Us);
        }

        // GET: Admin/About_Us/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Us about_Us = db.About_Us.Find(id);
            if (about_Us == null)
            {
                return HttpNotFound();
            }
            return View(about_Us);
        }

        // POST: Admin/About_Us/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Map,Address,Phone,Email,Socical,Status,CreateDate,CreateBy")] About_Us about_Us)
        {
            if (ModelState.IsValid)
            {
                if (about_Us.CreateDate == null)
                {
                    about_Us.CreateDate = DateTime.Now;
                }
                db.Entry(about_Us).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(about_Us);
        }

        // GET: Admin/About_Us/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About_Us about_Us = db.About_Us.Find(id);
            if (about_Us == null)
            {
                return HttpNotFound();
            }
            return View(about_Us);
        }

        // POST: Admin/About_Us/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            About_Us about_Us = db.About_Us.Find(id);
            db.About_Us.Remove(about_Us);
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
