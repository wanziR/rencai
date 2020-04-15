using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Laowu
    {
        // lwId, lwTitle, lwName, lwSex, lwage, lwPhone, lwArea, lwGz, lwDetail, lwAddtime, lwZhuangtai, isTuijian, isRemen
        public int lwId { set; get; }
        public string lwTitle { set; get; }
        public string lwName { set; get; }
        public string lwSex { set; get; }
        public string lwage { set; get; }
        public string lwPhone { set; get; }
        public string lwArea { set; get; }
        public string lwGz { set; get; }
        public string lwDetail { set; get; }
        public DateTime lwAddtime { set; get; }
        public int lwZhuangtai { set; get; }
        public int isTuijian { set; get; }
        public int isRemen { set; get; }
    }
}
