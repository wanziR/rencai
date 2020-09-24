using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class Point
    {
        //Point=>pointId, pointName, pointValue 
        public int pointId { get; set; }
        public string pointName { get; set; }
        public int pointValue { get; set; }

        //Point_Log=>plId, pointId, userId, plAddTime
        public int plId { get; set; }
        public int userId { get; set; }
        public DateTime plAddTime { get; set; }

    }
}
