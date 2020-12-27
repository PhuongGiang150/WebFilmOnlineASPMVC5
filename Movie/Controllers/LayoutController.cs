using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Movie.Models;

namespace Movie.Controllers
{
    public class LayoutController : Controller
    {
        MovieDbContext db = new MovieDbContext();
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu()
        {
            ViewBag.SubMenu = db.SubMenus.Where(x => x.Status != false).OrderBy(x => x.DisplayOrder).Take(7).ToList();
            var model = db.Menus.Where(x => x.Status != false).OrderBy(x => x.DisplayOrder).Take(5).ToList();
            return PartialView(model);
        }
        public ActionResult Footer()
        {
            var model = db.Footers.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).Take(7).ToList();
            return PartialView(model);
        }
        public PartialViewResult SubMenu(int idMenu)
        {
            var model = db.SubMenus.Where(x => x.Status == true && x.MenuID == idMenu).OrderBy(x => x.DisplayOrder).Take(7).ToList();
            ViewBag.Count = model.Count();
            return PartialView(model);

        }

    }
}