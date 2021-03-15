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