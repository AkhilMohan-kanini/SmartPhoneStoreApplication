using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPhoneStoreApplication.Controllers.Home
{
    public partial class HomeController : Controller
    {
        SmartPhoneStoreDBEntities context = new SmartPhoneStoreDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}