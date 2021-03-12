using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Home
{
    public partial class HomeController  : Controller
    {

        public ActionResult CompareProducts()
        {
            var brandNamesFromDb = context.Products.Select(p => p.BrandName);
            ViewBag.Brands = new SelectList(brandNamesFromDb.ToList(), "BrandName");
            return View();
        }

        public JsonResult GetProductsForCompare(string id)
        {

            var productsData = context.Products.Where(p => p.BrandName == id);
            return Json(productsData, JsonRequestBehavior.AllowGet);
        }
    }
}