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
    public class AdminDAL
    {
        #region 用户登录判断
        public UserInfo Login(UserInfo obj)
        {
            string sql = "select userName from User_Info where userName= '{0}' and userPwd = '{1}' and userRole=1";
            sql = string.Format(sql, obj.userName, obj.userPwd);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            try
            {
                if (dr.Read())
                {
                    obj.userName = dr["userName"].ToString();
                    dr.Close();
                }
                else
                {
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("应用程序数据库连接出现问题" + ex.Message);
            }
            return obj;


        }
        #endregion

        #region 获取用户列表
        public List<Admin> GetList()
        {
            string sql = "select * from Sys_Admin";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<Admin> list = new List<Admin>();
            while (dr.Read())
            {
                list.Add(new Admin
                {
                    adminId = Convert.ToInt32(dr["adminId"]),
                    adminName = dr["adminName"].ToString(),
                    adminAddtime = Convert.ToDateTime(dr["adminAddtime"])

                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 通过ID获取对像详细
        public Admin GetObjById(string id)
        {
            string sql = "select * from Sys_Admin where adminId='{0}'";
            sql = string.Format(sql, id);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            Admin obj = null;
            if (dr.Read())
            {
                obj = new Admin
                {
                    adminName = dr["adminName"].ToString(),
                    adminPwd = dr["adminPwd"].ToString(),
                    adminAddtime = Convert.ToDateTime(dr["adminAddtime"])
                };
            }

            return obj;
        }
        #endregion

        #region 添加用户
        public int Add(Admin obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Sys_Admin(adminName,adminPwd,adminAddtime) ");
            sqlBuilder.Append("values('{0}','{1}','{2}')");
            string sql = string.Format(sqlBuilder.ToString(), obj.adminName, obj.adminPwd, DateTime.Now);
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

        #region 通过id删除对像
        public int Del(string id)
        {
            string sql = "delete from Sys_Admin where adminId = " + id + "";
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

        #region @编辑对像 
        public int Edit(Admin obj)
        {

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Sys_Admin set adminName='{0}',adminPwd='{1}' ");
            sqlBuilder.Append(" where adminId = '{2}'");
            string sql = string.Format(sqlBuilder.ToString(), obj.adminName, obj.adminPwd, obj.adminId);
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
