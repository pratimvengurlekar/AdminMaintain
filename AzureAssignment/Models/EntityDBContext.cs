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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(f => f.FName)
                .IsRequired()
                .HasMaxLength(30);

            modelBuilder.Entity<Employee>()
               .Property(f => f.LName)
               .HasMaxLength(40);

            modelBuilder.Entity<Employee>()
               .Property(f => f.Address)
               .IsRequired()
               .HasMaxLength(255);

            modelBuilder.Entity<Employee>()
               .Property(f => f.DateOfBirth)
               .IsRequired();

            base.OnModelCreating(modelBuilder); 
        }
    }
}