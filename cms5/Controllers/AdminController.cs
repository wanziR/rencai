using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data; // Excel导入
using Models;
using BLL;
using System.Web.Security;
using System.IO;
using System.Web.Script.Serialization;

using X.PagedList;
using X.PagedList.Mvc;


namespace cms5.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult Index(string kWord, string info)
        {
            return View();
        }
        #region 返回页面
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult _Form()
        {
            return View();
        }

        public ActionResult _List()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }
        #endregion

        #region 登录判断

        public ActionResult AdminLogin(UserInfo obj)
        {
            obj = new UserInfo
            {
                userName = obj.userName,
                userPwd = obj.userPwd
            };
            obj = new AdminBLL().Login(obj);
            if (obj != null)
            {
                string userName = obj.userName;
                FormsAuthentication.SetAuthCookie(userName, true);
                return RedirectToAction("Jllist");
            }
            else
            {

                ViewBag.info = "用户名或密码错误！";
                return View("login");

            }
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

        #region 简历详情

        public ActionResult getDetail(string id)
        {
            Jianli obj = new JIanliBLL().GetObjByUId(id);
            return RedirectToAction("Detail", "Jianli", obj);
        }

        #endregion

        #region 简历添加

        public ActionResult Add()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult getAdd(Jianli obj)
        {
            obj = new Jianli
            {
                jlId = obj.jlId,
                jlName = obj.jlName,
                jlPic = obj.jlPic,
                jlGender = obj.jlGender,
                jlage = obj.jlage,
                jlIC = obj.jlIC,
                jlEdu = obj.jlEdu,
                jlGw = obj.jlGw,
                jlPhone = obj.jlPhone,
                jlEmail = obj.jlEmail,
                jlXinzi = obj.jlXinzi,
                jlHunyin = obj.jlHunyin,
                jlWork = obj.jlWork,
                jlPingJia = obj.jlPingJia,
                userID = obj.userID,
                jl_peixun = obj.jl_peixun,
                jl_jiaoyu = obj.jl_jiaoyu

            };
            int result = new JIanliBLL().Add(obj);
            return Content("添加成功！");
        }

        #endregion

        #region 简历列表

        public ActionResult JlList(string kword, string info, int page = 1)
        {
            List<Jianli> list = new JIanliBLL().getJlListByKword(kword);
            var pList = list.ToPagedList(page, 10);
            ViewBag.list = pList;
            ViewBag.info = info;
            return View(pList);

        }

        #endregion

        #region 招聘管理列表
        [Authorize]
        public ActionResult ZpList(int page = 1)
        {
            List<ZhaoPin> List = new ZhaoPinBLL().GetList();
            var pList = List.ToPagedList(page, 10);
            ViewBag.list = pList;
            return View(pList);
        }
        #endregion

        #region 招聘信息发布页面
        [Authorize]
        public ActionResult ZpFabu()
        {
         
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
                string warningText = "薪资待遇不能为空！";
                return this.Content("<script>$(function(){warning('" + warningText + "');})</script>");
            }
            if (obj.zpUser == null)
            {
                string warningText = "联系人不能为空！";
                return this.Content("<script>$(function(){warning('" + warningText + "');})</script>");
            }
            else
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

        #region 文章管理列表
        [Authorize]
        public ActionResult ArticleList(string kWord, string info,int page =1)
        {
            ViewBag.kWord = kWord;
            //kWord = "消息法规";
            ViewBag.kWord = kWord;
            List<Article> List = new ArticleBLL().GetListByKeyword(kWord);
            var pList = List.ToPagedList(page, 10);
            ViewBag.List = pList;

            List<Article> ACList = new ArticleBLL().GetACList();
            ViewBag.ACList = ACList;
            string acId = new ArticleBLL().getACId(kWord);
            ViewBag.acId = acId;
            ViewBag.info = info;
            return View(pList);
        }
        #endregion

        #region 文章添加
        [Authorize]
        [ValidateInput(false)]
        public ActionResult ArticleAdd(string kWord)
        {

          ViewBag.kWord = kWord;

            List<Article> List = new ArticleBLL().GetACList();
            ViewBag.List = List;
            string acId = new ArticleBLL().getACId(kWord);
            ViewBag.acId = acId;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GetAdd(Article obj, string kWord)
        {//aName, aContent, acId, aAuthor, aPV, aAddtime
            obj = new Article
            {
                aName = obj.aName,
                aContent = obj.aContent,
                acId = obj.acId,
                aAuthor = obj.aAuthor,
                aAddtime = obj.aAddtime
            };
            int result = new ArticleBLL().Add(obj);
            string info = "添加成功！";
            return RedirectToAction("aArticleList", "Article", new { info, kWord });
        }
        #endregion

        #region 文章编辑页面
        [Authorize]
        [ValidateInput(false)]
        public ActionResult ArticleEdit(string id)
        {
            Article obj = new ArticleBLL().GetObjById(id);
            return View(obj);
        }
        [ValidateInput(false)]
        public ActionResult GetEdit(Article obj)
        {
            obj = new Article()
            {
                aName = obj.aName,
                aContent = obj.aContent,
                acId = obj.acId,
                aId = obj.aId,
                aAuthor = obj.aAuthor,
                aAddtime = obj.aAddtime
            };
            int result = new ArticleBLL().Edit(obj);
            string info = "已修改一条记录！";
            return RedirectToAction("ArticleList", "Admin", new { info });
        }
        #endregion

        #region 文章删除

        public ActionResult ArticleDel(string id, string kWord)
        {
            int result = new ArticleBLL().Del(id);

            if (result == 1)
            {
                string info = "删除成功！";
                return RedirectToAction("ArticleList", "Admin", new { info, kWord });
            }
            else
            {
                return this.Content("删除失败！");
            }
        }
        #endregion

        #region 劳务信息列表
        [Authorize]
        public ActionResult LwList(int page = 1)
        {
            List<Laowu> list = new LaowuBLL().GetLwList();
            var plist = list.ToPagedList(page, 10);
            ViewBag.list = plist;
            return View(plist);
        }
        #endregion

        #region  人才库Excle导入到数据库

        /// <summary>
        /// Excle导入到数据库
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Import()
        {

            HttpPostedFileBase file = Request.Files["excel"];
            var path = Path.Combine(Request.MapPath("/Upload"), file.FileName);
            file.SaveAs(path);
            //从NPOI读取到的Excel的数据
            DataTable excelTable = new DataTable();
            excelTable = ImportExcel.GetExcelDataTable(path);
            ImportExcel.RemoveEmpty(excelTable);
            int result = 0;
            foreach (DataRow dataRow in excelTable.Rows)
            {
                Jianli obj = new Jianli();
                int userID = Convert.ToInt32(dataRow["用户编号"]);
                bool flag = new JIanliBLL().FindByUId(userID);
                //判断该用户是否存在，若不存在则添加
                if (flag)
                {
                    int ret = new JIanliBLL().ExDel(userID);
                }
                obj = new Jianli
                    {
                        userID = Convert.ToInt32(dataRow["用户编号"]),
                        jlName = dataRow["姓名"].ToString(),
                        jlPic = dataRow["头像"].ToString(),
                        jlGender = dataRow["性别"].ToString(),
                        jlage = dataRow["出生年月"].ToString(),
                        jlIC = dataRow["身份证号"].ToString(),
                        jlEdu = dataRow["学历"].ToString(),
                        jlGw = dataRow["求职岗位"].ToString(),
                        jlPhone = dataRow["联系方式"].ToString(),
                        jlEmail = dataRow["电子邮件"].ToString(),
                        jlXinzi = Convert.ToInt32(dataRow["期望薪资"]),
                        jlHunyin = dataRow["婚姻情况"].ToString(),
                        jlWork = Convert.ToInt32(dataRow["工作年限"]),
                        jlPingJia = dataRow["工作经历"].ToString(),
                        jl_peixun = dataRow["培训经历"].ToString(),
                        jl_jiaoyu = dataRow["教育经历"].ToString()

                    };
                result += new JIanliBLL().Add(obj);
              
            }
            return
           RedirectToAction("JlList", "Admin",new {info="导入成功"});
        }

        #endregion

        #region 用户列表
        public ActionResult UList(string info,int page =1)
        {
            List<UserInfo> List = new UserInfoBLL().GetList();
            var plist = List.ToPagedList(page, 10);
            ViewBag.list = plist;
            ViewBag.info = info;
            return View(plist);
        }
        #endregion

        #region 删除
        public ActionResult UDel(string id)
        {
            int result = new UserInfoBLL().Del(id);

            if (result == 1)
            {
                string info = "删除成功！";
                return RedirectToAction("UList", "Admin", new { info });

            }
            else
            {
                return this.Content("删除失败！");
            }
        }
        #endregion

        #region 设为管理员
        public ActionResult isGly(string id)
        {
            int result = new UserInfoBLL().isGly(id);

            if (result == 1)
            {
                string info = "设置成功！";
                return RedirectToAction("UList", "Admin", new { info });
            }
            else
            {
                return this.Content("设置失败！");
            }
        }
        #endregion

        #region 取消管理员
        public ActionResult isNoGly(string id)
        {
            int result = new UserInfoBLL().isNoGly(id);

            if (result == 1)
            {
                string info = "设置成功！";
                return RedirectToAction("UList", "Admin", new { info });
            }
            else
            {
                return this.Content("设置！");
            }
        }
        #endregion

        #region 单页编辑
        [Authorize]
        [ValidateInput(false)]
        public ActionResult ArticleSEdit(int id,string info)
        {
            Article obj = new ArticleBLL().GetObjByAsId(id);
            ViewBag.info = info;
            return View(obj);
        }
        [ValidateInput(false)]
        public ActionResult GetSEdit(Article obj)
        {
            obj = new Article()
            {
                asId = obj.asId,
                asName = obj.asName,
                asImg = obj.asImg,
                asContent = obj.asContent,
                asOrder = obj.asOrder
            };
            int result = new ArticleBLL().SEdit(obj);
            return RedirectToAction("ArticleSEdit", new { id= obj.asId ,info="编辑成功！"});

        }
        #endregion

     











    }
}