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
using System.Data.Entity.Validation;
using System.Diagnostics;

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

            var freelancers = _db.Freelancers.ToList();
            List<object> freelancerList = new List<object>();
            foreach (var f in freelancers)
            {
                freelancerList.Add(new
                {
                    ID = f.ID,
                    Name = f.Name + " " + f.Surname
                });
                this.ViewData["DBFreelancers"] = new SelectList(freelancerList, "ID", "Name");
            }

            var companies = new SelectList(_db.Companies.ToList(), "ID", "Name");
            ViewData["DBCompanies"] = companies;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateProject(CreateProjectModel model, string CompanyID, string FreelancerID)
        {
           
            var freelancers = _db.Freelancers.ToList();
            List<object> freelancerList = new List<object>();
            foreach (var f in freelancers)
            {
                freelancerList.Add(new
                {
                    ID = f.ID,
                    Name = f.Name + " " + f.Surname
                });
                this.ViewData["DBFreelancers"] = new SelectList(freelancerList, "ID", "Name");
            }

            var companies = new SelectList(_db.Companies.ToList(), "ID", "Name");
            ViewData["DBCompanies"] = companies;

            if(CompanyID == "")
            {
                ViewBag.validateCompany = "აირჩიეთ კომპანია";
                return View();
            }
            if(FreelancerID == "")
            {
                ViewBag.validateFreelancer = "აირჩიეთ ფრილანსერი";
                return View();
            }


            if (ModelState.IsValid)
            {
                Project project = new Project();
                Project_Status projectStatus = new Project_Status();
                project.Name = model.Name;
                project.Description = model.Description;
                project.CompanyID = Convert.ToInt32(CompanyID);
                project.FreelancerID = Convert.ToInt32(FreelancerID);
                project.FreelancerRating = 0;
                project.CompanyRating = 0;
                project.FreelancerEvaluation = "";
                project.CompanyEvaluation = "";
                project.StartDate = model.StartDate;
                project.EndDate = model.EndDate;
                project.DateAdded = DateTime.Now;
                _db.Projects.Add(project);
                _db.SaveChanges();
                projectStatus.StatusID = 2;
                projectStatus.ProjectID = project.ID;
                projectStatus.Date = DateTime.Now;
                _db.Project_Status.Add(projectStatus);
                _db.SaveChanges();
                ViewBag.Success = "პროექტი დაემატა წარმატებით";
               
            }
            return View();
        }


        [AdminFilter]
        public ActionResult EditProject(int? id, string StatusID)
        {

            var freelancers = _db.Freelancers.ToList();
            List<object> freelancerList = new List<object>();
            foreach(var f in freelancers)
            {
                freelancerList.Add(new {
                    ID = f.ID,
                    Name = f.Name + " " + f.Surname
                });
                this.ViewData["DBFreelancers"] = new SelectList(freelancerList, "ID", "Name");
            }



            var companies = new SelectList(_db.Companies.ToList(), "ID", "Name");
            ViewData["DBCompanies"] = companies;



            ViewBag.currentStatus = _db.Project_Status.FirstOrDefault(x => x.ProjectID == id).Status.Name;
            var status = new SelectList(_db.Status.ToList(), "ID", "Name");
            ViewData["DBStatus"] = status;

            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var project = _db.Projects.Find(id);
            var result = new EditProjectModel
            {
                ID = project.ID,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                CompanyID = project.CompanyID,
                FreelancerID = project.FreelancerID.Value,
                StatusID = project.Project_Status.FirstOrDefault(x => x.ProjectID == id).StatusID
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
        public ActionResult EditProject(EditProjectModel project)
        {

            var freelancers = _db.Freelancers.ToList();
            List<object> freelancerList = new List<object>();
            foreach (var f in freelancers)
            {
                freelancerList.Add(new
                {
                    ID = f.ID,
                    Name = f.Name + " " + f.Surname
                });
                this.ViewData["DBFreelancers"] = new SelectList(freelancerList, "ID", "Name");
            }


            var companies = new SelectList(_db.Companies.ToList(), "ID", "Name");
            ViewData["DBCompanies"] = companies;

            ViewBag.currentStatus = _db.Project_Status.FirstOrDefault(x => x.ProjectID == project.ID).Status.Name;
            var status = new SelectList(_db.Status.ToList(), "ID", "Name");
            ViewData["DBStatus"] = status;



            if (ModelState.IsValid)
            {
                var projectToUpdate = _db.Projects.FirstOrDefault(x => x.ID == project.ID); //ვპოულობ პროექტს დასარედაქტირებლად
                var statusToUpdate = _db.Project_Status.FirstOrDefault(x => x.ProjectID == project.ID); //ვპოულობ პროექტის სტატუსს დასარედაქტირებლად


                projectToUpdate.Name = project.Name.Trim();
                projectToUpdate.Description = project.Description;
                projectToUpdate.StartDate = project.StartDate;
                projectToUpdate.CompanyID = project.CompanyID;
                projectToUpdate.FreelancerID = project.FreelancerID;
                projectToUpdate.Project_Status.FirstOrDefault(x => x.ProjectID == project.ID).StatusID = project.StatusID;
                _db.SaveChanges();




                if (project.StatusID == 2) //თუ პროექტის სტატუსი არის 2 ანუ სტატუს ცხრილში 2 ნიშნავს მიმდინარეს, მაშინ პროექტის სტატუსი რჩება მიმდინარეთ და პროექტის დასრულების თარიღი ხდება null.
                {
                    statusToUpdate.StatusID = project.StatusID;
                    projectToUpdate.EndDate = null;
                    _db.SaveChanges();
                }
                else
                {
                    statusToUpdate.StatusID = project.StatusID; //თუ პროექტის სტატუსი არის 3 ანუ სტატუს ცხრილში 3 ნიშნავს დასრულებულს, მაშნ პროქტის სტატუსი ხდება დასრულებული.
                    projectToUpdate.EndDate = DateTime.Now;
                    _db.SaveChanges();
                }

                //return RedirectToAction("EditProject");
                return Redirect(Url.Action("EditProject", "Admin", new { id = project.ID }));
            }
            return View(project);
        }

        [AdminFilter]
        public ActionResult ProjectDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = _db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        public JsonResult DeleteProject(int? id)
        {
            _db.Projects.Remove(_db.Projects.Where(x => x.ID == id).FirstOrDefault()); //პროექტის წაშლა.
            _db.Project_Status.Remove(_db.Project_Status.Where(x => x.ProjectID == id).FirstOrDefault()); //პროექტის სტატუსის წაშლა.
            _db.Issues.RemoveRange(_db.Issues.Where(x => x.ProjectID == id)); //პროექტის წაშლის შემდეგ, კონკრეტულ პროექტზე დამატებული ამოცანების წაშლა.
            _db.Issue_Status.RemoveRange(_db.Issue_Status.Where(x => x.Issue.ProjectID == id)); //კონკრეტული პროექტის წაშლის შემდეგ, იმ პროექტის ამოცანების სტატუსების წაშლა რომელ პროექტზეც ეს ამოცანებია დამატებული.
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

            var freelancer = _db.Projects.FirstOrDefault(x => x.ID == id);
            var result = new FreelancerEvaluationModel
            {
               ID = freelancer.FreelancerID.Value,
               Name = freelancer.Freelancer.Name + " " + freelancer.Freelancer.Surname,
               FreelancerRating = freelancer.FreelancerRating.Value,
               FreelancerEvaluation = freelancer.FreelancerEvaluation
            };

            //ViewBag.freelancerRating = freelancer.FreelancerRating;
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
                var freelancerToEvaluate = _db.Projects.FirstOrDefault(x => x.ID == model.ID);
                freelancerToEvaluate.FreelancerRating = model.FreelancerRating;
                freelancerToEvaluate.FreelancerEvaluation = model.FreelancerEvaluation;
                _db.SaveChanges();
            }
            return RedirectToAction("AdminPanel", "Admin");
        }

        [AdminFilter]
        public ActionResult CompanyEvaluation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var company = _db.Projects.FirstOrDefault(x=> x.ID == id);
            var result = new CompanyEvaluationModel
            {
                ID = company.CompanyID,
                Name = company.Company.Name,
                CompanyRating = company.CompanyRating.Value,
                CompanyEvaluation = company.CompanyEvaluation
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
                var companyToEvaluate = _db.Projects.FirstOrDefault(x => x.ID == model.ID);
                companyToEvaluate.CompanyRating = model.CompanyRating;
                companyToEvaluate.CompanyEvaluation = model.CompanyEvaluation;
                _db.SaveChanges();
            }
            return RedirectToAction("AdminPanel", "Admin");

        }


        public ActionResult AddTaskToProject(int? id)
        {
            ViewBag.HiddenProjectID = id;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddTaskToProject(AddTaskToProjectModel Task, int? id)
        {
            
            var admin = LoginHelperForAdmin.admin();

            try
            {
                if (ModelState.IsValid)
                {
                    Issue issue = new Issue();
                    Issue_Status issueStatus = new Issue_Status();
                    issue.Name = Task.Name;
                    issue.Body = Task.Body;
                    issue.AdminID = admin.ID;
                    issue.isCompleted = false;
                    issue.ProjectID = id.Value;
                    issue.DueDate = Task.DueDate;
                    issue.DateCreated = DateTime.Now;
                    _db.Issues.Add(issue);
                    _db.SaveChanges();
                    issueStatus.StatusID = 2;
                    issueStatus.IssueID = issue.ID;
                    issueStatus.Date = DateTime.Now;
                    _db.Issue_Status.Add(issueStatus);
                    _db.SaveChanges();
                    ViewBag.TaskAdded = "ამოცანა დაემატა წარმატებით";
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }


            return View();
        }

        [AdminFilter]
        public ActionResult AllTask()
        {
            var issues = _db.Issues.ToList();  
            return View(issues);
        }


        [AdminFilter]
        public ActionResult EditTask(int? id)
        {


            ViewBag.currentStatus = _db.Issue_Status.FirstOrDefault(x => x.IssueID == id).Status.Name;
            var status = new SelectList(_db.Status.ToList(), "ID", "Name");
            ViewData["DBStatus"] = status;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var issue = _db.Issues.Find(id);
            var result = new EditIssueModel
            {
                ID = issue.ID,
                Name = issue.Name,
                Body = issue.Body,
                //StatusID = project.Project_Status.FirstOrDefault(x => x.ProjectID == id).StatusID
                StatusID = issue.Issue_Status.FirstOrDefault(x=> x.IssueID == id).StatusID,
                DueDate = issue.DueDate


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
        public ActionResult EditTask(EditIssueModel issue)
        {

            var issueToUpdate = _db.Issues.FirstOrDefault(x => x.ID == issue.ID); //ვპოულობ ამოცანას დასარედაქტირებლად
            var statusToUpdate = _db.Issue_Status.FirstOrDefault(x => x.IssueID == issue.ID); //ვპოულობ ამოცანის სტატუსს დასარედაქტირებლად

            ViewBag.currentStatus = _db.Issue_Status.FirstOrDefault(x => x.IssueID == issue.ID).Status.Name; //ამოცანის სტატუსი
            var status = new SelectList(_db.Status.ToList(), "ID", "Name");
            ViewData["DBStatus"] = status;

          

            if (ModelState.IsValid)
            {
                issueToUpdate.Name = issue.Name;
                issueToUpdate.Body = issue.Body;
                issueToUpdate.DueDate = issue.DueDate;
                _db.SaveChanges();



                if (issue.StatusID == 2)  //თუ ადმინისტრატორმა ამოცანა აირჩია როგორც მინდინარე, მაშინ ამოცანა ხდება შესასრულებელი.
                {
                    statusToUpdate.StatusID = issue.StatusID;
                    issueToUpdate.isCompleted = false;
                    _db.SaveChanges();
                }
                else
                {
                    statusToUpdate.StatusID = issue.StatusID; //თუ ადმინისტრატორმა ამოცანა აირჩია როგორც დასრულებული, მაშინ ამოცანა შესრულებული.
                    issueToUpdate.isCompleted = true;
                    _db.SaveChanges();
                }
                return Redirect(Url.Action("EditTask", "Admin", new { id = issue.ID }));


            }
            return View(issue);
        }

        [AdminFilter]
        public ActionResult TaskDetails(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = _db.Issues.Find(id);
            if(issue == null)
            {
                return HttpNotFound();
            }
            return View(issue);
        }

        [HttpPost]
        public JsonResult DeleteTask(int id)
        {
            _db.Issues.Remove(_db.Issues.Where(x => x.ID == id).FirstOrDefault());
            _db.Issue_Status.Remove(_db.Issue_Status.Where(x => x.IssueID == id).FirstOrDefault());
            _db.SaveChanges();
            return Json("DeleteSucceeded", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult TaskCompleted(int id)
        {
            Issue issue = _db.Issues.Find(id);
            var issueStatus = _db.Issue_Status.FirstOrDefault(x => x.IssueID == issue.ID); //ვიპოვე ამოცანის სტატუსი.
            issue.isCompleted = true;
            issueStatus.StatusID = 3; //შესრულება button-ზე კლიკის დროს ამოცანის სტატუსი ხდება 3 ანუ დასრულებული. (3 ნიშნავს Status Table-ში დასრულებულს)
            _db.Entry(issue).State = EntityState.Modified;
            _db.SaveChanges();
            ViewBag.TaskCompletedSuccessfully = "ამოცანა დასრულდა წარმატებით";
            return Json("TaskCompletedSuccessfully", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult TaskMarkedAsOngoing(int id)
        {
            Issue issue = _db.Issues.Find(id);
            var issueStatus = _db.Issue_Status.FirstOrDefault(x => x.IssueID == issue.ID); //ვიპოვე ამოცანის სტატუსი.
            issue.isCompleted = false;
            issueStatus.StatusID = 2; //შესრულებულ button-ზე კლიკის დროს ამოცანის სტატუსი ხდება 2 ანუ მიმდინარე, ფრილანსერს შეუძლია დააბრუნოს ამოცანა როგორც შესასრულებელი. (2 ნიშნავს Status Table-ში მიმდინარეს)
            _db.Entry(issue).State = EntityState.Modified;
            _db.SaveChanges();
            return Json("TaskMarkedAsOngoing", JsonRequestBehavior.AllowGet);
        }



    }
}