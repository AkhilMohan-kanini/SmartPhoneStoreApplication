using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Admin
{
    public partial class AdminController : Controller
    {

        public ActionResult ViewOrders()
        {
            
            if (Session["AdminID"] != null)
            {
               var  ordersData = adminContext.Orders.ToList();
                return View(ordersData);
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            
        }
    }
}