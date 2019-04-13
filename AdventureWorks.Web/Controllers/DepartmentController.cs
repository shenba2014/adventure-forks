using System.Collections.Generic;
using System.Web.Http;
using AdventureWorks.Services.HumanResources;

namespace AdventureWorks.Web.Controllers
{
	public class DepartmentsController : ApiController
	{
		[HttpGet]
		public IHttpActionResult Index()
		{
			DepartmentService departmentService = new DepartmentService();
			var departmentGroups = departmentService.GetDepartments();

			return Json(departmentGroups);
		}

		[HttpGet]
		public IHttpActionResult Employees(int id)
		{
			DepartmentService departmentService = new DepartmentService();
			var departmentEmployees = departmentService.GetDepartmentEmployees(id);
			var departmentInfo = departmentService.GetDepartmentInfo(id);
			var title = "Employees in " + departmentInfo.Name + " Department";

			return Json(new
			{
				Title = title,
				Employees = departmentEmployees
			});
		}
	}
}
