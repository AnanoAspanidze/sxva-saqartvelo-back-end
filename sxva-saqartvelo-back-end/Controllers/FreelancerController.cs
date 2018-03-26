using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sxva_saqartvelo_back_end.Models;
using sxva_saqartvelo_back_end.Filters;
using PagedList.Mvc;
using PagedList;
using System.Net;
using sxva_saqartvelo_back_end.Helpers;
using System.IO;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace sxva_saqartvelo_back_end.Controllers
{
    public class FreelancerController : Controller
    {

        OtherGeorgiaEntities _db = new OtherGeorgiaEntities();

        string randomSecret = "4b47a904bc5e81234a754f552355bf44"; //პაროლის დასაჰეშად



        public ActionResult Index(int? page)
        {
            ViewBag.CountFreelancers = _db.Freelancers.Count();

            //Mvc PagedList
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var freelancers = _db.Freelancers.OrderBy(x => Guid.NewGuid()).ToPagedList(pageNumber, pageSize);

            return View(freelancers);
        }



        public PartialViewResult FilterFreelancerData(string SearchInput, int[] CheckedSkills, int? RatingLow, int? RatingHight)
        {
            List<Freelancer> freelancers = new List<Freelancer>();

            var parametersExist = false;



            //For Search
            if (SearchInput != null && SearchInput != "" && SearchInput != " ")
            {
                parametersExist = true;
                var input = SearchInput.Trim();
                var searchWords = input.Split(' ');
                foreach (var word in searchWords)
                {
                    // თუ ცარიელია, ახლიდან ვავსებ. (თავზე გადაწერა)
                    if (freelancers.Count < 1)
                    {
                        freelancers.AddRange(_db.Freelancers.Where(x => x.Name.Contains(word) || x.Surname.Contains(word) || x.Freelancer_Skill.Any(e => e.Skill.Name.Contains(word)) || x.Bio.Contains(word) || x.Projects.Any(y => y.Name.Contains(word) || y.Description.Contains(word) || y.Company.Name.Contains(word))).ToList());
                    }
                    else
                    {
                        freelancers = freelancers.Where(x => x.Name.Contains(word) || x.Surname.Contains(word) || x.Freelancer_Skill.Any(e => e.Skill.Name.Contains(word)) || x.Bio.Contains(word) || x.Projects.Any(y => y.Name.Contains(word) || y.Description.Contains(word) || y.Company.Name.Contains(word))).ToList();
                    }
                }

                if (freelancers.Count < 1) return PartialView("_PartialFilterData", freelancers.Distinct());

            }
            //



            //For CheckBox Filter
            if (CheckedSkills != null && CheckedSkills.Count() > 0)
            {
                parametersExist = true;

                foreach (int skillID in CheckedSkills)
                {

                    if (freelancers.Count < 1)
                    {
                        freelancers.AddRange(_db.Freelancers.Where(x => x.Freelancer_Skill.Any(e => e.SkillID == skillID)).ToList());
                    }
                    else
                    {
                        freelancers = freelancers.Where(x => x.Freelancer_Skill.Any(e => e.SkillID == skillID)).ToList();
                    }

                }
                if (freelancers.Count < 1) return PartialView("_PartialFilterData", freelancers.Distinct());
            }
            //


            //For Range Slider Filter
            if (RatingLow >= 0 && RatingHight >= 0 && RatingLow <= RatingHight)
            {
                parametersExist = true;

                if (freelancers.Count < 1)
                {
                    freelancers.AddRange(_db.Freelancers.Where(x => x.Rating >= RatingLow && x.Rating <= RatingHight).ToList());
                }
                else
                {
                    freelancers = freelancers.Where(x => x.Rating >= RatingLow && x.Rating <= RatingHight).ToList();
                }

                if (freelancers.Count < 1) return PartialView("_PartialFilterData", freelancers.Distinct());
            }
            //

            if (parametersExist == false)
            {
                freelancers = _db.Freelancers.ToList();
            }

            return PartialView("_PartialFilterData", freelancers.Distinct());
        }


        public ActionResult Details(int id)
        {
            var freelancer = _db.Freelancers.FirstOrDefault(x => x.ID == id);
            return View(freelancer);
        }


        [LoginFilter]
        public ActionResult FreelancerProfile()
        {
            return View();
        }

        [LoginFilter]
        public ActionResult EditFreelancer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var editFreelancerViewModel = new EditFreelancerViewModel
            {
                freelancer = _db.Freelancers.Find(id)
            };
            if (editFreelancerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editFreelancerViewModel);
        }

        [ValidateInput(false)] //რამდენათ დასაშვებია?
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFreelancer([Bind(Include = "ID, Name, Surname, Field, Mobile, Bio, oldPassword, Password, RepeatPassword")] Freelancer editFreelancer, EditFreelancerViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var freelancerToEdit = _db.Freelancers.Find(editFreelancer.ID);
                
                if (freelancerToEdit == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }


                var hashedPassword = PasswordHashHelper.MD5Hash(randomSecret + model.editFreelancerModel.oldPassword);

                Freelancer freelancer = _db.Freelancers.FirstOrDefault(x => x.Password == hashedPassword);

                if(freelancer == null)
                {
                    ViewBag.error = "არსებული პაროლი არ არის სწორი";
                    return View(model);
                }
                else
                {
                    ViewBag.success = "მონაცემები წარმატებით შეიცვალა";
                }

                var existingFreelancer = _db.Freelancers.FirstOrDefault(x => x.ID == editFreelancer.ID);

                

                if (model.editFreelancerModel.Password != null)
                {
                    existingFreelancer.Password = PasswordHashHelper.MD5Hash(randomSecret + model.editFreelancerModel.Password.Trim());
                    _db.SaveChanges();

                    return View(model);
                }
               

                if (model.freelancer.Name != null)
                {
                    var allowedExtensions = new[] {
                    ".Jpg", ".png", ".jpg", ".jpeg"
                    };

                    //if(existingFreelancer.Photo != model.freelancer.Photo)
                    //{

                    //}

                    if (file != null)
                    {
                        var fileName = Path.GetFileName(file.FileName); //სურათის სახელი
                        var ext = Path.GetExtension(file.FileName); //სურათის extension
                        var randomString = Guid.NewGuid().ToString("N").Substring(0, 10); //რენდომ სტრინგი სურათის უნიკალურობისთვის
                        fileName = randomString + "ID" + existingFreelancer.ID; //სურათზე რენდომ სტრინგის და ფრილანსერის ID-ის დამატება უნიკალურობისთვის


                        if (allowedExtensions.Contains(ext))
                        {

                            string name = Path.GetFileNameWithoutExtension(fileName); //სურათი extension-ის გარეშე
                            var path = Path.Combine(Server.MapPath("~/img/pp"), name + ext); //ფოლდერი ატვირთული სურათების შესანახად
                            if (existingFreelancer.Photo != "default-freelancer-pic.png") //არსებული სურათი თუ არ არის ფრილასნერის default სურათი, "default-freelancer-pic.png", 
                            {
                                string existingFreelancerPhoto = Request.MapPath("~/img/pp/" + existingFreelancer.Photo); //არსებული ფრილასნერის სურათი
                                System.IO.File.Delete(existingFreelancerPhoto); //არსებული ფრილასნერის სურათის წაშლა თუ არსებული არ არის "default-freelancer-pic.png"
                                existingFreelancer.Photo = name + ext; //სურათის ჩაწერა ბაზაში
                                file.SaveAs(path); //სურათის შენახვა ფოლდერში
                                _db.SaveChanges();
                                ViewBag.uploadedFreelancerImg = name + ext; //ატვირთული სურათის ჩვენება layout-ის header-ისთვის და EditCompany view-ისთვის
                                return View(model);
                            }
                            else
                            {
                                existingFreelancer.Photo = name + ext; //სურათის ჩაწერა ბაზაში
                                file.SaveAs(path); //სურათის შენახვა ფოლდერში
                                _db.SaveChanges();
                                return View(model);
                            }
                              
                        }
                    }

                    

                    existingFreelancer.Name = model.freelancer.Name.Trim();
                    existingFreelancer.Surname = model.freelancer.Surname.Trim();
                    existingFreelancer.Field = model.freelancer.Field.Trim(); //ფრილანსერის პოზიცია, მაგ: ASP .NET MVC დეველოპერი
                    existingFreelancer.Mobile = model.freelancer.Mobile.Trim();
                    existingFreelancer.Bio = model.freelancer.Bio; //ფრილანსერის ბიოგრაფია
                    _db.SaveChanges();
                    return View(model);
                } 

            }
            return View(model);
        }
    }
}