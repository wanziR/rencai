using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BLL;
using Models;

namespace cms5.Controllers
{
    public class MobileController : Controller
    {
        // GET: Mobile
        #region 返回页面
        public ActionResult List()
        {
            return View();
        }
        public ActionResult lwInfo()
        {
            //个人劳务列表 
            List<Laowu> Listlw = new LaowuBLL().GetLwListIndex();
            ViewBag.lwlist = Listlw;
            return View();
        }
        public ActionResult zgInfo()
        {
            //用工信息列表 
            List<ZhaoGong> List = new ZhaoGongBLL().GetZgListIndex();
            ViewBag.zglist = List;
            return View();
        }
        public ActionResult lwDetail()
        {
            return View();
        }
        public ActionResult zgDetail()
        {
            return View();
        }
        public ActionResult msg()
        {
            return View();
        }
        public ActionResult user()
        {
            return View();
        }
        #endregion

        #region 主页
        public ActionResult Index()
        {
            //用工信息列表 
            List<ZhaoPin> List = new ZhaoPinBLL().GetListIndex();
            ViewBag.zplist = List;
            //个人劳务列表 
            List<Laowu> Listlw = new LaowuBLL().GetLwListIndex();
            ViewBag.lwlist = Listlw;
            return View();
        }
        #endregion

        #region 劳务详情
        public ActionResult GetLwXq(string id)
        {
            Laowu obj = new LaowuBLL().GetObjById(id);
            ViewBag.id = id;
            return View("lwDetail", obj);
        }
        #endregion

        #region 招工详情
        public ActionResult GetZgXq(string id)
        {
            ZhaoPin obj = new ZhaoPinBLL().GetObjById(id);
            ViewBag.id = id;
            return View("zgDetail", obj);
        }
        #endregion


        #region 登录
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Loginn()
        {
            return View();
        }
        #endregion

        #region 注册 
        public ActionResult reg()
        {
            return View();
        }
        #endregion

        #region 忘记密码 
        public ActionResult findPwd()
        {
            return View();
        }
        #endregion

        #region 发布 
        public ActionResult fabu()
        {

            return View();
        }
        #endregion

        #region 根据工种类获取工种列表

        public ActionResult getGzListByGzPid(int pid)
        {
            //工种列表 
            List<ZhaoGong> gzlsit = new ZhaoGongBLL().GetGzList(pid);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string strList = jss.Serialize(gzlsit);
            return Json(strList, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 招聘信息发布页面
        public ActionResult zpfabu(string info)
        {
            ViewBag.info = info;
            List<ZhaoPin> List = new ZhaoPinBLL().GetList();
            ViewBag.list = List;
            return View();
        }

        public ActionResult GetAdd(ZhaoPin obj)
        {
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
                string info = "添加成功！";
                return RedirectToAction("zpFabu",new {info});
                




        }
        #endregion
    }
}