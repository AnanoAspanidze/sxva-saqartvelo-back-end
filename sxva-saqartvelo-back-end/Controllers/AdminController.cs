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
    
    public class AdminController : Controller
    {
        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();


        // GET: Admin
        [AdminFilter]
        public ActionResult AdminPanel()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            //admin session
            var admin = LoginHelperForAdmin.admin();

            if(admin != null)
            {
                return RedirectToAction("AdminPanel", "Admin");
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
                return RedirectToAction("AdminPanel", "Admin");
            }
        }

        public ActionResult Logout()
        {
            LoginHelperForAdmin.Logout();
            return RedirectToAction("Login", "Admin");
        }

        [AdminFilter]
        public ActionResult CreateProject()
        {
            var freelancers = _db.Freelancers.ToList();
            freelancers.Insert(0, new Freelancer { ID = 0, Name = "აირჩიეთ ფრილანსერი" });
            ViewBag.freelancers = freelancers;
            ViewBag.selectedFreelancer = freelancers.FirstOrDefault(x=> x.ID == 0).ID;


            var companies = _db.Companies.ToList();
            companies.Insert(0, new Company { ID = 0, Name = "აირჩიეთ კომპანია" });
            ViewBag.companies = companies;
            ViewBag.selectedCompany = companies.FirstOrDefault(x => x.ID == 0).ID;

            //var result = new FreelancerCompanyModel
            //{
            //    listFreelancer = _db.Freelancers.ToList(),
            //    listCompany = _db.Companies.ToList()
            //};

            return View();
        }
    }
}