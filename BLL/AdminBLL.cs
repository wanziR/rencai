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
    public class AdminBLL
    {
        #region 登录判断
        public UserInfo Login(UserInfo obj)
        {
            obj = new AdminDAL().Login(obj);
            if (obj != null)
            {
                HttpContext.Current.Session["CurrentAdmin"] = obj;
                HttpContext.Current.Session["AdminName"] = obj.userName;
                //FormsAuthentication.SetAuthCookie(obj.adminName, true);
            }
            return obj;
        }
        #endregion

        #region 获取用户列表
        public List<Admin> GetList()
        {
            return new AdminDAL().GetList();
        }
        #endregion

        #region 通过ID获取对像详细
        public Admin GetObjById(string id)
        {
            return new AdminDAL().GetObjById(id);
        }
        #endregion

        #region 添加用户
        public int Add(Admin obj)
        {
            return new AdminDAL().Add(obj);
        }
        #endregion

        #region 通过id删除对像
        public int Del(string id)
        {
            return new AdminDAL().Del(id);
        }
        #endregion

        #region 编辑对像 
        public int Edit(Admin obj)
        {
            return new AdminDAL().Edit(obj);

        }
        #endregion
    }
}