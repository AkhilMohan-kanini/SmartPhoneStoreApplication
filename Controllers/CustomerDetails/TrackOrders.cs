using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.CustomerDetails
{
    public partial class CustomerController : Controller
    {

        public ActionResult TrackOrders(string id)
        {
            int tempID2;
            Customer customerData = null;
            ViewBag.UserID = id;

            if (Session["UserID"] != null)
            {
                try
                {
                    tempID2 = Int32.Parse(id);
                    customerData = customerContext.Customers.Find(tempID2);
                    ViewBag.UserName = customerData.FirstName;
                }
                catch
                {
                    return RedirectToAction("Login", "Customer");
                }
            }
            else
            {
                return RedirectToAction("Login", "Customer");
            }

            try
            {
                int tempID = Int32.Parse(id);
                var ordersFromDB = customerContext.Orders.Where(o => o.CustomerID == tempID);
                return View(ordersFromDB);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}