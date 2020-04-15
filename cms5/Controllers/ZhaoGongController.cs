using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace cms5.Controllers
{
    public class ZhaoGongController : Controller
    {
        // GET: ZhaoGong
        public ActionResult Index(UserInfo obj)
        {

            //招聘信息列表 
            List<ZhaoPin> List = new ZhaoPinBLL().GetListIndex();
            ViewBag.zplist = List;
            //个人劳务列表 
            List<Laowu> Listlw = new LaowuBLL().GetLwListIndex();
            ViewBag.lwlist = Listlw;
            //消息法规列表 
            List<Article> Listtz = new ArticleBLL().GetListByAcidIndex(2);
            ViewBag.tzlist = Listtz;
            //培训通知列表 
            List<Article> Listpx = new ArticleBLL().GetListByAcidIndex(3);
            ViewBag.pxlist = Listpx;
            return View();
        }
        public ActionResult getZgList(UserInfo obj)
        {
            List<ZhaoGong> List = new ZhaoGongBLL().GetZgListIndex();
            ViewBag.zglist = List;
            return PartialView("_zglist",List);
        }

        #region _UCLeft分部视图登录状态
        public ActionResult UCLeft(UserInfo obj)
        {
            string uPhone = this.User.Identity.Name;
            obj = new UserInfoBLL().GetObjByTel(uPhone);
            return PartialView("_UCLeft", obj);
        }
        #endregion

        #region 分部视图工种城市
        public ActionResult _GzCity()
        {
            List<ZhaoGong> ListCity = new ZhaoGongBLL().GetZgCityList();
            ViewBag.ListCity = ListCity;
            List<ZhaoGong> List1 = new ZhaoGongBLL().GetGzList(1);
            List<ZhaoGong> List2 = new ZhaoGongBLL().GetGzList(2);
            List<ZhaoGong> List3 = new ZhaoGongBLL().GetGzList(3);
            List<ZhaoGong> List4 = new ZhaoGongBLL().GetGzList(4);
            ViewBag.list1 = List1;
            ViewBag.list2 = List2;
            ViewBag.list3 = List3;
            ViewBag.list4 = List4;
            return PartialView("_GzCity");
        }
        #endregion

        #region 分部视图劳务城市
        public ActionResult _LwCity()
        {

            List<Laowu> ListCity = new LaowuBLL().GetZhCityList();
            ViewBag.ListCity = ListCity;
            List<ZhaoGong> List1 = new ZhaoGongBLL().GetGzList(1);
            List<ZhaoGong> List2 = new ZhaoGongBLL().GetGzList(2);
            List<ZhaoGong> List3 = new ZhaoGongBLL().GetGzList(3);
            List<ZhaoGong> List4 = new ZhaoGongBLL().GetGzList(4);
            ViewBag.list1 = List1;
            ViewBag.list2 = List2;
            ViewBag.list3 = List3;
            ViewBag.list4 = List4;
            return PartialView("_LwCity");
        }
        #endregion

        #region 分部视图星级
        public ActionResult _Xin(string a)
        {

            ViewBag.xin = "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>"
                           + "<i class='glyphicon glyphicon-star-empty'></i>";
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
            return PartialView("_Xin",a);
        }
        #endregion

        #region 招工列表信息
        public ActionResult ZgInfo(string strWord)
        {
            // List<ZhaoGong> List = new ZhaoGongBLL().GetZgList();
            List<ZhaoGong> List = new ZhaoGongBLL().GetZgListByWord(strWord);
            ViewBag.list = List;
           
            return View();
        }
        #endregion

        #region 用户中心
        [Authorize]
        public ActionResult userCenter(UserInfo obj)
        {
            string userPhone =this.User.Identity.Name;
            obj = new UserInfoBLL().GetObjByTel(userPhone);
            return View(obj);
        }
        #endregion

        #region 招工发布页面（管理员）
        public ActionResult zgFabu(string info)
        {
            ViewBag.info = info;
            return View();
        }
        #endregion

        #region 工种
        public ActionResult GongZhong(string info)
        {
            ViewBag.info = info;
            List<ZhaoGong> List1 = new ZhaoGongBLL().GetGzList(1);
            List<ZhaoGong> List2 = new ZhaoGongBLL().GetGzList(2);
            List<ZhaoGong> List3 = new ZhaoGongBLL().GetGzList(3);
            List<ZhaoGong> List4 = new ZhaoGongBLL().GetGzList(4);
            ViewBag.list1 = List1;
            ViewBag.list2 = List2;
            ViewBag.list3 = List3;
            ViewBag.list4 = List4;
            return PartialView("_GongZhong");
        }
        #endregion

        #region 发布招工信息
        [Authorize]
        public ActionResult getZgFabu(ZhaoGong obj)
        {
      
            //if (ModelState.IsValid)
            //{
                obj = new ZhaoGong
                {
                    //zgId, zgTitle, zgXuqiu, zgZhuTilei, zgZhuti, zgArea, zgGz, zgNum, zgDetail, zgUser, zgPhone, 
                    //zgFaburen, zgStarttime, zgEndtime, zgAddtime, zgImg1, zgImg2, zgImg3, isTuijian, isRemen
                    zgTitle = obj.zgTitle,
                    zgXuqiu = obj.zgXuqiu,
                    zgZhuTilei = obj.zgZhuTilei,
                    zgZhuti = obj.zgZhuti,
                    zgArea = obj.zgArea,
                    zgGz = obj.zgGz,
                    zgNum = obj.zgNum,
                    zgDetail = obj.zgDetail,
                    zgUser = obj.zgUser,
                    zgPhone = obj.zgPhone,
                    zgStarttime = obj.zgStarttime,
                    zgEndtime = obj.zgEndtime,
                    zgFaburen = obj.zgFaburen
                };
                int result = new ZhaoGongBLL().Add(obj);
                string info = "--->" + obj.zgTitle + "消息已经成功发布！";
                return RedirectToAction("zgFabu", new { info });
                //return this.Content("<script>window.location='" + Url.Action("GetList", "SysAdmin") + "'</script>");
                //return this.Content("发布成功！");
            //}
            //return View("aZgFabu");
        }
        #endregion

        #region 获取招工信息详细
        public ActionResult GetDetail(string id)
        {
            ZhaoGong obj = new ZhaoGongBLL().GetObjById(id);
            ViewBag.id = id;
            return View("zgDetail", obj);
        }
        #endregion

        #region 我的招工信息列表
        [Authorize]
        public ActionResult MyFabu(string userPhone)
        {
            List<ZhaoGong> List = new ZhaoGongBLL().GetZgListByWord(userPhone);
            ViewBag.list = List;
            return View();
        }
        #endregion

        #region 删除对像
        public ActionResult Del(string id)
        {
            int result = new ZhaoGongBLL().Del(id);
            return this.Content("删除成功！");
            //string info = "已删除一条记录！";
            //return RedirectToAction("MyFabu", "Zhaogong", new { info });
        }
        #endregion

        [Authorize]
        #region  管理员招工信息列表
        public ActionResult aZgList()
        {
            List<ZhaoGong> List = new ZhaoGongBLL().GetZgList();
            ViewBag.list = List;
            return View();
        }
        #endregion

        #region 返回页面
        public ActionResult Sgzl()
        {
            return View();
        }
        public ActionResult zgDetail()
        {
            return View();
        }
        public ActionResult sgdInfo()
        {
            return View();
        }
        public ActionResult sgdDetail()
        {
            return View();
        }
        public ActionResult xmInfo()
        {
            return View();
        }
       
        #endregion
    }
}