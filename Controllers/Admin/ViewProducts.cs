using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Admin
{
    public partial class AdminController : Controller
    {

        public ActionResult ViewProducts()
        {
            var productsData = adminContext.Products.ToList();
            return View(productsData);
        }
    }
}