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
   public class ZhaoHuoBLL
    {
        #region 发布找活信息
        public int Add(ZhaoHuo obj)
        {
            return new ZhaoHuoDAL().Add(obj);
        }
        #endregion

        #region 获取找活信息列表
        public List<ZhaoHuo> GetZgList()
        {
            return new ZhaoHuoDAL().GetZgList();
        }
        #endregion

        #region 获取找活城市列表
        public List<ZhaoHuo> GetZhCityList()
        {
            return new ZhaoHuoDAL().GetZhCityList();
        }
        #endregion

        #region 通过搜索关键字获取招工信息列表
        public List<ZhaoHuo> GetZhListByWord(string strWord)
        {
            return new ZhaoHuoDAL().GetZhListByWord(strWord);
        }
        #endregion

        #region 获取找活信息列表-首页
        public List<ZhaoHuo> GetZgListIndex()
        {
            return new ZhaoHuoDAL().GetZgList();
        }
        #endregion

        #region 通过ID获取找活信息详细
        public ZhaoHuo GetObjById(string id)
        {
            return new ZhaoHuoDAL().GetObjById(id);
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

    }
}
