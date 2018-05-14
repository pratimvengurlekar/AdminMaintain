using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureAssignment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public byte Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}