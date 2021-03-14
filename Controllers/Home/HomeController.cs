using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Home
{
    public partial class HomeController : Controller
    {
        SmartPhoneStoreDBEntities context = new SmartPhoneStoreDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            if (TempData["UserID"] != null)
            {
                int tempID;
                string id = TempData.Peek("UserID").ToString();
                TempData["UserID"] = id;
                ViewBag.UserID = id;
                try
                {
                    tempID =  Int32.Parse(id);
                    var user = context.Customers.Find(tempID);        
                    ViewBag.UserName = user.FirstName;
                }
                catch
                {
                    return RedirectToAction("Login", "Customer");
                }
                
            }
            return View();
        }
    }
}