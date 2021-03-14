using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.CustomerDetails
{
    public partial class CustomerController : Controller
    {

        SmartPhoneStoreDBEntities customerContext = new SmartPhoneStoreDBEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

    }
}