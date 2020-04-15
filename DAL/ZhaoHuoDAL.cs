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
   public class ZhaoHuoDAL
    {
        #region 发布找活信息
        public int Add(ZhaoHuo obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Zh_Info (zhTitle, zhUser, zhPhone, zhArea, zhGz, zhDetail, zhAddtime, zhNum) ");
            sqlBuilder.Append("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')");
            string sql = string.Format(sqlBuilder.ToString(), obj.zhTitle,obj.zhUser, obj.zhPhone, obj.zhArea, obj.zhGz, obj.zhDetail, DateTime.Now,obj.zhNum);
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

        #region 通过搜索关键字获取招工信息列表
        public List<ZhaoHuo> GetZhListByWord(string strWord)
        {
            string sql = "select * from Zh_Info where ";
            sql += "zhTitle like '%" + strWord + "%' ";
            sql += "or zhArea like '%" + strWord + "%' ";
            sql += "or zhUser like '%" + strWord + "%' ";
            sql += "or zhGz like '%" + strWord + "%' ";
            sql += "or zhDetail like '%" + strWord + "%' ";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoHuo> list = new List<ZhaoHuo>();
            while (dr.Read())
            {
                list.Add(new ZhaoHuo
                {
                    zhId = Convert.ToInt32(dr["zhId"]),
                    zhTitle = dr["zhTitle"].ToString(),
                    zhUser = dr["zhUser"].ToString(),
                    zhPhone = dr["zhPhone"].ToString(),
                    zhArea = dr["zhArea"].ToString(),
                    zhGz = dr["zhGz"].ToString(),
                    zhDetail = dr["zhDetail"].ToString(),
                    zhAddtime = Convert.ToDateTime(dr["zhAddtime"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 获取找活信息列表
        public List<ZhaoHuo> GetZgList()
        {
            string sql = "select * from Zh_Info order by zhAddtime desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoHuo> list = new List<ZhaoHuo>();
            while (dr.Read())
            {
                list.Add(new ZhaoHuo
                {
                    zhId = Convert.ToInt32(dr["zhId"]),
                    zhTitle = dr["zhTitle"].ToString(),
                    zhUser = dr["zhUser"].ToString(),
                    zhPhone = dr["zhPhone"].ToString(),
                    zhArea = dr["zhArea"].ToString(),
                    zhGz = dr["zhGz"].ToString(),
                    zhDetail = dr["zhDetail"].ToString(),
                    zhAddtime = Convert.ToDateTime(dr["zhAddtime"]),
                    zhNum = Convert.ToInt32(dr["zhNum"]),

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 获取找活城市列表
        public List<ZhaoHuo> GetZhCityList()
        {
            string sql = "select distinct zhArea from Zh_Info";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoHuo> list = new List<ZhaoHuo>();
            while (dr.Read())
            {
                list.Add(new ZhaoHuo
                {
                    zhArea = dr["zhArea"].ToString(),

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 通过ID获取找活信息详细
        public ZhaoHuo GetObjById(string id)
        {
            string sql = "select * from Zh_Info where zhId ='{0}'";
            sql = string.Format(sql, id);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            ZhaoHuo obj = null;
            if (dr.Read())
            {
                obj = new ZhaoHuo
                {
                    zhId = Convert.ToInt32(dr["zhId"]),
                    zhTitle = dr["zhTitle"].ToString(),
                    zhUser = dr["zhUser"].ToString(),
                    zhPhone = dr["zhPhone"].ToString(),
                    zhArea = dr["zhArea"].ToString(),
                    zhGz = dr["zhGz"].ToString(),
                    zhDetail = dr["zhDetail"].ToString(),
                    zhAddtime = Convert.ToDateTime(dr["zhAddtime"]),
                    zhNum = Convert.ToInt32(dr["zhNum"]),
                };
            }

            return obj;
        }
        #endregion
    }
}
