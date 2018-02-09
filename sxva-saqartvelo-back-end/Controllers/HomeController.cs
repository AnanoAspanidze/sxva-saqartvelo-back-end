using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class HomeController : Controller
    {
        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();


        public ActionResult Index()
        {
            var freelancers = _db.Freelancers.ToList();
            return View(freelancers);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}