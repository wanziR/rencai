using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Models
{
    public class Admin
    {//adminId,adminName,adminPwd,adminAddtime
        public int adminId { set; get; }
        public string adminName { set; get; }
        public string adminPwd { set; get; }
        public DateTime adminAddtime { set; get; }
    }

}