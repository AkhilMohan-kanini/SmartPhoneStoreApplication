using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Home
{
    public partial class HomeController : Controller
    {
        public ActionResult FilterProducts()
        {
            var brandsFromDb = context.Products.Select(p => p.BrandName).Distinct();
            ViewBag.Brands = new SelectList( brandsFromDb.ToList() , "BrandName");

            if (Session["UserID"] != null)
            {
                int tempId = (int)Session["UserID"];
                var user = context.Customers.Find(tempId);
                ViewBag.UserName = user.FirstName;

            }

            var productsData = context.Products.ToList();
            return View(productsData);
        }

        public JsonResult GetProducts(string id)
        {
            ViewBag.ProductID = id;
            var productsData = context.Products.Where(p => p.BrandName == id);
            return Json(productsData, JsonRequestBehavior.AllowGet);
        }

    }
}