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

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Select Brand",
                Value = "0",
                Selected = true
            });

            ViewBag.ModelNames = items;

            return View();
        }

        public JsonResult GetModels(string id)
        {

            var modelsData = from model in context.Products where model.BrandName == id select model.ModelName;
            ViewBag.ModelNames = new SelectList(modelsData.ToList(), "ModelName");
            return Json(modelsData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductsForCompare(string id)
        {

            var productsData = context.Products.Where(p => p.ModelName == id);
            return Json(productsData, JsonRequestBehavior.AllowGet);
        }
    }
}