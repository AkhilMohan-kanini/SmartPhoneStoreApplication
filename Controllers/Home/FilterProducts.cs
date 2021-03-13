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

            var productsData = context.Products.ToList();
            return View(productsData);
        }

        public JsonResult GetProducts(string id)
        {

            var productsData = context.Products.Where(p => p.BrandName == id);
            return Json(productsData, JsonRequestBehavior.AllowGet);
        }

    }
}