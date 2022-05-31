using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Area.Models;

namespace MVC_Area.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }
    }
}