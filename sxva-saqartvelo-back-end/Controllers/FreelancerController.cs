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
            ViewBag.CountFreelancers = _db.Freelancers.Count();
          
            //Mvc PagedList
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var freelancers = _db.Freelancers.OrderBy(x => Guid.NewGuid()).ToPagedList(pageNumber, pageSize);
            
            return View(freelancers);
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

//                            foreach (int skillName in CheckedSkills)
//                {
//                    if (freelancers.Count< 1)
//                    {
//                        var SkillIds = _db.Skills.FirstOrDefault(x => x.ID.Equals(skillName)).ID;
//        var result = _db.Freelancers.Where(x => x.Freelancer_Skill.Any(e => e.SkillID == SkillIds)).ToList();
//                        foreach (var f in result)
//                        {
//                            freelancers.Add(f);
//                        }
//}
//                }
            

        //    return PartialView("_PartialFilterData", checkboxResult.Distinct());
        //}



        public PartialViewResult FilterFreelancerData(int[] CheckedSkills, /*int RatingLow, int RatingHight,*/ string SearchInput)
        {
            List<Freelancer> freelancers = new List<Freelancer>();

            var parametersExist = false;


            //For CheckBox
            if (CheckedSkills != null && CheckedSkills.Count() > 0)
            {
                parametersExist = true;

                foreach (int skillName in CheckedSkills)
                {
                    var SkillIds = _db.Skills.FirstOrDefault(x => x.ID.Equals(skillName)).ID;
                    var result = _db.Freelancers.Where(x => x.Freelancer_Skill.Any(e => e.SkillID == SkillIds)).ToList();
                    foreach (var f in result)
                    {
                        freelancers.Add(f);
                    }
                }

            }




            //if (RatingLow != null && RatingLow.Count() > 0 || RatingHight != null && RatingHight.Count() > 0)
            //{
            //    parametersExist = true;
            //    if (freelancers.Count < 1)
            //    {
            //        freelancers.AddRange(_db.Freelancers.Where(x => x.Rating.Equals(RatingLow) || x.Rating.Equals(RatingHight)).ToList());
            //    }
            //    else
            //    {
            //        freelancers = freelancers.Where(x => x.Rating.Equals(RatingLow) || x.Rating.Equals(RatingHight)).ToList();
            //    }
            //}


            //if (RatingLow > 0)
            //{
            //    parametersExist = true;
            //    if (freelancers.Count < 1)
            //    {
            //        freelancers.AddRange(_db.Freelancers.Where(x => x.Rating == RatingLow).ToList());
            //    }
            //    else
            //    {
            //        freelancers = freelancers.Where(x => x.Rating == RatingLow).ToList();
            //    }
            //}

            //if (RatingHight > 0)
            //{
            //    parametersExist = true;
            //    if (freelancers.Count < 1)
            //    {
            //        freelancers.AddRange(_db.Freelancers.Where(x => x.Rating == RatingHight).ToList());
            //    }
            //    else
            //    {
            //        freelancers = freelancers.Where(x => x.Rating == RatingHight).ToList();
            //    }
            //}



            //For Search Filter
            if (SearchInput != null && SearchInput != "" && SearchInput != " ")
            {
                parametersExist = true;
                var searchWords = SearchInput.Split(' ');
                foreach(var word in searchWords)
                {
                    if (freelancers.Count < 1)
                    {
                        freelancers.AddRange(_db.Freelancers.Where(x => x.Name.Contains(word) ||
                        x.Surname.Contains(word) ||
                            x.Freelancer_Skill.Any(e => e.Skill.Name.Contains(word) ||
                                x.Bio.Contains(word) ||
                                    x.Projects.Any(y => y.Name.Contains(word) || y.Description.Contains(word) ||
                                        y.Company.Name.Contains(word)))).ToList());
                    }
                    else
                    {
                        freelancers = freelancers.Where(x => x.Name.Contains(word) ||
                        x.Surname.Contains(word) ||
                            x.Freelancer_Skill.Any(e => e.Skill.Name.Contains(word) ||
                                x.Bio.Contains(word) ||
                                    x.Projects.Any(y => y.Name.Contains(word) || y.Description.Contains(word) ||
                                        y.Company.Name.Contains(word)))).ToList();
                    }
                }
            }
            //


            if (freelancers.Count() < 1 && parametersExist == false)
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
    }
}