using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;

namespace Movie.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private MovieDbContext db = new MovieDbContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Dotask()
        {
            string email = Request["email"];
            string password = Request["password"];
            var f_password = Common.GetMD5(password);
            var data = db.Accounts.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password) && s.Class != null && s.Status != false).ToList();

            if (data.Count() > 0)
            {
                Session["admin"] = data.FirstOrDefault();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Đăng Nhập Thất Bại!";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}