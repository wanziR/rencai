using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace cms5.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        #region 返回页面
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(string id)
        {
            int pvAdd = new ArticleBLL().PvAddById(id);  //文章浏览次数+1
            return View();
        }
        
        #endregion

        #region 列表
        public ActionResult List(string kWord)
        {

            //kWord = "留言沟通";
            ViewBag.kWord = kWord;
            List<Article> List = new ArticleBLL().GetListByKeyword(kWord);
            ViewBag.List = List;
            //根据关键词获取文章右侧导航子标题列表
            List<Article> navList = new ArticleBLL().GetNavListByKeyword(kWord);
            ViewBag.navList = navList;
            //根据关键词获取文章右侧导航父标题
            string pNav = new ArticleBLL().GetPNavListByKeyword(kWord);
            ViewBag.pNav = pNav;
            return View();
        }
        #endregion

        #region 管理列表
        [Authorize]
        public ActionResult aArticleList(string kWord,string info)
        {
            ViewBag.kWord = kWord;
            List<Article> List = new ArticleBLL().GetListByKeyword(kWord);
            ViewBag.List = List;
            List<Article> ACList = new ArticleBLL().GetACList();
            ViewBag.ACList = ACList;
            string acId = new ArticleBLL().getACId(kWord);
            ViewBag.acId = acId;
            ViewBag.info = info;
            return View();
        }
        #endregion

        #region 详细
        public ActionResult GetDetail(string id)
        {
            Article obj = new ArticleBLL().GetObjById(id);
            ViewBag.id = id;
            int pvAdd = new ArticleBLL().PvAddById(id);  //文章浏览次数+1
            return View("Detail", obj);
        }
        #endregion

        #region 删除
        public ActionResult Del(string id,string kWord)
        {
            int result = new ArticleBLL().Del(id);

            if (result == 1)
            {
                string info = "删除成功！";
                return RedirectToAction("aArticleList", "Article", new { info, kWord });
            }
            else
            {
                return this.Content("删除失败！");
            }
        }
        #endregion

        #region 添加
        [ValidateInput(false)]
        public ActionResult Add(string kWord)
        {
            ViewBag.kWord = kWord;
            List<Article> List = new ArticleBLL().GetACList();
            ViewBag.List = List;
            string acId = new ArticleBLL().getACId(kWord);
            ViewBag.acId = acId;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GetAdd(Article obj,string kWord)
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
            return RedirectToAction("aArticleList", "Article", new { info,kWord});
        }
        #endregion

        #region 编辑页面
        [ValidateInput(false)]
        public ActionResult Edit(string id)
        {
            Article obj = new ArticleBLL().GetObjById(id);
            return View("Edit", obj);
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
                aAddtime =obj.aAddtime
            };
            int result = new ArticleBLL().Edit(obj);
            string info = "已修改一条记录！";
            return RedirectToAction("aArticleList", "Article", new { info });
        }
        #endregion





    }
}