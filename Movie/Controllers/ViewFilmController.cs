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
            return View(contact);
        }
    }
}