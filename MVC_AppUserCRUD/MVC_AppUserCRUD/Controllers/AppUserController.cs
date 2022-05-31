using MVC_AppUserCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppUserCRUD.Controllers
{
    public class AppUserController : Controller
    {

        public static List<AppUser> userList = new List<AppUser>()
        {
            new AppUser{Id=1,Username="admin",Email="admin@admin.com",Password="1234"},
            new AppUser{Id=2,Username="user",Email="user@user.com",Password="1234"}
        };



        // GET: AppUser
        public ActionResult Index()
        {
            return View(userList);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(AppUser appuser)
        {
            appuser.Id = userList.Count+1;
            userList.Add(appuser);
            return RedirectToAction("Index");
        }

        //Details
        public ActionResult Details(int id)
        {
            var userDetails = userList.Find(x=>x.Id==id);
            return View(userDetails);
        }

        //Update
        public ActionResult UpdateUser(int id)
        {
            var updated = userList.Find(x => x.Id == id);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(int id, string userName, string email)
        {
            var updated = userList.Find(x=>x.Id==id);
            updated.Username = userName;
            updated.Email = email;
            return RedirectToAction("Index");
        }


        //Delete
        public ActionResult Delete(int id)
        {
            var userDetails = userList.Find(x => x.Id == id);
            userList.Remove(userDetails);
            return View();
        }


    }
}