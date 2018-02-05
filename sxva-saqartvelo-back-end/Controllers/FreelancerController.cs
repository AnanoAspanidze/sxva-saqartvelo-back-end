using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using sxva_saqartvelo_back_end.Filters;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class FreelancerController : Controller
    {

        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();

        public ActionResult Index()
        {
            return View();
        }

        //Freelancer Profile Details
        public ActionResult Details()
        {
            return View();
        }

        [LoginFilter]
        public ActionResult FreelancerProfile()
        {
            return View();
        }
    }
}