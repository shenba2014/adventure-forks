using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Appender;
using WebGrease.Css.Extensions;

namespace AdventureWorks.Web.Filters
{
	public class ExceptionFilter : IExceptionFilter
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(ExceptionFilter));

	    public void OnException(ExceptionContext filterContext)
	    {
	        Log.Error("Application Exception", filterContext.Exception);
	        Log.Logger.Repository.GetAppenders().OfType<BufferingAppenderSkeleton>()
	            .ForEach(x => x.Flush());
	    }
	}
}