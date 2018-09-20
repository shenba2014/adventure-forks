using System;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Services.HumanResources
{
    public class DepartmentEmployee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime HireDate { get; set; }
    }
}
