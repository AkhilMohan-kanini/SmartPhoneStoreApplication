using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Home
{
    public partial class HomeController : Controller
    {

        public ActionResult Details(string id)
        {

            int tempID;
            Product productData = null;
            try
            {
                tempID = Int32.Parse(id);
                productData = context.Products.Find(tempID);
            }
            catch
            {
                return RedirectToAction("Login", "Customer");
            }

            if (Session["UserID"] != null)
            {
                int tempId = (int)Session["UserID"];
                var user = context.Customers.Find(tempId);
                ViewBag.UserName = user.FirstName;

            }

            return View(productData);

        }
    }
}