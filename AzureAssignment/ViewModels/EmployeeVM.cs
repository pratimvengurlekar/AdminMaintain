using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureAssignment.Models;
using System.ComponentModel.DataAnnotations;
using AzureAssignment.Validations;
using System.ComponentModel;

namespace AzureAssignment.ViewModels
{
    public class EmployeeVM 
    {
        private int _age;
        private DateTime _dob;
        
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(30)]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(40)]
        public string LName { get; set; }
       // [Range(18,75,ErrorMessage = "Age of the employee can be between 18 and 75")]
        public byte Age
        {
            get
            {
                _age = DateTime.Now.Year - DateOfBirth.Year;
                return Convert.ToByte(_age);
               
            }
            set
            {
                _age = value;
            }
           
        }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DateofBirth(ErrorMessage = "Date of Birth cannot be a future date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime DateOfBirth
        {
            get;
            set;
           
        }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}