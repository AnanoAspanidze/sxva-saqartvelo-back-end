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


            //For Range Slier Filter
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFreelancer([Bind(Include = "ID, Name, Surname, Field, Mobile, oldPassword, Password, RepeatPassword")] Freelancer editFreelancer, EditFreelancerViewModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                var freelancerToEdit = _db.Freelancers.Find(editFreelancer.ID);
                
                if (freelancerToEdit == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var existingFreelancer = _db.Freelancers.FirstOrDefault(x => x.ID == editFreelancer.ID);



                //if (model.freelancer.Name == null || model.freelancer.Surname == null || model.freelancer.Field == null || model.freelancer.Mobile == null || model.editFreelancerModel.Password == null)
                if(existingFreelancer == null)
                {
                    //existingFreelancer.Name = existingFreelancer.Name;
                    //existingFreelancer.Surname = existingFreelancer.Surname;
                    //existingFreelancer.Field = existingFreelancer.Field;
                    //existingFreelancer.Mobile = existingFreelancer.Mobile;
                    //existingFreelancer.Password = existingFreelancer.Password;

                    //_db.SaveChanges();
                    //return View(model);
                    existingFreelancer.Name = editFreelancer.Name;
                    existingFreelancer.Surname = editFreelancer.Surname;
                    existingFreelancer.Field = editFreelancer.Field;
                    existingFreelancer.Mobile = editFreelancer.Mobile;
                    _db.SaveChanges();
                    
                }
                else
                {
                    existingFreelancer.Name = model.freelancer.Name.Trim();
                    existingFreelancer.Surname = model.freelancer.Surname.Trim();
                    existingFreelancer.Field = model.freelancer.Field.Trim();
                    existingFreelancer.Mobile = model.freelancer.Mobile.Trim();
                    existingFreelancer.Password = PasswordHashHelper.MD5Hash(randomSecret + model.editFreelancerModel.Password.Trim());
                    _db.SaveChanges();
                    return View(model);
                }
                


                //if (model.freelancer.Name == null || model.freelancer.Surname == null || model.freelancer.Field == null || model.freelancer.Mobile == null || model.editFreelancerModel.oldPassword == null || model.editFreelancerModel.Password == null || model.editFreelancerModel.RepeatPassword == null)
                //{
                //    freelancerToEdit.Name = freelancerToEdit.Name;
                //    freelancerToEdit.Surname = freelancerToEdit.Surname;
                //    freelancerToEdit.Field = freelancerToEdit.Field;
                //    freelancerToEdit.Mobile = freelancerToEdit.Mobile;
                //    freelancerToEdit.Password = freelancerToEdit.Password;
                //    freelancerToEdit.Bio = freelancerToEdit.Bio;
                //    _db.SaveChanges();
                //    return View(model);
                //}
                //if (model.freelancer.Name != null || model.freelancer.Surname != null || model.freelancer.Field != null || model.freelancer.Mobile != null || model.editFreelancerModel.oldPassword != null || model.editFreelancerModel.Password != null || model.editFreelancerModel.RepeatPassword != null)
                //{
                //    freelancerToEdit.Name = model.freelancer.Name.Trim();
                //    freelancerToEdit.Surname = model.freelancer.Surname.Trim();
                //    freelancerToEdit.Field = model.freelancer.Field.Trim();
                //    freelancerToEdit.Mobile = model.freelancer.Mobile.Trim();
                //    freelancerToEdit.Password = PasswordHashHelper.MD5Hash(randomSecret + model.editFreelancerModel.Password.Trim());
                //    _db.SaveChanges();
                //}
                if (freelancerToEdit.Password != PasswordHashHelper.MD5Hash(randomSecret + model.editFreelancerModel.oldPassword.Trim()))
                {
                    ViewBag.PasswordsDoNotMatch = "ძველი პაროლი არ ემთხვევა";
                    return View(model);
                }
                //else
                //{
                //    freelancerToEdit.Name = model.freelancer.Name.Trim();
                //    freelancerToEdit.Surname = model.freelancer.Surname.Trim();
                //    freelancerToEdit.Field = model.freelancer.Field.Trim();
                //    freelancerToEdit.Mobile = model.freelancer.Mobile.Trim();
                //    freelancerToEdit.Password = PasswordHashHelper.MD5Hash(randomSecret + model.editFreelancerModel.Password.Trim());
                //    //freelancerToEdit.Bio = model.freelancer.Bio.Trim();
                //    _db.SaveChanges();
                //}

                
            }
            return View(model);
        }
    }
}






//FilterFreelancerByCheckBox
//public PartialViewResult FilterFreelancerByCheckBox(string[] skills)
//{
//    var checkboxResult = new List<Freelancer>();


//    foreach (string skillName in skills)
//    {
//        var SkillIds = _db.Skills.FirstOrDefault(x => x.Name.Equals(skillName)).ID;
//        var freelancers = _db.Freelancers.Where(x => x.Freelancer_Skill.Any(e=> e.SkillID == SkillIds)).ToList();
//        foreach(var f in freelancers)
//        {
//            checkboxResult.Add(f);   
//        }
//    }

//    return PartialView("_PartialFilterData", checkboxResult.Distinct());
//}
