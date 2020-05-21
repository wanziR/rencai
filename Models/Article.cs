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
    [ValidateInput(false)]
    public class Article
    {//aId, aName, aContent, acId, aAuthor, aPV, aAddtime, isTuiJian, isReMen, isZhiDing
        public int Id { set; get; }
        public int aId { set; get; }
        public string aName { set; get; }
        public string acName { set; get; }
        public string aContent { set; get; }
        public int acId { set; get; }
        public string aAuthor { set; get; }
        public int aPV { set; get; }
        public DateTime aAddtime { set; get; }
        public int isTuiJian { set; get; }
        public int isReMen { set; get; }
        public int isZhiDing { set; get; }
        public string aType { set; get; }
        public string aLink { set; get; }


        //单页
        public int asId { set; get; }
        public int asOrder { set; get; }
        public string asName { set; get; }
        public string asImg { set; get; }
        public string asContent { set; get; }
        public DateTime asAddTime { set; get; }
    }
}
