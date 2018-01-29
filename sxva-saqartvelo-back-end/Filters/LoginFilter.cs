using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace sxva_saqartvelo_back_end.Filters
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            //var user = (Freelancer)filterContext.HttpContext.Session["user"];

            //if(user == null)
            //{
            //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
            //    {
            //        { "controller", "Account" },
            //        { "action", "Login"}
            //    });
            //}
            base.OnActionExecuting(filterContext);
        }
    }
}