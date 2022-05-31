using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_NORTHWIND.CustomFilters;
using MVC_NORTHWIND.Models;

namespace MVC_NORTHWIND.Controllers
{
    public class ProductController : Controller
    {
        
        NORTHWNDEntities db = new NORTHWNDEntities();

        [AuthFilter]
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}