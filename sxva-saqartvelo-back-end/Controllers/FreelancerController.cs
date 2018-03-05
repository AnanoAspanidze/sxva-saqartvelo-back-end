﻿using System;
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
        public PartialViewResult FilterFreelancerByCheckBox(string[] skills)
        {
            var checkboxResult = new List<Freelancer>();
            
            
            foreach (string skillName in skills)
            {
                var SkillIds = _db.Skills.FirstOrDefault(x => x.Name.Equals(skillName)).ID;
                var freelancers = _db.Freelancers.Where(x => x.Freelancer_Skill.Any(e=> e.SkillID == SkillIds)).ToList();
                foreach(var f in freelancers)
                {
                    checkboxResult.Add(f);   
                }
            }
            

            return PartialView("_PartialFilterData", checkboxResult.Distinct());
        }


        //GetSearchRecord
        public PartialViewResult GetSearchRecord(string SearchResult)
        {

            var searchResult = _db.Freelancers.Where(x => x.Name.Contains(SearchResult) ||

                x.Surname.Contains(SearchResult) ||

                    x.Freelancer_Skill.Any(e => e.Skill.Name.Contains(SearchResult) ||

                        x.Bio.Contains(SearchResult) ||

                            x.Projects.Any(y => y.Name.Contains(SearchResult) ||

                                y.Description.Contains(SearchResult) ||

                                    y.Company.Name.Contains(SearchResult))))

                                    .ToList()

                                    .Select(x => new Freelancer
                                    {
                                        ID = x.ID,
                                        Photo = x.Photo,
                                        Name = x.Name,
                                        Surname = x.Surname,
                                        Freelancer_Skill = x.Freelancer_Skill,
                                        Projects = x.Projects,
                                        Rating = x.Rating
                                    })
                                    .ToList();

            return PartialView("_PartialFilterData", searchResult);
        }


        //filterFreelancerByRating
        public PartialViewResult filterFreelancerByRating(string ratingLow, string ratingHight)
        {
            var ratingResult = _db.Freelancers.Where(x=> x.Rating.ToString().Contains(ratingLow) || x.Rating.ToString().Contains(ratingHight))
                .ToList()
                .Select(x=> new Freelancer
                {
                    ID = x.ID,
                    Photo = x.Photo,
                    Name = x.Name,
                    Surname = x.Surname,
                    Freelancer_Skill = x.Freelancer_Skill,
                    Projects = x.Projects,
                    Rating = x.Rating
                })
                .ToList();

            return PartialView("_PartialFilterData", ratingResult);
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