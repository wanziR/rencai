using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class ZhaoGong
    {
        //zgId, zgTitle, zgXuqiu, zgZhuTilei, zgZhuti, zgArea, zgGz, zgNum, zgDetail, zgUser, zgPhone, zgFaburen,
        //zgStarttime, zgEndtime, zgAddtime, zgImg1, zgImg2, zgImg3
        public int zgId { set; get; }
        public string zgTitle { set; get; }
        public string zgXuqiu { set; get; }
        public string zgZhuTilei { set; get; }
        [DisplayName("主体名")]
        [Required(ErrorMessage = "{0}不得为空")]
        public string zgZhuti { set; get; }
        public int zgNum { set; get; }
        public string zgUser { set; get; }
        [DisplayName("电话号")]
        [Required(ErrorMessage = "{0}不得为空")]
        [StringLength(11, MinimumLength = 7, ErrorMessage = "{0}长度不合要求")]
        public string zgPhone { set; get; }
        public string zgArea { set; get; }
        public string zgGz { set; get; }
        public string zgDetail { set; get; }
        public string zgFaburen { set; get; }
        public string zgImg1 { set; get; }
        public string zgImg2 { set; get; }
        public string zgImg3 { set; get; }
        public DateTime zgStarttime { set; get; }
        public DateTime zgEndtime { set; get; }
        public DateTime zgAddtime { set; get; }

        //工种gzID, gzName, gzPid
        public int gzID { set; get; }
        public string gzName { set; get; }
        public int gzPid { set; get; }

    }
}
