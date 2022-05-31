using MVC_Sepet.CustomFilters;
using MVC_Sepet.Models;
using MVC_Sepet.Utils;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Sepet.Controllers
{
    public class HomeController : Controller
    {

        NORTHWINDEntities db = new NORTHWINDEntities();

        public ActionResult Index()
        {
            return View(db.Products.Where(x => x.CategoryID != null && x.UnitsInStock > 0).ToList());
        }

        public ActionResult AddToCart(int id)//50000
        {
            try
            {
                Product product = db.Products.Find(id);

                Cart c = null;

                if (Session["scart"] == null)
                {
                    c = new Cart();
                }
                else
                {
                    c = Session["scart"] as Cart;
                }

                //Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

                CartItem ci = new CartItem();
                ci.Id = product.ProductID;
                ci.Price = product.UnitPrice;
                ci.ProductName = product.ProductName;
                c.AddItem(ci);
                Session["scart"] = c;

                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {
                TempData["error"] = $"{id} karşılık gelen bir ürün bulunamadı!";
                return View();

            }

        }

        public ActionResult MyCart()
        {
            if (Session["scart"] != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "sepetinizde ürün bulunmamaktadır!";
                return RedirectToAction("Index");
            }
        }

        [AuthFilter]
        public ActionResult CompleteCart()
        {
            Cart cart = Session["scart"] as Cart;
            foreach (var item in cart.myCart)
            {
                Product product = db.Products.Find(item.Id);
                product.UnitsInStock -= Convert.ToInt16(item.Quantity);
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.OrderNumber = "156565";
                Session.Remove("scart");

                MailSender.SendEmail("basatberk@gmail.com", "Sipariş Bilgisi", "Sayın müşterimiz, siparişiniz alınmıştır. Sipariş Numarası: 156565");

            }
            return View();
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