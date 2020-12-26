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
    public class AccountsController : BaseController
    {
        private MovieDbContext db = new MovieDbContext();

        // GET: Admin/Accounts
        //TK Admin
        public ActionResult Index()
        {
            return View(db.Accounts.Where(a=>a.Class !=null).ToList());
        }
        //Tk Người Dùng
        public ActionResult IndexUser()
        {
            return View(db.Accounts.Where(a => a.Class == null).ToList());
        }
        // GET: Admin/Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Avartar,Name,Email,Password,Phone,Class,Status,CreateDate,CreateBy")] Account account)
        {
            if (ModelState.IsValid)
            {
                if (account.CreateDate == null)
                {
                    account.CreateDate = DateTime.Now;
                }
                var MaHMD5 = Common.GetMD5(account.Password);
                account.Password = MaHMD5;
                if (db.Accounts.Any(x => x.Email == account.Email))
                {
                    ModelState.AddModelError("TrungEmail", "Email đã tồn tại");
                }
                else
                {
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Avartar,Name,Email,Password,Phone,Class,Status,CreateDate,CreateBy")] Account account)
        {
            if (ModelState.IsValid)
            {

                if (account.CreateDate == null)
                {
                    account.CreateDate = DateTime.Now;
                }
                var MaHMD5 = Common.GetMD5(account.Password);
                account.Password = MaHMD5;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Admin/Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
