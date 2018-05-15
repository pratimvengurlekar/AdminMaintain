using AzureAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private EntityDBContext _context;
        public EmployeeController()
        {
            _context = new EntityDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            return View("EmployeeForm",new Employee());
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList<Employee>();
            return View(employees);
        }
    }
}