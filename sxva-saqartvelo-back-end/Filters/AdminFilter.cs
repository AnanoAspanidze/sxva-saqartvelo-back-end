using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using sxva_saqartvelo_back_end.Models;


namespace sxva_saqartvelo_back_end.Filters
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var admin = (Admin)filterContext.HttpContext.Session["admin"];

            if (admin == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Admin" },
                    { "action", "Login"}
                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}