using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_NORTHWIND.CustomFilters;
using MVC_NORTHWIND.Models;

namespace MVC_NORTHWIND.Controllers
{
    public class CustomerController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        [AuthFilter]
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}