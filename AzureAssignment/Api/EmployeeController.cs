using AzureAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace AzureAssignment.Api
{
    public class EmployeeController : ApiController
    {
        private EntityDBContext _context;

        public EmployeeController()
        {
            _context = new EntityDBContext();
        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

    }
}
