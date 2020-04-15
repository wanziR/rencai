using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace cms5.Controllers
{
    public class ZhaoPinController : Controller
    {
        // GET: ZhaoPin
        //zpId, zpXuqiu, zpZhuTilei, zpZhuti, zpArea, zpGangwei, zpNum, zpPayL, zpPayH, zpFuli, 
        //zpDetail, zpUser, zpPhone, zpFaburen, zpAddtime, zpEndtime, isTuijian, isRemen
        #region 返回页面
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 招聘列表页面
        public ActionResult zpinfo(string strWord)
        {
            List<ZhaoPin> List = new ZhaoPinBLL().GetListByWord(strWord);
            ViewBag.list = List;
            return View();
        }
        #endregion

        #region 招聘管理列表
        public ActionResult aZpList()
        {
            List<ZhaoPin> List = new ZhaoPinBLL().GetList();
            ViewBag.list = List;
            return View();
        }
        #endregion

        #region 招聘信息发布页面
        public ActionResult zpfabu()
        {
            List<ZhaoPin> List = new ZhaoPinBLL().GetList();
            ViewBag.list = List;
            return View();
        }

        public ActionResult GetAdd(ZhaoPin obj)
        {
           
            if (obj.zpGangwei == null)
            {
                string warningText = "岗位信息不能为空！";
                return this.Content("<script>$(function(){warning('" + warningText + "');})</script>");
            }
            if (obj.zpZhuti == null)
            {
                string warningText = "主体信息不能为空！";
                return this.Content("<script>$(function(){warning('" + warningText + "');})</script>");
            }
            if (obj.zpNum < 1)
            {
                string warningText = "招聘人数不能为空！";
                return this.Content("<script>$(function(){warning('" + warningText + "');})</script>");
            }
            if (obj.zpArea == null)
            {
                string warningText = "招聘地区不能为空！";
                return this.Content("<script>$(function(){warning('" + warningText + "');})</script>");
            }
            if (obj.zpPayL == null)
            {
                string  warningText = "薪资待遇不能为空！";
                return this.Content("<script>$(function(){warning('"+ warningText + "');})</script>");
            }
            if (obj.zpUser == null)
            {
                string warningText = "联系人不能为空！";
                return this.Content("<script>$(function(){warning('" + warningText + "');})</script>");
            }
            else {
                obj = new ZhaoPin
                {
                    zpXuqiu = obj.zpXuqiu,
                    zpZhuTilei = obj.zpZhuTilei,
                    zpZhuti = obj.zpZhuti,
                    zpArea = obj.zpArea,
                    zpGangwei = obj.zpGangwei,
                    zpNum = obj.zpNum,
                    zpPayL = obj.zpPayL,
                    zpPayH = obj.zpPayH,
                    zpFuli = obj.zpFuli,
                    zpDetail = obj.zpDetail,
                    zpUser = obj.zpUser,
                    zpPhone = obj.zpPhone,
                    zpFaburen = obj.zpFaburen,
                    //zpAddtime = obj.admin_name,
                    zpEndtime = obj.zpEndtime
                };
                int result = new ZhaoPinBLL().Add(obj);
                if (Request.IsAjaxRequest())
                {
                    string successText = "添加成功！";
                    return this.Content("<script>$(function(){success('" + successText + "');})</script>");
                }
                else
                {
                    return this.Content("不是Ajax提交");
                    //return this.Content("<script>window.location='" + Url.Action("GetList", "SysAdmin") + "'</script>");
                }
            }
           
          
        }
        #endregion

        #region 详细   
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult GetDetail(string id)
        {
            ZhaoPin obj = new ZhaoPinBLL().GetObjById(id);
            ViewBag.id = id;
            return View("Detail", obj);
        }
        #endregion

        #region 删除

        public ActionResult Del(string Id)
        {
            int result = new ZhaoPinBLL().Del(Id);

            if (result == 1)
            {
                return this.Content("删除成功！");
                //string info = "删除成功！";
                //return RedirectToAction("aUserList", "UserInfo", new { info });

            }
            else
            {
                return this.Content("删除失败！");
            }
        }
        #endregion



    }
}