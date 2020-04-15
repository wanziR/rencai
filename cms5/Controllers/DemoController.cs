using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cms5.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Uedit(FormCollection fc)
        {
            ViewBag.content = fc["editor"];
            return View();
        }
      
    }
}