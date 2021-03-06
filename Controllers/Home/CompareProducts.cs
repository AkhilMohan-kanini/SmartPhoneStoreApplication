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
            var brandNamesFromDb = context.Products.Select(p => p.BrandName).Distinct();
            ViewBag.Brands = new SelectList(brandNamesFromDb.ToList(), "BrandName");

            if(Session["UserID"] != null)
            {
                int tempId = (int)Session["UserID"];
                var user = context.Customers.Find(tempId);
                ViewBag.UserName = user.FirstName;
                ViewBag.UserID = tempId;
            }
             
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