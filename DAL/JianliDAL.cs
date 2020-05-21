using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class JianliDAL
    {//jlId, jlName, jlPic, jlGender, jlage, jlIC, jlEdu, jlGw, jlPhone, jlEmail, jlXinzi,
     //jlHunyin, jlWork, jlPingJia, jlAddtime, userID, jl_peixun, jl_jiaoyu
        #region 根据关键字获取简历列表
        public List<Jianli> getJlListByKword(string kword)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(
                "select *,(select userName from User_Info where userId=Jl_info.userID) as userName from Jl_info ");
            strb.Append("where jlName like '%" + kword + "%' ");
            strb.Append("or jlGw like '%" + kword + "%'");
            strb.Append("or jlPhone like '%" + kword + "%'");
            strb.Append("order by jlAddtime desc");
            string sql = strb.ToString();
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Jianli> list = new List<Jianli>();
            while (dr.Read())
            {
                list.Add(new Jianli
                {
                    jlId = Convert.ToInt32(dr["jlId"]),
                    jlWork = Convert.ToInt32(dr["jlWork"]),
                    userID = Convert.ToInt32(dr["userID"]),
                    jlXinzi = Convert.ToInt32(dr["jlXinzi"]),
                    jlName = dr["jlName"].ToString(),
                    jlPic = dr["jlPic"].ToString(),
                    jlGender = dr["jlGender"].ToString(),
                    jlage = dr["jlage"].ToString(),
                    jlIC = dr["jlIC"].ToString(),
                    jlEdu = dr["jlEdu"].ToString(),
                    jlGw = dr["jlGw"].ToString(),
                    jlPhone = dr["jlPhone"].ToString(),
                    jlEmail = dr["jlEmail"].ToString(),
                    jlPingJia = dr["jlPingJia"].ToString(),
                    jl_peixun = dr["jl_peixun"].ToString(),
                    jl_jiaoyu = dr["jl_jiaoyu"].ToString(),
                    jlAddtime = Convert.ToDateTime(dr["jlAddtime"]),
                });
            }
            dr.Close();
            return list;


        }
        #endregion

        #region 添加简历

        public int Add(Jianli obj)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("insert into jl_Info(jlName, jlPic, jlGender, jlage, jlIC, jlEdu, jlGw, jlPhone, jlEmail, jlXinzi, jlHunyin, jlWork, jlPingJia, jlAddtime, userID, jl_peixun, jl_jiaoyu)");
            strb.Append("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}',{11},'{12}','{13}',{14},'{15}','{16}')");
            string sql = string.Format(strb.ToString(), obj.jlName, obj.jlPic, obj.jlGender, obj.jlage, obj.jlIC, obj.jlEdu,
                obj.jlGw, obj.jlPhone, obj.jlEmail, obj.jlXinzi, obj.jlHunyin, obj.jlWork, obj.jlPingJia, DateTime.Now,
                obj.userID, obj.jl_peixun, obj.jl_jiaoyu);
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                throw new Exception("数据库操作出现异常！具体信息：\r\n" + ex.Message);
            }

        }

        #endregion

        #region --根据姓名判断用户是否存在（Excel导入用）
        public bool FindByUId(int uId)
        {
            string sql = "select * from jl_Info where userId=" + uId + "";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            try
            {
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("应用程序数据库连接出现问题" + ex.Message);
            }


        }
        #endregion

        #region 详细
        public Jianli GetObjByUId(string id)
        {
            string sql = "select *,(select userName from User_Info where userId=Jl_info.userID) as userName from Jl_info where jlId='{0}'";
            sql = string.Format(sql, id);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            Jianli obj = null;
            if (dr.Read())
            {
                obj = new Jianli
                {
                    // jlWork = Convert.ToInt32(dr["jlWork "]),
                    userID = Convert.ToInt32(dr["userID"]),
                    jlXinzi = Convert.ToInt32(dr["jlXinzi"]),
                    jlName = dr["jlName"].ToString(),
                    jlPic = dr["jlPic"].ToString(),
                    jlGender = dr["jlGender"].ToString(),
                    jlage = dr["jlage"].ToString(),
                    jlIC = dr["jlIC"].ToString(),
                    jlEdu = dr["jlEdu"].ToString(),
                    jlGw = dr["jlGw"].ToString(),
                    jlPhone = dr["jlPhone"].ToString(),
                    jlEmail = dr["jlEmail"].ToString(),
                    jlPingJia = dr["jlPingJia"].ToString(),
                    jl_peixun = dr["jl_peixun"].ToString(),
                    jl_jiaoyu = dr["jl_jiaoyu"].ToString(),
                    jlAddtime = Convert.ToDateTime(dr["jlAddtime"]),
                };
            }
            return obj;
        }
        #endregion

        #region Excel导入删除
        public int ExDel(int id)
        {
            string sql = "delete from jl_Info where jlId = " + id + "";
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
