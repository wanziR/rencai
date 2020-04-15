using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Web.Security;


namespace cms5.Controllers
{
    public class SysAdminController : Controller
    {
        // GET: SysAdmin
        [Authorize]
        public ActionResult Index(SysAdmin objAdmin)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                string adminName = this.User.Identity.Name;  //获取写入cookie的adminName
                ViewBag.adminName = adminName;
                ViewBag.info = "欢迎你" + adminName;
                return View();
            }
            else
            {
                return View("Login");
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }

        #region 登录判断
        public ActionResult AdminLogin(SysAdmin obj)
        {
            obj = new SysAdmin
            {
                admin_name = obj.admin_name,
                admin_pwd = obj.admin_pwd
            };
            obj = new SysAdminBLL().Login(obj);
            if (obj != null)
            {
                string adminName = obj.admin_name;
                FormsAuthentication.SetAuthCookie(adminName, true);
                ViewBag.info = "欢迎你" + adminName;
            }

            else
            {
                ViewBag.info = "用户名密码错误";
                return View("Login");
            }
            return View("Index", obj);
        }
        #endregion

        #region 退出
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            Session["CurrentAdmin"] = null;
            return View("Login");
        }
        #endregion

        #region 获取列表
        public ActionResult GetList(string info)
        {
            List<SysAdmin> List = new SysAdminBLL().GetList();
            ViewBag.info = info;
            ViewBag.list = List;
            return View("List");
        }
        #endregion

        #region 获取详细
        public ActionResult GetDetail(string id)
        {
            SysAdmin obj = new SysAdminBLL().GetObjById(id);
            ViewBag.id = id;
            return View("Detail", obj);
        }
        #endregion

        #region 添加
        public ActionResult GetAdd(SysAdmin obj)
        {
            obj = new SysAdmin
            {
                admin_name = obj.admin_name,
                admin_pwd = obj.admin_pwd
            };
            int result = new SysAdminBLL().Add(obj);
            string info = "已添加一条记录！";
            return RedirectToAction("GetList", "SysAdmin", new { info });
            //return this.Content("<script>window.location='" + Url.Action("GetList", "SysAdmin") + "'</script>");
        }
        #endregion
        
        #region 删除对像
        public ActionResult Del(string id)
        {
            int result = new SysAdminBLL().Del(id);
            string info = "已删除一条记录！";
            return RedirectToAction("GetList", "SysAdmin", new { info });
        }
        #endregion

        #region 编辑页面
        public ActionResult Edit(string id)
        {
            SysAdmin obj = new SysAdminBLL().GetObjById(id);
            ViewBag.id = id;
            return View("Edit",obj);
        }
        #endregion

        #region @编辑对像
        public ActionResult GetEdit(SysAdmin obj)
        {
            obj = new SysAdmin()
            {
                PK_Sys_Admin = obj.PK_Sys_Admin,
                admin_name = obj.admin_name,
                admin_pwd= obj.admin_pwd
            };
            int result = new SysAdminBLL().Edit(obj);
             string info = "已修改一条记录！";
             return RedirectToAction("GetList", "SysAdmin", new { info });

        }
        #endregion
 

    }
}