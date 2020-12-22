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
    }
}