using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;

namespace Movie.Controllers
{
    public class HomeController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Banner = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.UpSlice).Take(5).ToList();
            ViewBag.BannerButtom = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.UpHome).Take(8).ToList();
            ViewBag.Featured = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.Year).Take(12).ToList();
            ViewBag.TopView = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.ViewCount).Take(12).ToList();
            ViewBag.TopRatting = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.Quality).Take(12).ToList();
            ViewBag.NewUpdate = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.UpHome).Take(12).ToList();
            ViewBag.MostPopular = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.UpHome).Take(6).ToList();
            return View();
        }
        public ActionResult Footer()
        {
            var model = db.Footers.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).Take(7).ToList();
            return PartialView(model);
        }
        public ActionResult Banner()
        {
            var model = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.ViewCount).Take(6).ToList();
            return PartialView(model);
        }
        public ActionResult Menu()
        {
            var model = db.Menus.Where(x => x.Status != false).OrderBy(x => x.DisplayOrder).Take(7).ToList();
            return PartialView(model);
        }
        public ActionResult Dotask()
        {
            string email = Request["email"];
            string password = Request["password"];
            var f_password = Common.GetMD5(password);
            var data = db.Accounts.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password) && s.Class == null && s.Status != false).ToList();

            if (data.Count() > 0)
            {
                Session["user"] = data.FirstOrDefault();
                TempData["Ms"] = "Đăng Nhập Thành Công!";

            }
            else
            {
                TempData["Ms"] = "Đăng Nhập Thất Bại!";
            }
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
        // Tạo tk người dùng
        public ActionResult CreateUser()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser([Bind(Include = "Id,Avartar,Name,Email,Password,Phone,Class,Status,CreateDate,CreateBy")] Account account)
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
                    return RedirectToAction("Index","Home");
                }
            }

            return View(account);
        }
    }
}