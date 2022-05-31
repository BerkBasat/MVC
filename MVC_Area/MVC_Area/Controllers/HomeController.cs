using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Area.Models;

namespace MVC_Area.Controllers
{
    public class HomeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Index()
        {

            TempData["Products"] = db.Products.ToList();
            TempData["Categories"] = db.Categories.ToList();
            TempData.Keep();

            return View();
        }
    }
}