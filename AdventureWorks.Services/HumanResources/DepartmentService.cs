using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks.Services.HumanResources
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DbModel.Entities _entities = new DbModel.Entities();

        public DepartmentService()
        {
        }

        public ICollection<Department> GetDepartments()
        {
            var query = from d in _entities.Departments
                        select new Department
                        {
                            Id = d.DepartmentID,
                            Name = d.Name,
                            GroupName = d.GroupName
                        };

            return query.ToArray();
        }

        public DepartmentInfo GetDepartmentInfo(int departmentId)
        {
            var query = from d in _entities.Departments
                        where d.DepartmentID == departmentId
                        select new DepartmentInfo
                        {
                            Id = d.DepartmentID,
                            Name = d.Name,
                            NumberOfEmployees = _entities.EmployeeDepartmentHistories.Count(edh => edh.DepartmentID == departmentId)
                        };

            return query.FirstOrDefault();
        }

        //    from category in categories
        //join prod in products on category.ID equals prod.CategoryID
        //select new { ProductName = prod.Name, Category = category.Name

        public ICollection<DepartmentEmployee> GetDepartmentEmployees(int departmentId)
        {
            var query = from e in _entities.Employees
                        join edh in _entities.EmployeeDepartmentHistories on e.BusinessEntityID equals edh.BusinessEntityID
                        join p in _entities.People on e.BusinessEntityID equals p.BusinessEntityID
                        where edh.DepartmentID == departmentId
                        select new DepartmentEmployee
                        {
                            Id = e.BusinessEntityID,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            JobTitle = e.JobTitle,
                            HireDate = e.HireDate
                        };

            return query.ToArray();
        }
    }
}
