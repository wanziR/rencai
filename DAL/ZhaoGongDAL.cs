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
   public class ZhaoGongDAL
    {
        #region 发布招工信息
        public int Add(ZhaoGong obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Zg_Info (zgXuqiu, zgZhuTilei, zgZhuti, zgArea, zgGz, zgNum, zgDetail, zgUser, zgPhone, zgFaburen, zgAddtime,zgStarttime,zgEndtime) ");
            sqlBuilder.Append("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')");
            string sql = string.Format(sqlBuilder.ToString(), obj.zgXuqiu, obj.zgZhuTilei, obj.zgZhuti, obj.zgArea, obj.zgGz, obj.zgNum, obj.zgDetail, obj.zgUser, obj.zgPhone, obj.zgFaburen, DateTime.Now,obj.zgStarttime, obj.zgEndtime);
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

        #region 获取招工信息列表-首页
        public List<ZhaoGong> GetZgListIndex()
        {
            string sql = "select top 6 * from Zg_Info order by zgAddtime";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoGong> list = new List<ZhaoGong>();
            while (dr.Read())
            {
                // zgId, zgTitle, zgUser, zgPhone, zgArea, zgGz, zgDetail, zgAddtime, zgImg1, zgImg2, zgImg3
                list.Add(new ZhaoGong
                {
                    zgId = Convert.ToInt32(dr["zgId"]),
                    zgTitle = dr["zgTitle"].ToString(),
                    zgXuqiu = dr["zgXuqiu"].ToString(),
                    zgZhuTilei = dr["zgZhuTilei"].ToString(),
                    zgZhuti = dr["zgZhuti"].ToString(),
                    zgNum = Convert.ToInt32(dr["zgNum"]),
                    zgUser = dr["zgUser"].ToString(),
                    zgPhone = dr["zgPhone"].ToString(),
                    zgArea = dr["zgArea"].ToString(),
                    zgGz = dr["zgGz"].ToString(),
                    zgDetail = dr["zgDetail"].ToString(),
                    zgFaburen = dr["zgFaburen"].ToString(),
                    zgAddtime = Convert.ToDateTime(dr["zgAddtime"]),
                    zgStarttime = Convert.ToDateTime(dr["zgStarttime"]),
                    zgEndtime = Convert.ToDateTime(dr["zgEndtime"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 获取个人求职列表-首页
        public List<ZhaoGong> GetLwListIndex()
        {
            string sql = "select top 6 * from Zg_Info order by zgAddtime asc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoGong> list = new List<ZhaoGong>();
            while (dr.Read())
            {
                // zgId, zgTitle, zgUser, zgPhone, zgArea, zgGz, zgDetail, zgAddtime, zgImg1, zgImg2, zgImg3
                list.Add(new ZhaoGong
                {
                    zgId = Convert.ToInt32(dr["zgId"]),
                    zgTitle = dr["zgTitle"].ToString(),
                    zgXuqiu = dr["zgXuqiu"].ToString(),
                    zgZhuTilei = dr["zgZhuTilei"].ToString(),
                    zgZhuti = dr["zgZhuti"].ToString(),
                    zgNum = Convert.ToInt32(dr["zgNum"]),
                    zgUser = dr["zgUser"].ToString(),
                    zgPhone = dr["zgPhone"].ToString(),
                    zgArea = dr["zgArea"].ToString(),
                    zgGz = dr["zgGz"].ToString(),
                    zgDetail = dr["zgDetail"].ToString(),
                    zgFaburen = dr["zgFaburen"].ToString(),
                    zgAddtime = Convert.ToDateTime(dr["zgAddtime"]),
                    zgStarttime = Convert.ToDateTime(dr["zgStarttime"]),
                    zgEndtime = Convert.ToDateTime(dr["zgEndtime"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 获取招工信息列表
        public List<ZhaoGong> GetZgList()
        {
            string sql = "select * from Zg_Info order by zgAddtime asc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoGong> list = new List<ZhaoGong>();
            while (dr.Read())
            {
                //zgId, zgTitle, zgXuqiu, zgZhuTilei, zgZhuti, zgArea, zgGz, zgNum, zgDetail, zgUser, zgPhone, zgFaburen,
                //zgStarttime, zgEndtime, zgAddtime, zgImg1, zgImg2, zgImg3
                list.Add(new ZhaoGong
                {
                   zgId = Convert.ToInt32(dr["zgId"]),
                    zgTitle = dr["zgTitle"].ToString(),
                    zgXuqiu = dr["zgXuqiu"].ToString(),
                    zgZhuTilei = dr["zgZhuTilei"].ToString(),
                    zgZhuti = dr["zgZhuti"].ToString(),
                    zgNum = Convert.ToInt32(dr["zgNum"]),
                    zgUser = dr["zgUser"].ToString(),
                    zgPhone = dr["zgPhone"].ToString(),
                    zgArea = dr["zgArea"].ToString(),
                    zgGz = dr["zgGz"].ToString(),
                    zgDetail = dr["zgDetail"].ToString(),
                    zgFaburen = dr["zgFaburen"].ToString(),
                    zgAddtime = Convert.ToDateTime(dr["zgAddtime"]),
                    zgStarttime = Convert.ToDateTime(dr["zgStarttime"]),
                    zgEndtime = Convert.ToDateTime(dr["zgEndtime"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 获取招工城市列表
        public List<ZhaoGong> GetZgCityList()
        {
            string sql = "select distinct zgArea from Zg_Info";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoGong> list = new List<ZhaoGong>();
            while (dr.Read())
            {
                // zgId, zgTitle, zgUser, zgPhone, zgArea, zgGz, zgDetail, zgAddtime, zgImg1, zgImg2, zgImg3
                list.Add(new ZhaoGong
                {
                    zgArea = dr["zgArea"].ToString(),

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 通过搜索关键字获取招工信息列表
        public List<ZhaoGong> GetZgListByWord(string strWord)
        {
            string sql = "select * from Zg_Info where ";
            sql += "zgXuqiu like '%" + strWord + "%' ";
            sql += "or zgTitle like '%"+ strWord + "%' ";
            sql += "or zgPhone like '%" + strWord + "%' ";
            sql += "or zgArea like '%" + strWord + "%' ";
            sql += "or zgUser like '%" + strWord + "%' ";
            sql += "or zgGz like '%" + strWord + "%' ";
            sql += "or zgDetail like '%" + strWord + "%' ";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoGong> list = new List<ZhaoGong>();
            while (dr.Read())
            {
                // zgId, zgTitle, zgUser, zgPhone, zgArea, zgGz, zgDetail, zgAddtime, zgImg1, zgImg2, zgImg3
                list.Add(new ZhaoGong
                {
                    zgId = Convert.ToInt32(dr["zgId"]),
                    zgTitle = dr["zgTitle"].ToString(),
                    zgXuqiu = dr["zgXuqiu"].ToString(),
                    zgZhuTilei = dr["zgZhuTilei"].ToString(),
                    zgZhuti = dr["zgZhuti"].ToString(),
                    zgNum = Convert.ToInt32(dr["zgNum"]),
                    zgUser = dr["zgUser"].ToString(),
                    zgPhone = dr["zgPhone"].ToString(),
                    zgArea = dr["zgArea"].ToString(),
                    zgGz = dr["zgGz"].ToString(),
                    zgDetail = dr["zgDetail"].ToString(),
                    zgFaburen = dr["zgFaburen"].ToString(),
                    zgAddtime = Convert.ToDateTime(dr["zgAddtime"]),
                    zgStarttime = Convert.ToDateTime(dr["zgStarttime"]),
                    zgEndtime = Convert.ToDateTime(dr["zgEndtime"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 通过ID获取招工信息详细
        public ZhaoGong GetObjById(string id)
        {
            string sql = "select * from Zg_Info where zgId ='{0}'";
            sql = string.Format(sql, id);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            ZhaoGong obj = null;
            if (dr.Read())
            {
                obj = new ZhaoGong
                {
                    zgId = Convert.ToInt32(dr["zgId"]),
                    zgTitle = dr["zgTitle"].ToString(),
                    zgXuqiu = dr["zgXuqiu"].ToString(),
                    zgZhuTilei = dr["zgZhuTilei"].ToString(),
                    zgZhuti = dr["zgZhuti"].ToString(),
                    zgNum = Convert.ToInt32(dr["zgNum"]),
                    zgUser = dr["zgUser"].ToString(),
                    zgPhone = dr["zgPhone"].ToString(),
                    zgArea = dr["zgArea"].ToString(),
                    zgGz = dr["zgGz"].ToString(),
                    zgDetail = dr["zgDetail"].ToString(),
                    zgFaburen = dr["zgFaburen"].ToString(),
                    zgAddtime = Convert.ToDateTime(dr["zgAddtime"]),
                    zgStarttime = Convert.ToDateTime(dr["zgStarttime"]),
                    zgEndtime = Convert.ToDateTime(dr["zgEndtime"])
                };
            }

            return obj;
        }
        #endregion

        #region 通过PId获取工种列表
        public List<ZhaoGong> GetGzList(int PId)
        {
            string sql = "select * from Gz_Info where gzPid = "+ PId;
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoGong> list = new List<ZhaoGong>();
            while (dr.Read())
            {
                // zgId, zgTitle, zgUser, zgPhone, zgArea, zgGz, zgDetail, zgAddtime, zgImg1, zgImg2, zgImg3
                list.Add(new ZhaoGong
                {
                    gzID = Convert.ToInt32(dr["gzID"]),
                    gzName = dr["gzName"].ToString(),
                    gzPid = Convert.ToInt32(dr["gzPid"]),

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 通过id删除对像
        public int Del(string id)
        {
            string sql = "delete from Zg_Info where zgId = " + id + "";
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
