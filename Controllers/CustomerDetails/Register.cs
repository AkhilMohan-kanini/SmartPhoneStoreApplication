using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SmartPhoneStoreApplication.Controllers.CustomerDetails
{
    public partial class CustomerController : Controller
    {
    
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer customer)
        {
            try
            {
                customerContext.Customers.Add(customer);
                customerContext.SaveChanges();
                ViewBag.SuccessMessage = "Customer Registered Successfully";
                ViewBag.ErrorMessage = "";
            }
            catch
            {
                ViewBag.ErrorMessage = " Customer Registration Failed";
                ViewBag.SuccessMessage = "";
            }

            return View();
        }
    
    }
}