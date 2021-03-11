using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Admin
{
    public partial class AdminController : Controller
    {

        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    adminContext.Products.Add(product);
                    adminContext.SaveChanges();
                }
               
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = "Exception Found : " + e.Message; 
                
            }
            return View();
        }
    }
}