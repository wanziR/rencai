using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Models
{
   public class Jianli
    {//jlId, jlName, jlPic, jlGender, jlage, jlIC, jlEdu, jlGw, jlPhone, jlEmail, jlXinzi, 
     //jlHunyin, jlWork, jlPingJia, jlAddtime, userID, jl_peixun, jl_jiaoyu  ,userName
        public int jlId { set; get; }
        public int jlWork { set; get; }
        public int userID { set; get; }
        public int jlXinzi { set; get; }
        public string jlName { set; get; }
        public string jlPic { set; get; }
        public string jlGender { set; get; }
        public string jlage { set; get; }
        public string jlIC { set; get; }
        public string jlEdu { set; get; }
        public string jlGw { set; get; }
        public string jlPhone { set; get; }
        public string jlEmail { set; get; }
        public string jlHunyin { set; get; }
        public string jlPingJia { set; get; }
        public string jl_peixun { set; get; }
        public string jl_jiaoyu { set; get; }
        public DateTime jlAddtime { set; get; }

    }
}
