using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_NORTHWIND.CustomFilters;
using MVC_NORTHWIND.Models;

namespace MVC_NORTHWIND.Controllers
{
    public class EmployeeController : Controller
    {
        
        NORTHWNDEntities db = new NORTHWNDEntities();

        [AuthFilter]
        public ActionResult Index()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}