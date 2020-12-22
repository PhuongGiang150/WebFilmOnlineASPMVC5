using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie.Controllers
{
    public class ViewFilmController : Controller
    {
        // GET: ViewFilm
        public ActionResult Index()
        {
            return View();
        }
    }
}