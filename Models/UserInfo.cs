using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class UserInfo
    {
        //userId, userName, userPhone, userArea, userXin, isVIP, isShiming,
        //isCompany, isSGgd, isGeren, userAddtime
        public int userId { set; get; }
        [DisplayName("姓名")]
        [Required(ErrorMessage = "*{0}不得为空")]
        [StringLength(24, MinimumLength = 2, ErrorMessage = "*{0}长度不合要求")]
        public string userName { set; get; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "*{0}不得为空")]
        [StringLength(24, MinimumLength = 6, ErrorMessage = "*{0}长度不合要求")]
        public string userPwd { set; get; }
        [Compare("userPwd",ErrorMessage ="两次输入密码不一致")]
        public string userPwdag { set; get; }
        [DisplayName("手机号")]
        [Required(ErrorMessage = "*{0}不得为空")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "*{0}长度不合要求")]
        public string userPhone { set; get; }
        [DisplayName("电子邮件")]
        [Required(ErrorMessage = "*{0}不得为空")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$",ErrorMessage ="输入正确的{0}")]
        public string userEmail { set; get; }
        public string userArea { set; get; }
        public int userXin { set; get; }
        public int userRole { set; get; }
        public int isVIP { set; get; }
        public int isShiming { set; get; }
        public int isCompany { set; get; }
        public int isSGgd { set; get; }
        public int isGeren { set; get; }
        public DateTime userAddtime { set; get; }

        public string Code { set; get; }

    }
}
