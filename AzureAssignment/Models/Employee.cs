using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AzureAssignment.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Display(Name ="Last Name")]
        public string LName { get; set; }
        public byte Age { get; set; }

        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }

    }
}