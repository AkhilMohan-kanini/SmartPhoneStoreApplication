using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.CustomerDetails
{
    public partial class CustomerController : Controller 
    {

        public ActionResult EditProfile(string id)
        {
            int tempID;
            Customer customerData = null;
            ViewBag.UserID = id;

            if (Session["UserID"] != null)
            {
                try
                {
                    tempID = Int32.Parse(id);
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

        [HttpPost]
        public ActionResult EditProfile(string id, Customer model)
        {

            System.Diagnostics.Debug.WriteLine(id);
            ViewBag.UserID = id;
            
            if (TempData["UserID"] != null)
            {
                try
                {
                  
                    int tempId = Int32.Parse(id);
                    var customerData = customerContext.Customers.FirstOrDefault(x => x.CustomerID == tempId);

                    System.Diagnostics.Debug.WriteLine(customerData);
                    customerData.FirstName = model.FirstName;
                    customerData.LastName = model.LastName;
                    customerData.EmailID = model.EmailID;
                    customerData.AddressLine1 = model.AddressLine1;
                    customerData.AddressLine2 = model.AddressLine2;
                    customerData.PinCode = model.PinCode;
                    customerData.District = model.District;
                    customerData.CustomerState = model.CustomerState;
                    customerData.MobileNumber = model.MobileNumber;

                    customerContext.SaveChanges();
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return RedirectToAction("Login", "Customer");
                }
            }
            else
            {
                return RedirectToAction("Login", "Customer");
            }

            TempData["UserID"] = id;
            return View();

        }




    }
}