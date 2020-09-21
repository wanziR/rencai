using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Plugin
    {
        //短信 Sms_Code=>Id, Code, TelPhone, Sendtime, Validtime
        public int Id { set; get; }
        public int Code { set; get; }
        public string TelPhone { set; get; }
        public DateTime Sendtime { set; get; }
        public DateTime Validtime { set; get; }

    }
}
