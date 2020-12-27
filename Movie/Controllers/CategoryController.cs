using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;
namespace Movie.Controllers
{
    public class CategoryController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: Category
        public ActionResult Index(string category)
        {
            ViewBag.Category = db.Films.Where(x => x.Status != false && x.Genre.Contains(category)).OrderByDescending(x => x.CreateDate).Take(24).ToList();
            ViewBag.ReView = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.CreateDate).Take(10).ToList();
            return View();
        }
        public ActionResult PhimMoi()
        {
            ViewBag.New = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.CreateDate).Take(24).ToList();
            return View();
        }

    }
}