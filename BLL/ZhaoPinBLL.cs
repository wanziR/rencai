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
   public class ZhaoPinBLL
    {
        #region 获取招聘信息列表
        public List<ZhaoPin> GetList()
        {
            return new ZhaoPinDAL().GetList();
        }
        #endregion

        #region 获取招聘信息列表首页
        public List<ZhaoPin> GetListIndex()
        {
            return new ZhaoPinDAL().GetListIndex();
        }
        #endregion

        #region 通过搜索关键字获取招聘信息列表
        public List<ZhaoPin> GetListByWord(string strWord)
        {
            return new ZhaoPinDAL().GetListByWord(strWord);
        }
        #endregion

        #region 发布招聘信息
        public int Add(ZhaoPin obj)
        {
            return new ZhaoPinDAL().Add(obj);
        }
        #endregion

        #region 招聘信息详情
        public ZhaoPin GetObjById(string id)
        {
            return new ZhaoPinDAL().GetObjById(id);
        }
        #endregion

        #region 删除
        public int Del(string id)
        {
            return new ZhaoPinDAL().Del(id);
        }
        #endregion
    }
}
