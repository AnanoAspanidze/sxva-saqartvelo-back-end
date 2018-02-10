using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using sxva_saqartvelo_back_end.Filters;
using PagedList.Mvc;
using PagedList;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class FreelancerController : Controller
    {

        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();

        public ActionResult Index(int? page)
        {
            //Mvc PagedList
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var freelancers = _db.Freelancers.OrderBy(x => x.ID).ToPagedList(pageNumber, pageSize);
            return View(freelancers);
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