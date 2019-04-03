using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace AdventureWorks.Web.Filters
{
    public class ActionLogFilter : IActionFilter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ActionLogFilter));

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log.Info($"Executing {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName} {filterContext.ActionDescriptor.ActionName}");
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log.Info(
                $"Executed {filterContext.ActionDescriptor.ControllerDescriptor.ControllerName} {filterContext.ActionDescriptor.ActionName}");
        }
    }
}