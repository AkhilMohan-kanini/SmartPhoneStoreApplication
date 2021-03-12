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
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Select Brand",
                Value = "0",
                Selected = true
            });
            items.Add(new SelectListItem { Text = "Samsung", Value = "Samsung" });
            items.Add(new SelectListItem { Text = "Poco", Value = "Poco" });
            items.Add(new SelectListItem { Text = "Redmi", Value = "Redmi" });
            items.Add(new SelectListItem { Text = "OnePlus", Value = "OnePlus" });
            ViewBag.Brands = items;

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