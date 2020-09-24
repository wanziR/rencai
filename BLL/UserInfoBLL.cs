using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Web;
using System.Web.Security;

namespace BLL
{
   public  class UserInfoBLL
    {
        #region 用户登录判断
        public UserInfo Login(UserInfo obj)
        {
            obj = new UserInfoDAL().Login(obj);
            if (obj != null)
            {
               HttpContext.Current.Session["UserName"] = obj.userName;
               HttpContext.Current.Session["UserPhone"] = obj.userPhone;

            }
            return obj;

        }
        #endregion

        #region 验证码登录判断
        public UserInfo Code(UserInfo obj)
        {
            obj = new UserInfoDAL().Code(obj);
            if (obj != null)
            {
                HttpContext.Current.Session["Code"] = obj.Code;
            }
            return obj;
        }
        #endregion

        #region 注册用户
        public int Add(UserInfo obj)
        {
            return new UserInfoDAL().Add(obj);
        }
        #endregion

        #region 通过手机号获取对像详细
        public UserInfo GetObjByTel(string userPhone)
        {
            return new UserInfoDAL().GetObjByTel(userPhone);
        }
        #endregion

        #region 通过用户名取对像
        public UserInfo GetObjByUName(string userName)
        {
          return new UserInfoDAL().GetObjByUName(userName);

        }
        #endregion

        #region @编辑对像 
        public int Edit(UserInfo obj)
        {

            return new UserInfoDAL().Edit(obj);
        }
        #endregion

        #region 忘记密码 
        public int EditPwd(UserInfo obj)
        {

            return new UserInfoDAL().EditPwd(obj);
        }
        #endregion

        #region 用户列表
        public List<UserInfo> GetList()
        {
            return new UserInfoDAL().GetList();
        }
        #endregion

        #region 删除用户
        public int Del(string id)
        {
            return new UserInfoDAL().Del(id);
        }
        #endregion

        #region 设为管理员
        public int isGly(string id)
        {
            return new UserInfoDAL().isGly(id);
        }
        #endregion

        #region 取消管理员
        public int isNoGly(string id)
        {
            return new UserInfoDAL().isNoGly(id);
        }
        #endregion
    }
}
