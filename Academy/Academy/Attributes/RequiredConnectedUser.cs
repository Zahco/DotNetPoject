using Academy.Models;
using System;
using System.Web.Mvc;

namespace Academy.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class RequiredConnectedUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!GlobalVariables.IsAuthenticated)
                filterContext.HttpContext.Response.Redirect("/Session/LogOn?ReturnUrl=" + filterContext.HttpContext.Request.RawUrl);
        }
    }
}