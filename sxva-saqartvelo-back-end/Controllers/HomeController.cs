using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using PagedList.Mvc;
using PagedList;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class HomeController : Controller
    {
        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();


        public ActionResult Index(int ? page)
        {
            //Mvc PagedList
            int pageSize = 8;
            int pageNumber = (page ?? 1);


            var freelancers = _db.Freelancers.OrderBy(x => x.ID).ToPagedList(pageNumber, pageSize);
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