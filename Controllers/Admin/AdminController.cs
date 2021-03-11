using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Admin
{
    public partial class AdminController : Controller
    {

        SmartPhoneStoreDBEntities adminContext = new SmartPhoneStoreDBEntities();
        // GET: Admin
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLogin admin)
        {

            if(ModelState.IsValid)
            {
                var adminDataFromDB = adminContext.AdminLogins.Find(admin.AdminID);

                if (adminDataFromDB != null)
                {
                    if (admin.AdminPassword == adminDataFromDB.AdminPassword)
                    {
                        TempData["AdminID"] = adminDataFromDB.AdminID;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Password Incorrect";
                        return View();
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "Admin ID Incorrect";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            ViewData["AdminID"] = TempData.Peek("AdminID").ToString();
            return View();
        }
    }
}