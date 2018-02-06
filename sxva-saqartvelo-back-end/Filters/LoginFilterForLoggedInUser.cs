using sxva_saqartvelo_back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sxva_saqartvelo_back_end.Filters
{
    public class LoginFilterForLoggedInUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var freelancer = (Freelancer)filterContext.HttpContext.Session["freelancer"];

            if (freelancer != null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Freelancer" },
                    { "action", "FreelancerProfile"}
                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}