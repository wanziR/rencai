using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
   public class PointDAL
    {
        public int AddPoint(int pointId, int userId, DateTime plAddTime)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into Point_Log(pointId,pointValue,userId,plAddTime)");
            sb.Append("values({0},(select pointValue from Point where pointId = {0}),{1},'{2}')");
            string sql = String.Format(sb.ToString(), pointId, userId, plAddTime);
            int result = SQLHelper.Update(sql);
            return result;
        }
    }
}
