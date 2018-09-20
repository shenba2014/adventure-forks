using System.Collections.Generic;

namespace AdventureWorks.Services.HumanResources
{
    public interface IDepartmentService
    {
        ICollection<Department> GetDepartments();

        DepartmentInfo GetDepartmentInfo(int departmentId);

        ICollection<DepartmentEmployee> GetDepartmentEmployees(int departmentId);
    }
}
