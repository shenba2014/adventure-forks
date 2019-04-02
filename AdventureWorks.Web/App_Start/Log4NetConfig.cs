using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdventureWorks.Web
{
    public class Log4NetConfig
    {
        public static void Configure()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}