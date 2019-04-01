using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace AdventureWorks.Web.Filters
{
	public class ExceptionFilter : IExceptionFilter
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(ExceptionFilter));

		public void OnException(ExceptionContext filterContext)
		{
			Log.Error("Application Exception", filterContext.Exception);
		}
	}
}