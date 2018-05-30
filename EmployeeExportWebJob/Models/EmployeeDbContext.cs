using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeExportWebJob.Models
{
    class EmployeeDBContext:DbContext
    {
        public EmployeeDBContext() : base("name=EmpConnection")
        {

        }

        public DbSet<AzureAssignment.Models.Employee> Employees { get; set; }
    }
}
