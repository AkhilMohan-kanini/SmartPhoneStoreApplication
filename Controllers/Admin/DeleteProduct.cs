using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Admin
{
    public partial class AdminController : Controller
    {

        public ActionResult DeleteProduct(string id)
        {
            int tempID;
            Product productData = null;

            if (Session["AdminID"] != null)
            {

                try
                {

                    tempID = Int32.Parse(id);
                    productData = adminContext.Products.Find(tempID);
                }
                catch
                {
                    return RedirectToAction("AdminLogin", "Admin");
                }
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }


            return View(productData);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public ActionResult DeleteConfirmed(string id)
        {
            int tempID;
            Product productData = null;

            if (Session["AdminID"] != null)
            {
                try
                {
                    tempID = Int32.Parse(id);
                    productData = adminContext.Products.Find(tempID);
                    adminContext.Products.Remove(productData);
                    adminContext.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("AdminLogin", "Admin");
                }
            }
            else
            {
                return RedirectToAction("AdminLogin", "Admin");
            }


            return View(productData);

        }
    }
}