using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using System.Web;

namespace BLL
{
   public class PluginBLL
    {
        #region 短信
        //添加手验证码到数据库
        public int AddCoreInfo(Plugin obj)
        {
            return new PluginDAL().AddCoreInfo(obj);
        }
        #endregion
    }
}
