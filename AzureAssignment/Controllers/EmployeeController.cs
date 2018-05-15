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

        [HttpPost]
        public ActionResult Save(Employee emp)
        {
            if (emp.Id == 0)
            {
                _context.Employees.Add(emp);
            }
            else
            {
                var employeeinDb = _context.Employees.Single(e => e.Id == emp.Id);
                TryUpdateModel(employeeinDb);
            }
            _context.SaveChanges();
            return   RedirectToAction("Index", "Employee");    
            
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null)
                return HttpNotFound();

            return View("EmployeeForm",employee);
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList<Employee>();
            return View(employees);
        }
    }
}