using Movie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Movie.Controllers
{
    public class ViewFilmController : Controller
    {
        private MovieDbContext db = new MovieDbContext();
        // GET: ViewFilm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewFilm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film contact = db.Films.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.UpNext = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.CreateDate).Take(8).ToList();
            ViewBag.YouLike = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.UpHome).Take(10).ToList();
            ViewBag.Featured = db.Films.Where(x => x.Status != false).OrderByDescending(x => x.Year).Take(12).ToList();
            return View(contact);
        }
        public ActionResult Comment(int? id)
        {
            var model = db.Feedbacks.Where(x =>x.IDFilm == id).OrderByDescending(x => x.SentDate).Take(3).ToList();
            return PartialView(model);
        }
    }
}