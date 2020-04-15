using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class LaowuDAL
    {
        #region 获取招工信息列表-首页
        public List<Laowu> GetLwListIndex()
        {
            string sql = "select top 6 * from Lw_Info order by lwAddtime asc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Laowu> list = new List<Laowu>();
            while (dr.Read())
            {
                // lwId, lwTitle, lwName, lwSex, lwage, lwPhone, lwArea, lwGz, lwDetail, lwAddtime, lwZhuangtai, isTuijian, isRemen
                list.Add(new Laowu
                {
                    lwId = Convert.ToInt32(dr["lwId"]),
                    lwTitle = dr["lwTitle"].ToString(),
                    lwName = dr["lwName"].ToString(),
                    lwSex = dr["lwSex"].ToString(),
                    lwage = dr["lwage"].ToString(),
                    lwPhone = dr["lwPhone"].ToString(),
                    lwArea = dr["lwArea"].ToString(),
                    lwGz = dr["lwGz"].ToString(),
                    lwDetail = dr["lwDetail"].ToString(),
                    lwAddtime = Convert.ToDateTime(dr["lwAddtime"]),
                    lwZhuangtai = Convert.ToInt32(dr["lwZhuangtai"]),
                    isTuijian = Convert.ToInt32(dr["isTuijian"]),
                    isRemen = Convert.ToInt32(dr["isRemen"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 获取个人劳务列表
        public List<Laowu> GetLwList()
        {
            string sql = "select  * from Lw_Info order by lwAddtime asc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Laowu> list = new List<Laowu>();
            while (dr.Read())
            {
                // lwId, lwTitle, lwName, lwSex, lwage, lwPhone, lwArea, lwGz, lwDetail, lwAddtime, lwZhuangtai, isTuijian, isRemen
                list.Add(new Laowu
                {
                    lwId = Convert.ToInt32(dr["lwId"]),
                    lwTitle = dr["lwTitle"].ToString(),
                    lwName = dr["lwName"].ToString(),
                    lwSex = dr["lwSex"].ToString(),
                    lwage = dr["lwage"].ToString(),
                    lwPhone = dr["lwPhone"].ToString(),
                    lwArea = dr["lwArea"].ToString(),
                    lwGz = dr["lwGz"].ToString(),
                    lwDetail = dr["lwDetail"].ToString(),
                    lwAddtime = Convert.ToDateTime(dr["lwAddtime"]),
                    lwZhuangtai = Convert.ToInt32(dr["lwZhuangtai"]),
                    isTuijian = Convert.ToInt32(dr["isTuijian"]),
                    isRemen = Convert.ToInt32(dr["isRemen"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 通过搜索关键字获取劳务信息列表
        public List<Laowu> GetZhListByWord(string strWord)
        {
            // lwId, lwTitle, lwName, lwSex, lwage, lwPhone, lwArea, lwGz, lwDetail, lwAddtime, lwZhuangtai, isTuijian, isRemen
            string sql = "select * from Lw_Info where ";
            sql += "lwTitle like '%" + strWord + "%' ";
            sql += "or lwArea like '%" + strWord + "%' ";
            sql += "or lwName like '%" + strWord + "%' ";
            sql += "or lwGz like '%" + strWord + "%' ";
            sql += "or lwDetail like '%" + strWord + "%' ";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Laowu> list = new List<Laowu>();
            while (dr.Read())
            {
                list.Add(new Laowu
                {
                    lwId = Convert.ToInt32(dr["lwId"]),
                    lwTitle = dr["lwTitle"].ToString(),
                    lwName = dr["lwName"].ToString(),
                    lwSex = dr["lwSex"].ToString(),
                    lwage = dr["lwage"].ToString(),
                    lwPhone = dr["lwPhone"].ToString(),
                    lwArea = dr["lwArea"].ToString(),
                    lwGz = dr["lwGz"].ToString(),
                    lwDetail = dr["lwDetail"].ToString(),
                    lwAddtime = Convert.ToDateTime(dr["lwAddtime"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 获取找活城市列表
        public List<Laowu> GetZhCityList()
        {
            string sql = "select distinct lwArea from lw_Info";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Laowu> list = new List<Laowu>();
            while (dr.Read())
            {
                list.Add(new Laowu
                {
                    lwArea = dr["lwArea"].ToString(),

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 通过ID获取找活信息详细
        public Laowu GetObjById(string id)
        {
            string sql = "select * from lw_Info where lwId ='{0}'";
            sql = string.Format(sql, id);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            Laowu obj = null;
            if (dr.Read())
            {
                obj = new Laowu
                {
                    lwId = Convert.ToInt32(dr["lwId"]),
                    lwTitle = dr["lwTitle"].ToString(),
                    lwName = dr["lwName"].ToString(),
                    lwSex = dr["lwSex"].ToString(),
                    lwage = dr["lwage"].ToString(),
                    lwPhone = dr["lwPhone"].ToString(),
                    lwArea = dr["lwArea"].ToString(),
                    lwGz = dr["lwGz"].ToString(),
                    lwDetail = dr["lwDetail"].ToString(),
                    lwAddtime = Convert.ToDateTime(dr["lwAddtime"]),
                    lwZhuangtai = Convert.ToInt32(dr["lwZhuangtai"]),
                    isTuijian = Convert.ToInt32(dr["isTuijian"]),
                    isRemen = Convert.ToInt32(dr["isRemen"])
                };
            }

            return obj;
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
            string sql = "delete from Lw_Info where lwId = " + id + "";
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

    }
}
