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
    public class SubMenusController : BaseController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/SubMenus
        public ActionResult Index()
        {
            return View(db.SubMenus.ToList());
        }

        // GET: Admin/SubMenus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = db.SubMenus.Find(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            return View(subMenu);
        }

        // GET: Admin/SubMenus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SubMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Metatitle,Link,DisplayOrder,MenuID,Status,CreateDate,CreateBy")] SubMenu subMenu)
        {
            if (ModelState.IsValid)
            {

                if (subMenu.CreateDate == null)
                {
                    subMenu.CreateDate = DateTime.Now;
                }
                db.SubMenus.Add(subMenu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subMenu);
        }

        // GET: Admin/SubMenus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = db.SubMenus.Find(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            return View(subMenu);
        }

        // POST: Admin/SubMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Metatitle,Link,DisplayOrder,MenuID,Status,CreateDate,CreateBy")] SubMenu subMenu)
        {
            if (ModelState.IsValid)
            {
                if (subMenu.CreateDate == null)
                {
                    subMenu.CreateDate = DateTime.Now;
                }
                db.Entry(subMenu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subMenu);
        }

        // GET: Admin/SubMenus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubMenu subMenu = db.SubMenus.Find(id);
            if (subMenu == null)
            {
                return HttpNotFound();
            }
            return View(subMenu);
        }

        // POST: Admin/SubMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubMenu subMenu = db.SubMenus.Find(id);
            db.SubMenus.Remove(subMenu);
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
