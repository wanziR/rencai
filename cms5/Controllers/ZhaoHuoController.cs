using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace cms5.Controllers
{
    public class ZhaoHuoController : Controller
    {
        // GET: ZhaoHuo
        public ActionResult Index()
        {
            return View();
        }
        #region 找活列表信息
        public ActionResult zhInfo(string strWord)
        {
            // List<ZhaoHuo> List = new ZhaoHuoBLL().GetZgList();
            List<ZhaoHuo> ListCity = new ZhaoHuoBLL().GetZhCityList();
            ViewBag.ListCity = ListCity;
            List<ZhaoHuo> List = new ZhaoHuoBLL().GetZhListByWord(strWord);
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

        #region 获取找活信息详细
        public ActionResult GetDetail(string id)
        {
            ZhaoHuo obj = new ZhaoHuoBLL().GetObjById(id);
            ViewBag.id = id;
            return View("zhDetail", obj);
        }
        #endregion

        #region 发布找活信息
        //[Authorize]
        public ActionResult getZhFabu(ZhaoHuo obj)
        {
            if (ModelState.IsValid)
            {
                obj = new ZhaoHuo
                {
                    zhTitle = obj.zhTitle,
                    zhUser = obj.zhUser,
                    zhPhone = obj.zhPhone,
                    zhArea = obj.zhArea,
                    zhGz = obj.zhGz,
                    zhNum = obj.zhNum,
                    zhDetail = obj.zhDetail
                };
                int result = new ZhaoHuoBLL().Add(obj);
                string info = "--->" + obj.zhTitle + "消息已经成功发布！";
                return RedirectToAction("zhFabu", "ZhaoHuo", new { info });
                //return this.Content("<script>window.location='" + Url.Action("GetList", "SysAdmin") + "'</script>");
            }
            else return View("Reg");
        }
        #endregion

        #region 返回页面
        //[Authorize]
        public ActionResult zhFabu(string info)
        {
            List<ZhaoGong> List1 = new ZhaoGongBLL().GetGzList(1);
            List<ZhaoGong> List2 = new ZhaoGongBLL().GetGzList(2);
            List<ZhaoGong> List3 = new ZhaoGongBLL().GetGzList(3);
            List<ZhaoGong> List4 = new ZhaoGongBLL().GetGzList(4);
            ViewBag.list1 = List1;
            ViewBag.list2 = List2;
            ViewBag.list3 = List3;
            ViewBag.list4 = List4;
            return View();
        }
        #endregion
    }
}