using AzureAssignment.Models;
using AzureAssignment.ViewModels;
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
            return View("EmployeeForm",new EmployeeVM());
        }

        [HttpPost]
        public ActionResult Save(EmployeeVM empvm)
        {
            if(!ModelState.IsValid)
            {
                var vm = new EmployeeVM
                {
                    FName = empvm.FName,
                    LName = empvm.LName,
                    Address = empvm.Address,
                    IsActive = empvm.IsActive,
                    Id = empvm.Id

                };
                return View("EmployeeForm", vm);
            }
            Employee emp = new Employee()
            {
                Id = empvm.Id,
                FName = empvm.FName,
                LName = empvm.LName,
                DateOfBirth = empvm.DateOfBirth,
                Address = empvm.Address,
                IsActive = empvm.IsActive,
                Age=empvm.Age
            };
            if (emp.Id == 0)
            {
                _context.Employees.Add(emp);
            }
            else
            {
                var employeeinDb = _context.Employees.Single(e => e.Id == emp.Id);
                //  TryUpdateModel(employeeinDb,"",new string[] { "FName", "LName", "Age", "DateOfBirth", "Address", "IsActive" });
                employeeinDb.FName = emp.FName;
                employeeinDb.LName = emp.LName;
                employeeinDb.DateOfBirth = emp.DateOfBirth;
                employeeinDb.Age = emp.Age;
                employeeinDb.Address = emp.Address;
                employeeinDb.IsActive = emp.IsActive;
            }
            _context.SaveChanges();
            return   RedirectToAction("Index", "Employee");    
            
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null)
                return HttpNotFound();
            var vm = new EmployeeVM
            {
                Id = employee.Id,
                FName = employee.FName,
                LName = employee.LName,
                Address = employee.Address,
                DateOfBirth = employee.DateOfBirth,
                IsActive = employee.IsActive
            };
            return View("EmployeeForm",vm);
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employees = _context.Employees.ToList<Employee>();
            return View(employees);
        }
    }
}