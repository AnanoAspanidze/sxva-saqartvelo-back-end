using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class DevelopersController : Controller
    {

        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();

        public ActionResult Index()
        {
            return View();
        }
    }
}