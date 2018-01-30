using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}