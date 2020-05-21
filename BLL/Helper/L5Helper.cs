using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class L5Helper
    {
        #region MD5加密
        public string MD5(string DataStr)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(DataStr, "md5");
        }
        public string MD5_16(string DataStr)
        {
            string md5str = this.MD5(DataStr);
            return md5str.Substring(8, 16);
        }
        #endregion

        #region 根据生日获取年龄

        public int GetAgeByBD(string strDate)
        {
            DateTime dtn = DateTime.Now;
            DateTime dt = Convert.ToDateTime(strDate);
            TimeSpan ts = dtn - dt;
            int age = Convert.ToInt32(ts.Days / 360);
            return age;
        }

        #endregion
    }
}
