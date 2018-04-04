using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using sxva_saqartvelo_back_end.Helpers;
using sxva_saqartvelo_back_end.Filters;

namespace sxva_saqartvelo_back_end.Controllers
{
    //[AdminFilter]
    public class AdminController : Controller
    {
        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();
        // GET: Admin
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            //admin session
            var admin = LoginHelperForAdmin.admin();

            if(admin != null)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AdminLoginModel login)
        {
            Admin admin = _db.Admins.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            if(admin == null)
            {
                ViewBag.message = "ელ.ფოსტა ან პაროლი არასწორია";
                return View();
            }
            else
            {
                Session["admin"] = admin;
                return RedirectToAction("Index", "Admin");
            }
        }

        public ActionResult Logout()
        {
            LoginHelperForAdmin.Logout();
            return RedirectToAction("Login","Admin");
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}