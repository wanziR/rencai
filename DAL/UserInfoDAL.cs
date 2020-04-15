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
   public class UserInfoDAL
    {
        #region 用户登录判断
        public UserInfo Login(UserInfo obj)
        {
            string sql = "select * from User_Info where userName= '{0}' and userPwd = '{1}'";
            sql = string.Format(sql, obj.userName, obj.userPwd);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            try
            {
                if (dr.Read())
                {
                    obj.userName = dr["userName"].ToString();
                    obj.userPhone = dr["userPhone"].ToString();
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

        #region 验证码登录判断
        public UserInfo Code(UserInfo obj)
        {
            string sql = "select * from Sms_Code where TelPhone= '{0}' and Code = '{1}' and Validtime >getdate() ";
            sql = string.Format(sql, obj.userPhone, obj.Code);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            try
            {
                if (dr.Read())
                {
                    obj.userPhone = dr["TelPhone"].ToString();
                    obj.Code =dr["Code"].ToString();
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

        #region 注册用户
        public int Add(UserInfo obj)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into User_Info(userName,userPwd,userPhone,userAddtime) ");
            sqlBuilder.Append("values('{0}','{1}','{2}','{3}')");
            string sql = string.Format(sqlBuilder.ToString(), obj.userName, obj.userPwd,obj.userPhone, DateTime.Now);
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

        #region 通过手机号获取对像
        public UserInfo GetObjByTel(string userPhone)
        {
            string sql = "select * from User_Info where userPhone='{0}'";
            sql = string.Format(sql, userPhone);
            SqlDataReader dr = SQLHelper.GetReader(sql);
            UserInfo obj = null;
            if (dr.Read())
            {
                obj = new UserInfo
                {//userId, userName, userPwd, userPhone, userArea, userXin, userRole, isVIP, isShiming, isCompany, isSGgd, isGeren, userAddtime

                    userId = Convert.ToInt32(dr["userId"]),
                    userName = dr["userName"].ToString(),
                    userPwd = dr["userPwd"].ToString(),
                    userArea = dr["userArea"].ToString(),
                    userPhone = dr["userPhone"].ToString(),
                    userRole = Convert.ToInt32(dr["userRole"]),
                    isVIP = Convert.ToInt32(dr["isVIP"]),
                    isShiming = Convert.ToInt32(dr["isShiming"]),
                    isCompany = Convert.ToInt32(dr["isCompany"]),
                    userAddtime = Convert.ToDateTime(dr["userAddtime"])
                };
            }
            
                return obj;
          
        }
        #endregion

        #region @编辑对像 
        public int Edit(UserInfo obj)
        {

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update User_Info set userName='{0}',userArea='{1}' ");
            sqlBuilder.Append(" where userName = '{2}'");
            string sql = string.Format(sqlBuilder.ToString(), obj.userName, obj.userArea, obj.userName);
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

        #region 忘记密码 
        public int EditPwd(UserInfo obj)
        {

            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update User_Info set userPwd='{0}' ");
            sqlBuilder.Append(" where userPhone = '{1}'");
            string sql = string.Format(sqlBuilder.ToString(), obj.userPwd, obj.userPhone);
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

        #region 用户列表
        public List<UserInfo> GetList()
        {
            string sql = "select * from User_Info order by userRole desc";
            SqlDataReader dr = SQLHelper.GetReader(sql);
            List<UserInfo> list = new List<UserInfo>();
            while (dr.Read())
            {
                list.Add(new UserInfo
                {//userId, userName, userPwd, userPhone, userArea, userXin, userRole,
                    //isVIP, isShiming, isCompany, isSGgd, isGeren, userAddtime
                    userId = Convert.ToInt32(dr["userId"]),
                    userName = dr["userName"].ToString(),
                    userPwd = dr["userPwd"].ToString(),
                    userArea = dr["userArea"].ToString(),
                    userPhone = dr["userPhone"].ToString(),
                    userRole = Convert.ToInt32(dr["userRole"]),
                    isVIP = Convert.ToInt32(dr["isVIP"]),
                    isShiming = Convert.ToInt32(dr["isShiming"]),
                    isCompany = Convert.ToInt32(dr["isCompany"]),
                    userAddtime = Convert.ToDateTime(dr["userAddtime"])
                });
            }
            dr.Close();
            return list;
        }
        #endregion

        #region 删除用户
        public int Del(string id)
        {
            string sql = "delete from User_Info where userId =" + id + "";
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

        #region 设为管理员
        public int isGly(string id)
        {
            string sql = "update User_Info set userRole=1 where userId = " + id + "";
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

        #region 取消管理员
        public int isNoGly(string id)
        {
            string sql = "update User_Info set userRole=0 where userId = " + id + "";
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
