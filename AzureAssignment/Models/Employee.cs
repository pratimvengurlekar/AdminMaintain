using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Web;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace AzureAssignment.Models
{
    [Serializable()]
    public class Employee: ISerializable
    {
        public int Id { get; set; }
        
        public string FName { get; set; }
        
        public string LName { get; set; }
        public byte Age { get; set; }

        //[Display(Name = "Birthdate")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        
        public bool IsActive { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("FName", FName);
            info.AddValue("LName", LName);
            info.AddValue("Age", Age);
            info.AddValue("DateOfBirth", DateOfBirth);
            info.AddValue("Address", Address);
            info.AddValue("IsActive", IsActive);
        }
    }
}