using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class ZhaoPin
    {
        //zpId, zpXuqiu, zpZhuTilei, zpZhuti, zpArea, zpGangwei, zpNum, zpPayL, zpPayH, zpFuli, 
        //zpDetail, zpUser, zpPhone, zpFaburen, zpAddtime, zpEndtime, isTuijian, isRemen
        public int zpId { set; get; }
        public string zpXuqiu { set; get; }
        public string zpZhuTilei { set; get; }
        public string zpZhuti { set; get; }
        public string zpArea { set; get; }
        public int zpNum { set; get; }
        public string zpGangwei { set; get; }
        public string zpPayL { set; get; }
        public string zpPayH { set; get; }
        public string zpFuli { set; get; }
        public string zpDetail { set; get; }
        public string zpUser { set; get; }
        [DisplayName("电话号")]
        [Required(ErrorMessage = "{0}不得为空")]
        [StringLength(11, MinimumLength = 7, ErrorMessage = "{0}长度不合要求")]
        public string zpPhone { set; get; }
        public string zpFaburen { set; get; }
        public DateTime zpAddtime { set; get; }
        public DateTime zpEndtime { set; get; }
        public int isTuijian { set; get; }
        public int isRemen { set; get; }


    }
}
