using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AzureAssignment.Validations
{
    public class DateofBirthAttribute : ValidationAttribute
    {
        public DateofBirthAttribute()
        {
        }
        public override bool IsValid(object value)
        {
            var userDate = (DateTime)value;
            if (userDate >= DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}