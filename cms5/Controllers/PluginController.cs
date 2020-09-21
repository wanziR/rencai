using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using qcloudsms_csharp;
using X.PagedList;
using System.IO;


namespace cms5.Controllers
{
    public class PluginController : Controller
    {
        // GET: Plugin
        public ActionResult Index()
        {
            return View();
        }
        #region 短信
        public ActionResult Sms()
        {
            return View();
        }
        //分部视图_发送验证码
        public ActionResult _Sms(string PhoneId, string Smsmeg)
        {
            ViewBag.PhoneId = PhoneId;
            ViewBag.Smsmeg = Smsmeg;
            return PartialView("_Sms");
        }
        //发送验证码
        public ActionResult SendSms(string telphone, string smsmeg)
        {
            // 短信应用SDK AppID
            int appid = 1400247845;

            // 短信应用SDK AppKey
            string appkey = "e4f356f4cf5927e06994b73df3fa86c5";

            // 需要发送短信的手机号码
            //  string[] phoneNumbers = { "139094236879", "18193169220" };
            // string smsPhone = "13909426879";
            // 短信模板ID，需要在短信应用中申请
            int templateId = 401837; // 

            // 签名
            string smsSign = "五点科技"; // NOTE: 这里的签名只是示例，请使用真实的已申请的签名, 签名参数使用的是`签名内容`，而不是`签名ID`
            //验证码
            Random r1 = new Random();
            int smsCode = r1.Next(100000, 999999);
            //消息
            string smsMeg = smsmeg;


            //单发短信
            SmsSingleSender ssender = new SmsSingleSender(appid, appkey);
            var result = ssender.send(0, "86", "" + telphone + "",
                "【" + smsSign + "】验证码" + smsCode + "，用于" + smsMeg + "，5分钟内有效。验证码提供给他人可能导致帐号被盗，请勿泄露，谨防被骗。", "", "");
            Console.WriteLine(result);
            ViewBag.code = smsCode;
            ViewBag.msg = "消息已发送！";
            Plugin obj = new Plugin()
            {
                Code = smsCode,
                TelPhone = telphone
            };
            var result2 = new PluginBLL().AddCoreInfo(obj);
            string strCode = smsCode.ToString();
            return Content(strCode);


        }
        #endregion
    }
}