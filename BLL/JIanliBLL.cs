using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
   public class JIanliBLL
    {//jlId, jlName, jlPic, jlGender, jlage, jlIC, jlEdu, jlGw, jlPhone, jlEmail, jlXinzi, 
     //jlHunyin, jlWork, jlPingJia, jlAddtime, userID, jl_peixun, jl_jiaoyu
        #region 根据关键字获取简历列表
        public List<Jianli> getJlListByKword(string kword)
        {
            return new JianliDAL().getJlListByKword(kword);
        }
        #endregion

        #region 添加简历

        public int Add(Jianli obj)
        {
           return new JianliDAL().Add(obj);
        }

        #endregion

        #region --根据姓名判断用户是否存在（Excel导入用）
        public bool FindByUId(int uId)
        {
          return new JianliDAL().FindByUId(uId);

        }
        #endregion

        #region 详细
        public Jianli GetObjByUId(string id)
        {
           return new JianliDAL().GetObjByUId(id);
        }
        #endregion

        #region Excel导入删除
        public int ExDel(int id)
        {
           return new JianliDAL().ExDel(id);
        }
        #endregion
    }
}
