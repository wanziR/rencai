using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;


namespace BLL
{
   public class PointBLL
    {
        public int AddPoint(int pointId, int userId, DateTime plAddTime)
        {
           return new PointDAL().AddPoint(pointId, userId, plAddTime);
        }
    }
}
