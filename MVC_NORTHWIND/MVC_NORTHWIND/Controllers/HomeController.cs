using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_NORTHWIND.CustomFilters;
using MVC_NORTHWIND.Models;

namespace MVC_NORTHWIND.Controllers
{
    public class HomeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        [AuthFilter]
        public ActionResult Index()
        {
            //Toplam ürün sayısı
            var result1 = db.Products.Count();
            ViewBag.TotalProduct = result1;

            //Toplam çalışan sayısı
            var result2 = db.Employees.Count();
            ViewBag.EmployeeCount = result2;

            //Toplam sipariş sayısı
            var result3 = db.Orders.Count();
            ViewBag.OrderCount = result3;

            //Toplam Müşteri Sayısı
            var result4 = db.Customers.Count();
            ViewBag.CustomerCount = result4;

            //Siparişler
            TempData["Orders"] = db.Orders.ToList();
            TempData.Keep();

            return View();
        }

        public ActionResult Details(int id)
        {
            var details = db.Order_Details.FirstOrDefault(x => x.OrderID == id);
            return View(details);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.Users.Any(x => x.Username == user.Username || x.Email == user.Email))
                    {
                        TempData["Error"] = "Username or Email is already taken!";
                        return View(user);
                    }
                    else
                    {
                        db.Users.Add(user);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                }
                catch (Exception)
                {

                    return View();
                }
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                bool result = db.Users.Any(x => x.Username == userVM.Username && x.Password == userVM.Password);
                if (result)
                {
                    User user = db.Users.Where(x => x.Username == userVM.Username && x.Password == userVM.Password).FirstOrDefault();

                    Session["login"] = user;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Username or password is wrong!";
                    return View(userVM);
                }
            }
            else
            {
                return View(userVM);
            }
        }

    }
}