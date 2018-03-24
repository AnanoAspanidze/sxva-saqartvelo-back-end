using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Filters;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        [LoginFilter]
        public ActionResult CompanyProfile()
        {
            return View();
        }
    }
}