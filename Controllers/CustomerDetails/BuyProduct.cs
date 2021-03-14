using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.CustomerDetails
{
    public partial class CustomerController : Controller
    {

        public ActionResult BuyProduct(string id)
        {
            if (Session["UserID"] != null)
            {
                int tempId = (int)Session["UserID"];
                var user = customerContext.Customers.Find(tempId);
                ViewBag.UserName = user.FirstName;
            }

            try
            {
                int tempId2 = Int32.Parse(id);
                var productData = customerContext.Products.Find(tempId2);
                ViewBag.ProductID = id;
                ViewBag.BrandName = productData.BrandName;
                ViewBag.ModelName = productData.ModelName;
                ViewBag.Price = productData.Price;
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost, ActionName("BuyProduct")]
        public ActionResult BuyProductConfirmed(string id)
        {
            Order order = new Order();
            if (Session["UserID"] != null)
            {
                int tempId = (int)Session["UserID"];
                var user = customerContext.Customers.Find(tempId);
                ViewBag.UserName = user.FirstName;
            }

            try
            {
                int tempId2 = Int32.Parse(id);
                var productData = customerContext.Products.Find(tempId2);
                order.ProductID = tempId2;
                order.CustomerID = (int)Session["UserID"];
                order.Quantity = 1;
                order.OrderStatus = "Confirmed";
                order.OrderedDate = DateTime.Now;
                order.ExpectedDate = (DateTime.Now).AddDays(3);
                order.Price = productData.Price;

                customerContext.Orders.Add(order);
                customerContext.SaveChanges();
                return View();
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}