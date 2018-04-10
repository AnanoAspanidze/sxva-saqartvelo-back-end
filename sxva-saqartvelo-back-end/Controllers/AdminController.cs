using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using sxva_saqartvelo_back_end.Helpers;
using sxva_saqartvelo_back_end.Filters;
using System.Net;
using System.Data.Entity;

namespace sxva_saqartvelo_back_end.Controllers
{
    
    public class AdminController : Controller
    {
        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();


        // GET: Admin
        [AdminFilter]
        public ActionResult AdminPanel()
        {
            var projects = _db.Projects.ToList();
            return View(projects);
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
            var freelancers = new SelectList(_db.Freelancers.ToList(), "ID", "Name");
            ViewData["DBFreelancers"] = freelancers;
            
            var companies = new SelectList(_db.Companies.ToList(), "ID", "Name");
            ViewData["DBCompanies"] = companies;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateProject(CreateProjectModel model, string CompanyID, string FreelancerID)
        {
            var freelancers = new SelectList(_db.Freelancers.ToList(), "ID", "Name");
            ViewData["DBFreelancers"] = freelancers;

            var companies = new SelectList(_db.Companies.ToList(), "ID", "Name");
            ViewData["DBCompanies"] = companies;


            if (ModelState.IsValid)
            {
                Project project = new Project();
                project.Name = model.Name;
                project.Description = model.Description;
                project.CompanyID = Convert.ToInt32(CompanyID);
                project.FreelancerID = Convert.ToInt32(FreelancerID);
                project.StartDate = DateTime.Now;
                project.DateAdded = DateTime.Now;
                _db.Projects.Add(project);
                _db.SaveChanges();
            }
            return View();
        }


        [AdminFilter]
        public ActionResult EditProject(int? id)
        {

            var freelancers = new SelectList(_db.Freelancers.ToList(), "ID", "Name");
            ViewData["DBFreelancers"] = freelancers;

            var companies = new SelectList(_db.Companies.ToList(), "ID", "Name");
            ViewData["DBCompanies"] = companies;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var project = _db.Projects.Find(id);

            if(project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditProject(Project project, string CompanyID, string FreelancerID)
        {
            
            if (ModelState.IsValid)
            {
                var projectToUpdate = _db.Projects.FirstOrDefault(x => x.ID == project.ID);
                projectToUpdate.Name = project.Name.Trim();
                projectToUpdate.Description = project.Description;
                projectToUpdate.CompanyID = Convert.ToInt32(CompanyID);
                projectToUpdate.FreelancerID = Convert.ToInt32(FreelancerID);
                _db.SaveChanges();
                return RedirectToAction("AdminPanel");
            }
            return View(project);
        }

        [HttpPost]
        public JsonResult DeleteProject(int id)
        {
            var del = _db.Projects.Find(id);

            Project project = _db.Projects.Find(del.ID);
            _db.Projects.Remove(project);
            _db.SaveChanges();

            //_db.Projects.Remove(_db.Projects.Where(x => x.ID == id).FirstOrDefault());
            //_db.SaveChanges();
            
            return Json("DeleteSucceeded", JsonRequestBehavior.AllowGet);
        }
    }
}