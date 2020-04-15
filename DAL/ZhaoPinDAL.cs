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
   public class ZhaoPinDAL
    {
        //zpId, zpXuqiu, zpZhuTilei, zpZhuti, zpArea, zpGangwei, zpNum, zpPayL, zpPayH, zpFuli, 
        //zpDetail, zpUser, zpPhone, zpFaburen, zpAddtime, zpEndtime, isTuijian, isRemen
        #region 获取招聘信息列表
        public List<ZhaoPin> GetList()
        {
            string sql = "select * from Zp_Info order by zpAddtime desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoPin> list = new List<ZhaoPin>();
            while (dr.Read())
            {
                list.Add(new ZhaoPin
                {
                    zpId = Convert.ToInt32(dr["zpId"]),
                    zpXuqiu = dr["zpXuqiu"].ToString(),
                    zpZhuTilei = dr["zpZhuTilei"].ToString(),
                    zpZhuti = dr["zpZhuti"].ToString(),
                    zpArea = dr["zpArea"].ToString(),
                    zpGangwei = dr["zpGangwei"].ToString(),
                    zpNum = Convert.ToInt32(dr["zpNum"]),
                    zpPayL = dr["zpPayL"].ToString(),
                    zpPayH = dr["zpPayH"].ToString(),
                    zpFuli = dr["zpFuli"].ToString(),
                    zpDetail = dr["zpDetail"].ToString(),
                    zpUser = dr["zpUser"].ToString(),
                    zpPhone = dr["zpPhone"].ToString(),
                    zpFaburen = dr["zpFaburen"].ToString(),
                    zpEndtime = Convert.ToDateTime(dr["zpEndtime"]),
                    zpAddtime = Convert.ToDateTime(dr["zpAddtime"]),
                    isTuijian = Convert.ToInt32(dr["isTuijian"]),
                    isRemen = Convert.ToInt32(dr["isRemen"])
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 获取招聘信息首页列表
        public List<ZhaoPin> GetListIndex()
        {
            string sql = "select top 6 * from Zp_Info order by zpAddtime desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoPin> list = new List<ZhaoPin>();
            while (dr.Read())
            {
                list.Add(new ZhaoPin
                {
                    zpId = Convert.ToInt32(dr["zpId"]),
                    zpXuqiu = dr["zpXuqiu"].ToString(),
                    zpZhuTilei = dr["zpZhuTilei"].ToString(),
                    zpZhuti = dr["zpZhuti"].ToString(),
                    zpArea = dr["zpArea"].ToString(),
                    zpGangwei = dr["zpGangwei"].ToString(),
                    zpNum = Convert.ToInt32(dr["zpNum"]),
                    zpPayL = dr["zpPayL"].ToString(),
                    zpPayH = dr["zpPayH"].ToString(),
                    zpFuli = dr["zpFuli"].ToString(),
                    zpDetail = dr["zpDetail"].ToString(),
                    zpUser = dr["zpUser"].ToString(),
                    zpPhone = dr["zpPhone"].ToString(),
                    zpFaburen = dr["zpFaburen"].ToString(),
                    zpEndtime = Convert.ToDateTime(dr["zpEndtime"]),
                    zpAddtime = Convert.ToDateTime(dr["zpAddtime"]),
                    isTuijian = Convert.ToInt32(dr["isTuijian"]),
                    isRemen = Convert.ToInt32(dr["isRemen"])
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 通过搜索关键字获取招聘信息列表
        public List<ZhaoPin> GetListByWord(string strWord)
        {
            string sql = "select * from Zp_Info where ";
            sql += "zpXuqiu like '%" + strWord + "%' ";
            sql += "or zpZhuti like '%" + strWord + "%' ";
            sql += "or zpPhone like '%" + strWord + "%' ";
            sql += "or zpArea like '%" + strWord + "%' ";
            sql += "or zpUser like '%" + strWord + "%' ";
            sql += "or zpGangwei like '%" + strWord + "%' order by zpAddtime desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<ZhaoPin> list = new List<ZhaoPin>();
            while (dr.Read())
            {
                list.Add(new ZhaoPin
                {
                    zpId = Convert.ToInt32(dr["zpId"]),
                    zpXuqiu = dr["zpXuqiu"].ToString(),
                    zpZhuTilei = dr["zpZhuTilei"].ToString(),
                    zpZhuti = dr["zpZhuti"].ToString(),
                    zpArea = dr["zpArea"].ToString(),
                    zpGangwei = dr["zpGangwei"].ToString(),
                    zpNum = Convert.ToInt32(dr["zpNum"]),
                    zpPayL = dr["zpPayL"].ToString(),
                    zpPayH = dr["zpPayH"].ToString(),
                    zpFuli = dr["zpFuli"].ToString(),
                    zpDetail = dr["zpDetail"].ToString(),
                    zpUser = dr["zpUser"].ToString(),
                    zpPhone = dr["zpPhone"].ToString(),
                    zpFaburen = dr["zpFaburen"].ToString(),
                    zpEndtime = Convert.ToDateTime(dr["zpEndtime"]),
                    zpAddtime = Convert.ToDateTime(dr["zpAddtime"]),
                    isTuijian = Convert.ToInt32(dr["isTuijian"]),
                    isRemen = Convert.ToInt32(dr["isRemen"])

                });

            }
            dr.Close();
            return list;
        }
        #endregion

        #region 发布招聘信息
        public int Add(ZhaoPin obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Zp_Info(zpXuqiu, zpZhuTilei, zpZhuti, zpArea, zpGangwei, zpNum, zpPayL, zpPayH, zpFuli, zpDetail, zpUser, zpPhone, zpFaburen, zpAddtime, zpEndtime) ");
            sqlBuilder.Append("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')");
            string sql = string.Format(sqlBuilder.ToString(), obj.zpXuqiu, obj.zpZhuTilei, obj.zpZhuti, obj.zpArea, obj.zpGangwei, obj.zpNum, obj.zpPayL, obj.zpPayH, obj.zpFuli, obj.zpDetail, obj.zpUser, obj.zpPhone, obj.zpFaburen, DateTime.Now, obj.zpEndtime);
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

        #region 招聘信息详情
        public ZhaoPin GetObjById(string id)
        {
            string sql = "select * from Zp_Info where zpId='{0}'";
            sql = string.Format(sql, id);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            ZhaoPin obj = null;
            if (dr.Read())
            {
                obj = new ZhaoPin
                {
                    zpId = Convert.ToInt32(dr["zpId"]),
                    zpXuqiu = dr["zpXuqiu"].ToString(),
                    zpZhuTilei = dr["zpZhuTilei"].ToString(),
                    zpZhuti = dr["zpZhuti"].ToString(),
                    zpArea = dr["zpArea"].ToString(),
                    zpGangwei = dr["zpGangwei"].ToString(),
                    zpNum = Convert.ToInt32(dr["zpNum"]),
                    zpPayL = dr["zpPayL"].ToString(),
                    zpPayH = dr["zpPayH"].ToString(),
                    zpFuli = dr["zpFuli"].ToString(),
                    zpDetail = dr["zpDetail"].ToString(),
                    zpUser = dr["zpUser"].ToString(),
                    zpPhone = dr["zpPhone"].ToString(),
                    zpFaburen = dr["zpFaburen"].ToString(),
                    zpEndtime = Convert.ToDateTime(dr["zpEndtime"]),
                    zpAddtime = Convert.ToDateTime(dr["zpAddtime"]),
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
            string sql = "delete from zp_info where zpId = " + id + "";
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
