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
                Project_Status projectStatus = new Project_Status();
                project.Name = model.Name;
                project.Description = model.Description;
                project.CompanyID = Convert.ToInt32(CompanyID);
                project.FreelancerID = Convert.ToInt32(FreelancerID);
                project.StartDate = DateTime.Now;
                project.DateAdded = DateTime.Now;
                _db.Projects.Add(project);
                _db.SaveChanges();
                projectStatus.StatusID = 2;
                projectStatus.ProjectID = project.ID;
                projectStatus.Date = DateTime.Now;
                _db.Project_Status.Add(projectStatus);
                _db.SaveChanges();
               
            }
            return View();
        }


        [AdminFilter]
        public ActionResult EditProject(int? id, string StatusID)
        {

            var freelancers = new SelectList(_db.Freelancers.ToList(), "ID", "Name");
            ViewData["DBFreelancers"] = freelancers;

            var companies = new SelectList(_db.Companies.ToList(), "ID", "Name");
            ViewData["DBCompanies"] = companies;

            //var status = new SelectList(_db.Project_Status.FirstOrDefault(x => x.ProjectID == id).Status.Name, "ID", "Name");
            ViewBag.currentStatus = _db.Project_Status.FirstOrDefault(x => x.ProjectID == id).Status.Name;
            var status = new SelectList(_db.Status.ToList(), "ID", "Name");
            ViewData["DBStatus"] = status;

            if(id == null)
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
        public ActionResult EditProject(Project project, string CompanyID, string FreelancerID, string StatusID)
        {
            //Project_Status projectStatus = new Project_Status();
            //var projectToUpdate = _db.Projects.FirstOrDefault(x => x.ID == project.ID);
            //var statusToUpdate = _db.Project_Status.FirstOrDefault(x => x.ProjectID == project.ID);
            //projectToUpdate.Name = project.Name.Trim();
            //projectToUpdate.Description = project.Description;
            //projectToUpdate.CompanyID = Convert.ToInt32(CompanyID);
            //projectToUpdate.FreelancerID = Convert.ToInt32(FreelancerID);
            //statusToUpdate.StatusID = Convert.ToInt32(StatusID);
            //_db.SaveChanges();
            //return RedirectToAction("AdminPanel");

            if (ModelState.IsValid)
            {
                //Project_Status projectStatus = new Project_Status();
                var projectToUpdate = _db.Projects.FirstOrDefault(x => x.ID == project.ID); //ვპოულობ პროექტს დასარედაქტირებლად
                var statusToUpdate = _db.Project_Status.FirstOrDefault(x => x.ProjectID == project.ID); //ვპოულობ პროექტის სტატუსის დასარედაქტირებლად
                projectToUpdate.Name = project.Name.Trim();
                projectToUpdate.Description = project.Description;
                projectToUpdate.CompanyID = Convert.ToInt32(CompanyID);
                projectToUpdate.FreelancerID = Convert.ToInt32(FreelancerID);

                if(StatusID == "" || StatusID == null) //თუ პროექტის სტატუსი იქნება ცარიელი და სხვა ველები იქნება შევსებული edit-ის დროს, პროექტის სტატუსი რჩება იგივე.
                {
                    statusToUpdate.StatusID = statusToUpdate.StatusID;
                    _db.SaveChanges();
                    return RedirectToAction("AdminPanel");
                }
                


                if(Convert.ToInt32(StatusID) == 2) //თუ პროექტის სტატუსი არის 2 ანუ სტატუს ცხრილში 2 ნიშნავს მიმდინარეს, მაშინ პროექტის სტატუსი რჩება მიმდინარეთ და პროექტის დასრულების თარიღი ხდება null.
                {
                    statusToUpdate.StatusID = Convert.ToInt32(StatusID);
                    projectToUpdate.EndDate = null;
                    _db.SaveChanges();
                }
                else
                {
                    statusToUpdate.StatusID = Convert.ToInt32(StatusID); //თუ პროექტის სტატუსი არის 3 ანუ სტატუს ცხრილში 3 ნიშნავს დასრულებულს, მაშნ პროქტის სტატუსი ხდება დასრულებული.
                    projectToUpdate.EndDate = DateTime.Now;
                    _db.SaveChanges();
                }
                return RedirectToAction("AdminPanel");
            }
            return View(project);
        }

        [HttpPost]
        public JsonResult DeleteProject(int? id)
        {
            _db.Projects.Remove(_db.Projects.Where(x => x.ID == id).FirstOrDefault());
            _db.Project_Status.Remove(_db.Project_Status.Where(x => x.ProjectID == id).FirstOrDefault());
            _db.SaveChanges();

            return Json("DeleteSucceeded", JsonRequestBehavior.AllowGet);
        }



        [AdminFilter]
        public ActionResult FreelancerEvaluation(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = new FreelancerEvaluationModel
            {
                freelancer = _db.Freelancers.Find(id)
            };

            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult FreelancerEvaluation(FreelancerEvaluationModel model)
        {
            if (ModelState.IsValid)
            {
                var freelancerToEvaluate = _db.Projects.FirstOrDefault(x => x.FreelancerID == model.freelancer.ID);
                freelancerToEvaluate.FreelancerRating = model.FreelancerRating;
                freelancerToEvaluate.FreelancerEvaluation = model.FreelancerEvaluation;
                _db.SaveChanges();
            }
            return View();
        }

        [AdminFilter]
        public ActionResult CompanyEvaluation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = new CompanyEvaluationModel
            {
                company = _db.Companies.Find(id)
            };

            if(result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CompanyEvaluation(CompanyEvaluationModel model)
        {
            if (ModelState.IsValid)
            {
                var companyToEvaluate = _db.Projects.FirstOrDefault(x => x.CompanyID == model.company.ID);
                companyToEvaluate.CompanyRating = model.CompanyRating;
                companyToEvaluate.CompanyEvaluation = model.CompanyEvaluation;
                _db.SaveChanges();
            }
            return View();
        }
    }
}