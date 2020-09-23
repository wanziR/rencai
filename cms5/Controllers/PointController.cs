using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.XPath;
using Models;
using BLL;

namespace cms5.Controllers
{
    public class PointController : Controller
    {
        // GET: Point
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult GetAddPoint(string pointId,string userId)
        {

            pointId = "2";
            userId = "1";
            int addpoint = new PointBLL().AddPoint(Convert.ToInt32(pointId), Convert.ToInt32(userId), DateTime.Now);
            return this.Content("添加成功！");

        }
    }
}