using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class ZhaoHuo
    {
        //zhId, zhTitle, zhUser, zhPhone, zhArea, zhGz, zhDetail, zhAddtime, zhNum
        public int zhId { set; get; }
        public string zhTitle { set; get; }
        public string zhUser { set; get; }
        public string zhPhone { set; get; }
        public string zhArea { set; get; }
        public string zhGz { set; get; }
        public string zhDetail { set; get; }
        public string zgImg1 { set; get; }
        public string zgImg2 { set; get; }
        public string zgImg3 { set; get; }
        public DateTime zhAddtime { set; get; }
        public int zhNum { set; get; }

    }
}
