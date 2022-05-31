using MVC_CodeFirstExample.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CodeFirstExample.Controllers
{
    public class HomeController : Controller
    {
        ProjectContext db = new ProjectContext();
        
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(db.Products.ToList());
            }
            else
            {
                return View(db.Products.Where(x=>x.CategoryId==id).ToList());
            }
            
        }


        public PartialViewResult _CategoryPartial()
        {
            return PartialView(db.Categories.ToList());
        }
    }
}