using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Admin
{
    public partial class AdminController : Controller
    {

        public ActionResult EditProduct(string id)
        {
            int tempID;
            Product productData = null;
            
            if (Session["AdminID"]!= null)
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

        [HttpPost]
        public ActionResult EditProduct(string id,Product model)
        {
            if (Session["AdminID"] != null)
            {
                try
                {
                    int tempId = Int32.Parse(id);
                    var productData = adminContext.Products.FirstOrDefault(x => x.ProductID == tempId);

                    productData.BrandName = model.BrandName;
                    productData.ModelName = model.ModelName;
                    productData.RAM = model.RAM;
                    productData.ROM = model.ROM;
                    productData.Display = model.Display;
                    productData.Battery = model.Battery;
                    productData.PrimaryCamera = model.PrimaryCamera;
                    productData.SecondaryCamera = model.SecondaryCamera;
                    productData.Processor = model.Processor;
                    productData.Color = model.Color;
                    productData.SimType = model.SimType;
                    productData.OsName = model.OsName;
                    productData.Price = model.Price;

                    adminContext.SaveChanges();
                }
                catch (Exception ex)
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