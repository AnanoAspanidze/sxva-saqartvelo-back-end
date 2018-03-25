using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using sxva_saqartvelo_back_end.Models;

namespace sxva_saqartvelo_back_end.Filters
{
    public class LoginFilterForCompany : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var company = (Company)filterContext.HttpContext.Session["company"];

            if (company == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Account" },
                    { "action", "CompanyLogin"}
                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}