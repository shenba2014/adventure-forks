using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventureWorks.Services.HumanResources;

namespace AdventureWorks.Web.Controllers
{
	[RoutePrefix("Departments")]
    public class DepartmentViewController : Controller
    {
		// GET: Departments
	    [Route]
		public ActionResult Index()
	    {
		    DepartmentService departmentService = new DepartmentService();
		    var departmentGroups = departmentService.GetDepartments();

		    return View(departmentGroups);
	    }

		// GET: Departments/Employees/{id}
		[Route("{id}")]
		public ActionResult Employees(int id)
	    {
		    DepartmentService departmentService = new DepartmentService();
		    var departmentEmployees = departmentService.GetDepartmentEmployees(id);
		    var departmentInfo = departmentService.GetDepartmentInfo(id);

		    ViewBag.Title = "Employees in " + departmentInfo.Name + " Department";

		    return View(departmentEmployees);
	    }
	}
}