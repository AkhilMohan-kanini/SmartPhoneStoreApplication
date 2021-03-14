using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.CustomerDetails
{
    public partial class CustomerController : Controller
    {

        public ActionResult UserProfile(string id)
        {

            int tempID;
            Customer customerData = null;
            ViewBag.UserID = id;


            if (Session["UserID"] != null)
            {
                try
                {
                    tempID =  Int32.Parse(id);
                    customerData = customerContext.Customers.Find(tempID);
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

            TempData["UserID"] = id;
            return View(customerData);
        }
    }
}