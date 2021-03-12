using System;
using System.Collections.Generic;
using System.IO;
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

                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    string extension = Path.GetExtension(product.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    product.ImagePath = "~/Content/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Content/Images/"), fileName);
                    product.ImageFile.SaveAs(fileName);

                    adminContext.Products.Add(product);
                    adminContext.SaveChanges();
                    ViewBag.ErrorMessage = "Success";
                       
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