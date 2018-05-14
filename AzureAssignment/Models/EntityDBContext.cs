using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AzureAssignment.Models
{
    public class EntityDBContext :DbContext
    {
        public EntityDBContext() : base("name=DbConnection")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}