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
            

        //    return PartialView("_PartialFilterData", checkboxResult.Distinct());
        //}


        //GetSearchRecord
        //public PartialViewResult GetSearchRecord(string SearchResult)
        //{

        //    var searchResult = _db.Freelancers.Where(x => x.Name.Contains(SearchResult) ||

        //        x.Surname.Contains(SearchResult) ||

        //            x.Freelancer_Skill.Any(e => e.Skill.Name.Contains(SearchResult) ||

        //                x.Bio.Contains(SearchResult) ||

        //                    x.Projects.Any(y => y.Name.Contains(SearchResult) ||

        //                        y.Description.Contains(SearchResult) ||

        //                            y.Company.Name.Contains(SearchResult))))

        //                            .ToList()

        //                            .Select(x => new Freelancer
        //                            {
        //                                ID = x.ID,
        //                                Photo = x.Photo,
        //                                Name = x.Name,
        //                                Surname = x.Surname,
        //                                Freelancer_Skill = x.Freelancer_Skill,
        //                                Projects = x.Projects,
        //                                Rating = x.Rating
        //                            })
        //                            .ToList();

        //    return PartialView("_PartialFilterData", searchResult);
        //}


        //filterFreelancerByRating
        //public PartialViewResult filterFreelancerByRating(string ratingLow, string ratingHight)
        //{
        //    var ratingResult = _db.Freelancers.Where(x=> x.Rating.ToString().Contains(ratingLow) || x.Rating.ToString().Contains(ratingHight))
        //        .ToList()
        //        .Select(x=> new Freelancer
        //        {
        //            ID = x.ID,
        //            Photo = x.Photo,
        //            Name = x.Name,
        //            Surname = x.Surname,
        //            Freelancer_Skill = x.Freelancer_Skill,
        //            Projects = x.Projects,
        //            Rating = x.Rating
        //        })
        //        .ToList();

        //    return PartialView("_PartialFilterData", ratingResult);
        //}

        public PartialViewResult FilterFreelancerData(string SearchInput, string[] CheckedSkills, string RatingLow, string RatingHight)
        {
            List<Freelancer> freelancers = new List<Freelancer>();

            var parametersExist = false;
            
            //For Search Filter
            if(SearchInput != null && SearchInput != "" && SearchInput != " ")
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

            //For CheckBox
            if(CheckedSkills != null && CheckedSkills.Count() > 0)
            {
                parametersExist = true;
                foreach (string skillName in CheckedSkills)
                {
                    if (freelancers.Count < 1)
                    {
                        var SkillIds = _db.Skills.FirstOrDefault(x => x.Name.Equals(skillName)).ID;
                        var result = _db.Freelancers.Where(x => x.Freelancer_Skill.Any(e => e.SkillID == SkillIds)).ToList();
                        foreach (var f in result)
                        {
                            freelancers.Add(f);
                        }
                    }
                    else
                    {
                        var SkillIds = _db.Skills.FirstOrDefault(x => x.Name.Equals(skillName)).ID;
                        var result = _db.Freelancers.Where(x => x.Freelancer_Skill.Any(e => e.SkillID == SkillIds)).ToList();
                        foreach (var f in result)
                        {
                            freelancers.Add(f);
                        }
                    }
                }

                if (RatingLow != null && RatingLow.Count() > 0 || RatingHight != null && RatingHight.Count() > 0)
                {
                    parametersExist = true;
                    if (freelancers.Count < 1)
                    {
                        freelancers.AddRange(_db.Freelancers.Where(x => x.Rating.ToString().Contains(RatingLow) || x.Rating.ToString().Contains(RatingHight)).ToList());
                    }
                    else
                    {
                        freelancers = freelancers.Where(x => x.Rating.ToString().Contains(RatingLow) || x.Rating.ToString().Contains(RatingHight)).ToList();
                    }
                }

                if (freelancers.Count() < 1 && parametersExist == false)
                {
                    freelancers = _db.Freelancers.ToList();
                }

                //foreach (string skillName in CheckedSkills)
                //{

                //    var SkillIds = _db.Skills.FirstOrDefault(x => x.Name.Equals(skillName)).ID;

                //    if (freelancers.Count < 1)
                //    {
                //        var result = _db.Freelancers.Where(x => x.Freelancer_Skill.Any(e => e.SkillID == SkillIds)).ToList();
                //        foreach (var f in result)
                //        {
                //            freelancers.Add(f);
                //        }
                //    }
                //    else
                //    {
                //        var result = _db.Freelancers.Where(x => x.Freelancer_Skill.Any(e => e.SkillID == SkillIds)).ToList();
                //        foreach (var f in result)
                //        {
                //            freelancers.Add(f);
                //        }
                //    }
                //}
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