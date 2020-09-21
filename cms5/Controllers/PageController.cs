using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace cms5.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index(string id)
        {
           int iID = Convert.ToInt32(id);
            Article obj = new ArticleBLL().GetObjByAsId(iID);
            return View(obj);
        }
        
    }
}