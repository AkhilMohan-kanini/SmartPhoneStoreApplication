﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Customer
{
    public partial class CustomerController : Controller
    {
        public ActionResult FilterProducts()
        {
            var productsData = customerContext.Products.ToList();
            return View(productsData);
        }

    }
}