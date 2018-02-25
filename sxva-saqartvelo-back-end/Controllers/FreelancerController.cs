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

        public ActionResult Index(int? page, FormCollection formCollection)
        {
            //Mvc PagedList
            int pageSize = 9;
            int pageNumber = (page ?? 1);

            var freelancers = _db.Freelancers.OrderBy(x => Guid.NewGuid()).ToPagedList(pageNumber, pageSize);
            return View(freelancers);
        }

        public PartialViewResult FilterSkills(string[] skills)
        {
            var result = new List<Skill>();

            foreach(string skillName in skills)
            {
                var skillID = _db.Skills.FirstOrDefault(x => x.Name.Equals(skillName)).ID;
                var freelancerSkills = _db.Skills.Where(x => x.ID == skillID).ToList();
                foreach(var freelancerSkill in freelancerSkills)
                {
                    result.Add(freelancerSkill);
                }
            }

            //result = result.OrderBy(x => Guid.NewGuid()).ToList();

            return PartialView("_PartialSkilss", result);
        }

        //Freelancer Profile Details
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