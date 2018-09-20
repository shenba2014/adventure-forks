using System.Web.Mvc;

namespace AdventureWorks.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}