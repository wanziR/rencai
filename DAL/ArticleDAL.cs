using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
   public class ArticleDAL
    {
        //aId, aName, aContent, acId, aAuthor, aPV, aAddtime, isTuiJian, isReMen, isZhiDing
        #region 获取文章列表
        public List<Article> GetList()
        {
            string sql = "select *,(select acName from Art_Column where acId=Article.acId) as acName from Article order by aAddtime desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    aId = Convert.ToInt32(dr["aId"]),
                    aName = dr["aName"].ToString(),
                    acName = dr["acName"].ToString(),
                    aContent = dr["aContent"].ToString(),
                    acId = Convert.ToInt32(dr["acId"]),
                    aAuthor = dr["aAuthor"].ToString(),
                    aPV = Convert.ToInt32(dr["aPV"]),
                    isTuiJian = Convert.ToInt32(dr["isTuiJian"]),
                    isReMen = Convert.ToInt32(dr["isReMen"]),
                    isZhiDing = Convert.ToInt32(dr["isZhiDing"]),
                    aType = dr["acName"].ToString(),
                    aLink = dr["acName"].ToString(),
                    aAddtime = Convert.ToDateTime(dr["aAddtime"])
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 根据栏目ID获取文章列表
        public List<Article> GetListByAcidIndex(int acId)
        {
            string sql = "select top 6 *,(select acName from Art_Column where acId=Article.acId) as acName from Article where acId =" + acId + " order by aAddtime desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    aId = Convert.ToInt32(dr["aId"]),
                    aName = dr["aName"].ToString(),
                    acName = dr["acName"].ToString(),
                    aContent = dr["aContent"].ToString(),
                    acId = Convert.ToInt32(dr["acId"]),
                    aAuthor = dr["aAuthor"].ToString(),
                    aPV = Convert.ToInt32(dr["aPV"]),
                    isTuiJian = Convert.ToInt32(dr["isTuiJian"]),
                    isReMen = Convert.ToInt32(dr["isReMen"]),
                    isZhiDing = Convert.ToInt32(dr["isZhiDing"]),
                    aType = dr["acName"].ToString(),
                    aLink = dr["acName"].ToString(),
                    aAddtime = Convert.ToDateTime(dr["aAddtime"])
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 根据栏目ID获取文章列表
        public List<Article> GetListByAcid(int acId)
        {
            string sql = "select *,(select acName from Art_Column where acId=Article.acId) as acName from Article where acId ="+acId+" order by aAddtime desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    aId = Convert.ToInt32(dr["aId"]),
                    aName = dr["aName"].ToString(),
                    acName = dr["acName"].ToString(),
                    aContent = dr["aContent"].ToString(),
                    acId = Convert.ToInt32(dr["acId"]),
                    aAuthor = dr["aAuthor"].ToString(),
                    aPV = Convert.ToInt32(dr["aPV"]),
                    isTuiJian = Convert.ToInt32(dr["isTuiJian"]),
                    isReMen = Convert.ToInt32(dr["isReMen"]),
                    isZhiDing = Convert.ToInt32(dr["isZhiDing"]),
                    aType = dr["acName"].ToString(),
                    aLink = dr["acName"].ToString(),
                    aAddtime = Convert.ToDateTime(dr["aAddtime"])
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 根据关键词获取文章列表
        public List<Article> GetListByKeyword(string kWord)
        {
            string sql = "select *,(select acName from Art_Column where acId=Article.acId) as acName from Article ";
            sql += "where (select acName from Art_Column where acId=Article.acId) like '%"+ kWord + "%' ";
            sql += "or aName  like '%" + kWord + "%' ";
            sql += "or aAuthor  like '%" + kWord + "%' ";
            sql += "order by aAddtime desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    aId = Convert.ToInt32(dr["aId"]),
                    aName = dr["aName"].ToString(),
                    acName = dr["acName"].ToString(),
                    aContent = dr["aContent"].ToString(),
                    acId = Convert.ToInt32(dr["acId"]),
                    aAuthor = dr["aAuthor"].ToString(),
                    aPV = Convert.ToInt32(dr["aPV"]),
                    isTuiJian = Convert.ToInt32(dr["isTuiJian"]),
                    isReMen = Convert.ToInt32(dr["isReMen"]),
                    isZhiDing = Convert.ToInt32(dr["isZhiDing"]),
                    aType = dr["acName"].ToString(),
                    aLink = dr["acName"].ToString(),
                    aAddtime = Convert.ToDateTime(dr["aAddtime"])
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 根据关键词获取文章右侧导航子标题列表
        public List<Article> GetNavListByKeyword(string nWord)
        {
            string sql = "select acName from Art_Column where acPid =(select top 1 acPid from Art_Column where acId =(select acId from Art_Column where acName ='{0}'))";
            sql = string.Format(sql, nWord);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    acName = dr["acName"].ToString(),
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 根据关键词获取文章右侧导航父标题
        public string GetPNavListByKeyword(string nWord)
        {
            string sql = "select acName from Art_Column where acId = (select top 1 acPid from Art_Column where acId =(select acId from Art_Column where acName ='{0}'))";
            sql = string.Format(sql, nWord);
            string pNav = SQLHelper.SingleResultStr(sql);
            return pNav;
        }
        #endregion

        #region 文章详情
        public Article GetObjById(string id)
        {
            string sql = "select *,(select acName from Art_Column where acId=Article.acId) as acName from Article where aId ='{0}'";
            sql = string.Format(sql, id);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            Article obj = null;
            if (dr.Read())
            {
                obj = new Article
                {
                    aId = Convert.ToInt32(dr["aId"]),
                    aName = dr["aName"].ToString(),
                    acName = dr["acName"].ToString(),
                    aContent = dr["aContent"].ToString(),
                    acId = Convert.ToInt32(dr["acId"]),
                    aAuthor = dr["aAuthor"].ToString(),
                    aPV = Convert.ToInt32(dr["aPV"]),
                    isTuiJian = Convert.ToInt32(dr["isTuiJian"]),
                    isReMen = Convert.ToInt32(dr["isReMen"]),
                    isZhiDing = Convert.ToInt32(dr["isZhiDing"]),
                    aType = dr["acName"].ToString(),
                    aLink = dr["acName"].ToString(),
                    aAddtime = Convert.ToDateTime(dr["aAddtime"])
                };
            }

            return obj;
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
            string sql = "delete from Article where aId = " + id + "";
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该号被其他实体引用，不能直接删除该学员对象！");
                else
                    throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 添加
        public int Add(Article obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Article(aName, aContent, acId, aAuthor,aAddtime) ");
            sqlBuilder.Append("values('{0}','{1}','{2}','{3}','{4}')");
            string sql = string.Format(sqlBuilder.ToString(), obj.aName, obj.aContent, obj.acId, obj.aAuthor,DateTime.Now);
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
        }
        #endregion

        #region 编辑对像 
        public int Edit(Article obj)
        {
            //aName, aContent, acId, aAuthor,aAddtime
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Article set aName='{0}',aContent='{1}',aAuthor='{2}'");
            sqlBuilder.Append(" where aId = {3}");
            string sql = string.Format(sqlBuilder.ToString(), obj.aName, obj.aContent, obj.aAuthor,obj.aId);
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
        }
        #endregion

        #region 获取文章子标题列表
        public List<Article> GetACList()
        {
            string sql = "select * from Art_Column where acPid != 0";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Article> list = new List<Article>();
            while (dr.Read())
            {
                list.Add(new Article
                {
                    acName = dr["acName"].ToString(),
                    acId = Convert.ToInt32(dr["acId"])
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 根据栏目名称获取栏目id
        public string getACId(string acName)
        {
            string sql = "select acId from Art_Column where acName = '"+acName+"'";
            try
            {
                return SQLHelper.SingleResultStr(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该号被其他实体引用，不能直接删除该学员对象！");
                else
                    throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 根据文章ID浏览次数加1
        public int PvAddById(string id)
        {
            string sql = "update Article set aPV += 1 where aId = " + id + "";
            try
            {
                return SQLHelper.Update(sql);
            }
           
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 根据单页ID获取详情
        public Article GetObjByAsId(int id)
        {
            string sql = "select * from  Art_Single where asId ='{0}'";
            sql = string.Format(sql, id);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            Article obj = null;
            if (dr.Read())
            {
                obj = new Article
                {
                    asId = Convert.ToInt32(dr["asId"]),
                    asName = dr["asName"].ToString(),
                    asImg = dr["asImg"].ToString(),
                    asContent = dr["asContent"].ToString(),
                    asOrder = Convert.ToInt32(dr["asOrder"]),
                    asAddTime = Convert.ToDateTime(dr["asAddTime"])
                };
            }

            return obj;
        }
        #endregion

        #region 编辑单页
        public int SEdit(Article obj)
        {
            //asName,asImg,asContent,asAddTime
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Art_Single set asName='{0}',asImg='{1}',asContent='{2}'");
            sqlBuilder.Append(" where asId = {3}");
            string sql = string.Format(sqlBuilder.ToString(), obj.asName, obj.asImg, obj.asContent, obj.asId);
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }
        }
        #endregion





    }
}
