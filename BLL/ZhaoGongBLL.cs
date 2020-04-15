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
   public class ZhaoGongBLL
    {
        #region 发布招工信息
        public int Add(ZhaoGong obj)
        {
            return new ZhaoGongDAL().Add(obj);
        }
        #endregion

        #region 获取招工信息列表
        public List<ZhaoGong> GetZgList()
        {
            return new ZhaoGongDAL().GetZgList();
        }
        #endregion

        #region 获取招工城市列表
        public List<ZhaoGong> GetZgCityList()
        {
            return new ZhaoGongDAL().GetZgCityList();
        }
        #endregion

        #region 通过搜索关键字获取招工信息列表
        public List<ZhaoGong> GetZgListByWord(string strWord)
        {
            return new ZhaoGongDAL().GetZgListByWord(strWord);
        }
        #endregion

        #region 获取招工信息列表-首页
        public List<ZhaoGong> GetZgListIndex()
        {
            return new ZhaoGongDAL().GetZgListIndex();
        }
        #endregion

        #region 通过ID获取招工信息详细
        public ZhaoGong GetObjById(string id)
        {
            return new ZhaoGongDAL().GetObjById(id);
        }
        #endregion

        #region 通过PId获取工种列表
        public List<ZhaoGong> GetGzList(int PId)
        {
            return new ZhaoGongDAL().GetGzList(PId);
        }
        #endregion

        #region 首页标题字数
        public string SubStr(string sString, int nLeng)
        {
            if (sString.Length <= nLeng)
            {
                return sString;
            }
            string sNewStr = sString.Substring(0, nLeng);
            sNewStr = sNewStr + "..."; return sNewStr;
        }
        #endregion

        #region 通过id删除对像
        public int Del(string id)
        {
            return new ZhaoGongDAL().Del(id);
        }
        #endregion


    }
}
