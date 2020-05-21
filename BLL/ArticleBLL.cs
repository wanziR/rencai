using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Web;
namespace BLL
{
   public class ArticleBLL
    {
      

        #region 获取文章列表
        public List<Article> GetList()
        {
            return new ArticleDAL().GetList();
        }
        #endregion

        #region 根据栏目ID获取文章列表首页
        public List<Article> GetListByAcidIndex(int acId)
        {
            return new ArticleDAL().GetListByAcid(acId);
        }
        #endregion

        #region 根据栏目ID获取文章列表
        public List<Article> GetListByAcid(int acId)
        {
            return new ArticleDAL().GetListByAcid(acId);
        }
        #endregion

        #region 根据关键词获取文章列表
        public List<Article> GetListByKeyword(string kWord)
        {
            return new ArticleDAL().GetListByKeyword(kWord);
        }
        #endregion

        #region 文章详情
        public Article GetObjById(string id)
        {
            return new ArticleDAL().GetObjById(id);
        }
        #endregion

        #region 根据关键词获取文章右侧导航子标题列表
        public List<Article> GetNavListByKeyword(string nWord)
        {
            return new ArticleDAL().GetNavListByKeyword(nWord);
        }
        #endregion

        #region 根据关键词获取文章右侧导航父标题
        public string GetPNavListByKeyword(string nWord)
        {
            return new ArticleDAL().GetPNavListByKeyword(nWord);
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
            return new ArticleDAL().Del(id);
        }
        #endregion

        #region 添加
        public int Add(Article obj)
        {
            return new ArticleDAL().Add(obj);
        }
        #endregion

        #region 编辑对像 
        public int Edit(Article obj)
        {
            return new ArticleDAL().Edit(obj);
        }
        #endregion

        #region 获取文章子标题列表
        public List<Article> GetACList()
        {
            return new ArticleDAL().GetACList();
        }
        #endregion

        #region 根据栏目名称获取栏目id
        public string getACId(string acName)
        {
            return new ArticleDAL().getACId(acName);
        }
        #endregion

        #region 根据文章ID浏览次数加1
        public int PvAddById(string id)
        {
            return new ArticleDAL().PvAddById(id);
        }
        #endregion

        #region 根据单页ID获取详情
        public Article GetObjByAsId(int id)
        {
           return new ArticleDAL().GetObjByAsId(id);
        }
        #endregion

        #region 编辑单页
        public int SEdit(Article obj)
        {
            return new ArticleDAL().SEdit(obj);
        }
        #endregion


    }
}
