using System;
using System.Collections.Generic;
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


    }
}