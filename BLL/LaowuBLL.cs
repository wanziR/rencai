using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
   public class LaowuBLL
    {
        #region 获取招工信息列表-首页
        public List<Laowu> GetLwListIndex()
        {

            return new LaowuDAL().GetLwListIndex();
        }
        #endregion

        #region 获取个人劳务列表
        public List<Laowu> GetLwList()
        {
            return new LaowuDAL().GetLwList();
        }
        #endregion

        #region 通过搜索关键字获取劳务信息列表
        public List<Laowu> GetZhListByWord(string strWord)
        {
            return new LaowuDAL().GetZhListByWord(strWord);
        }
        #endregion

        #region 获取找活城市列表
        public List<Laowu> GetZhCityList()
        {
            return new LaowuDAL().GetZhCityList();
        }
        #endregion

        #region 通过ID获取找活信息详细
        public Laowu GetObjById(string id)
        {
            return new LaowuDAL().GetObjById(id);
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
            return new LaowuDAL().Del(id);
        }
        #endregion
    }
}
