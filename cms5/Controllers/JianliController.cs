using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace cms5.Controllers
{
    public class JianliController : Controller
    {
        // GET: Jianli
        //jlName, jlPic, jlGender, jlage, jlIC, jlEdu, jlGw, jlPhone, jlEmail, jlXinzi, jlHunyin,
        //jlWork, jlPingJia, jlAddtime, userID, jl_peixun, jl_jiaoyu
        public ActionResult Index()
        {
            return View();
        }

        #region 详情

        public ActionResult Detail(string id)
        {
            Jianli obj = new JIanliBLL().GetObjByUId(id);
            return View(obj);
        }

        #endregion

        #region 添加

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

        #region 列表

        public ActionResult List()
        {
            List<Jianli> list = new JIanliBLL().getJlListByKword("");
            ViewBag.list = list;
            return View();
        }

        #endregion

        #region Excel导入数据库
        public ActionResult Excel()
        {
            return View();
        }
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
                if (!flag)
                {

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
            }
            return Content("成功添加" + result + "条记录！");
        }

        #endregion



    }
}