using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace cms5.Controllers
{
    public class LaowuController : Controller
    {
        // GET: Laowu
        public ActionResult Index()
        {
            return View();
        }

        #region 获取劳务信息列表（管理员）
        public ActionResult aLwList()
        {
            List<Laowu> list = new LaowuBLL().GetLwList();
            ViewBag.list = list;
            return View();
        }
        #endregion

        #region 找活列表信息
        public ActionResult lwInfo(string strWord)
        {
            // List<ZhaoHuo> List = new ZhaoHuoBLL().GetZgList();
            List<Laowu> ListCity = new LaowuBLL().GetZhCityList();
            ViewBag.ListCity = ListCity;
            List<Laowu> List = new LaowuBLL().GetZhListByWord(strWord);
            ViewBag.list = List;
            List<ZhaoGong> List1 = new ZhaoGongBLL().GetGzList(1);
            List<ZhaoGong> List2 = new ZhaoGongBLL().GetGzList(2);
            List<ZhaoGong> List3 = new ZhaoGongBLL().GetGzList(3);
            List<ZhaoGong> List4 = new ZhaoGongBLL().GetGzList(4);
            ViewBag.list1 = List1;
            ViewBag.list2 = List2;
            ViewBag.list3 = List3;
            ViewBag.list4 = List4;
            ViewBag.xin0 = "<i class='glyphicon glyphicon-star-empty'></i>"
                          + "<i class='glyphicon glyphicon-star-empty'></i>"
                          + "<i class='glyphicon glyphicon-star-empty'></i>"
                          + "<i class='glyphicon glyphicon-star-empty'></i>"
                          + "<i class='glyphicon glyphicon-star-empty'></i>";
            ViewBag.xin1 = "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>";
            ViewBag.xin2 = "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>";
            ViewBag.xin3 = "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>";
            ViewBag.xin4 = "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>";
            ViewBag.xin5 = "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                           + "<i class='glyphicon glyphicon-star'></i>"
                          + "<i class='glyphicon glyphicon-star'></i>";
            return View();
        }
        #endregion

        #region 获取劳务信息详细
        public ActionResult GetDetail(string id)
        {
            Laowu obj = new LaowuBLL().GetObjById(id);
            ViewBag.id = id;
            return View("lwDetail", obj);
        }
        #endregion

        #region 删除

        public ActionResult Del(string id)
        {
            int result = new LaowuBLL().Del(id);

            if (result == 1)
            {
                return this.Content("删除成功！");
            }
            else
            {
                return this.Content("删除失败！");
            }
        }
        #endregion

      

    }
}