using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.CustomerDetails
{
    public partial class CustomerController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer login)
        {
            var data = customerContext.Customers.FirstOrDefault(x => x.CustomerID == login.CustomerID);

            if (data != null)
            {

                if (data.CustomerPassword == login.CustomerPassword)
                {
                    Session["UserID"] = data.CustomerID;
                    TempData["UserID"] = data.CustomerID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Customer ID or Password Incorrect";
                    return View();
                }

            }
            else
            {
                ViewBag.ErrorMessage = "Login Failed";
                return View();
            }
        }

        public ActionResult LogOut(string id)
        {
            Session.Clear();
            return RedirectToAction("Login");
        }


    }
}