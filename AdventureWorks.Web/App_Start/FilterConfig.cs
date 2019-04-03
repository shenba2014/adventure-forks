using System.Web;
using System.Web.Mvc;
using AdventureWorks.Web.Filters;

namespace AdventureWorks.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionFilter());
            filters.Add(new ErrorHandler.AiHandleErrorAttribute());
            filters.Add(new ActionLogFilter());
        }
    }
}
