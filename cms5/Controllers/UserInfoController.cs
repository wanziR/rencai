using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using System.Web.Security;
using qcloudsms_csharp;
using qcloudsms_csharp.json;
using qcloudsms_csharp.httpclient;


namespace cms5.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        #region 登录判断
        [HttpPost]
        public ActionResult userLogin(UserInfo obj)
        {
            obj = new UserInfo
            {
                userName = obj.userName,
                userPwd = obj.userPwd
            };
            obj = new UserInfoBLL().Login(obj);
            if (obj != null)
            {
                string userPhone = obj.userPhone;
                FormsAuthentication.SetAuthCookie(userPhone, true);
                return new ContentResult() { Content = "<script> window.location.href = '/zhaogong/userCenter';</script>" };
                //return RedirectToAction("userCenter","ZhaoGong",obj);
            }
            else
            {
                return this.Content("用户名或密码错误，请重新填写！");
            }

        }
        #endregion

        #region 注册
        [HttpPost]
        public ActionResult userReg(UserInfo obj)
        {
            if (obj.userName==null || obj.userName.Length < 4)
            {
                return this.Content("用户名不能为空并且要长度大于3个字符！");
            }
            if (obj.userPwd == null || obj.userPwd.Length < 6)
            {
                return this.Content("密码不能为空并且要长度大于5个字符！");
            }
            if (obj.userPwd != obj.userPwdag)
            {
                return this.Content("两次密码输入不一致！");
            }
            if (obj.userPhone == null)
            {
                return this.Content("手机号不能为空！");
            }
            UserInfo obju = new UserInfoBLL().GetObjByTel(obj.userPhone);
            if (obju != null)
            {
                return this.Content("手机号已被注册！");
            }
            if (obj.Code == null)
            {
                return this.Content("验证码不能为空！");
            }
            else
            {
                UserInfo objc = new UserInfo
                {
                    userPhone = obj.userPhone,
                    Code = obj.Code
                };
                objc = new UserInfoBLL().Code(objc);
                if (objc != null)
                {
                    obj = new UserInfo
                    {
                        userName = obj.userName,
                        userPwd = obj.userPwd,
                        userPwdag = obj.userPwdag,
                        userPhone = obj.userPhone
                    };

                    int result = new UserInfoBLL().Add(obj);
                    return this.Content("注册成功，点击登录！");
                    
                }
                else
                {
                    return this.Content("验证码错误！");
                }
            }
        }
        #endregion

        #region _ZgTop分部视图登录状态
        public ActionResult Logined(UserInfo obj)
        {
            string uPhone = this.User.Identity.Name;
            obj = new UserInfoBLL().GetObjByTel(uPhone);
            return PartialView("_ZgTop", obj);
        }
        #endregion


        //#region 验证码注册/登录
        //public ActionResult GetAdd(UserInfo obj)
        //{
        //    obj = new UserInfo
        //    {
        //        userPhone = obj.userPhone,
        //        Code = obj.Code
        //    };
        //    obj = new UserInfoBLL().Code(obj);
        //    if (obj != null)
        //    {
        //        UserInfo obju = new UserInfoBLL().GetObjByTel(obj.userPhone);
        //        if (obju != null)
        //        {
        //            //ViewBag.tel = "*该手机号已被注册";
        //            string userName = obju.userName;
        //            FormsAuthentication.SetAuthCookie(userName, true);
        //            Session["UserName"] = userName;
        //            Session["UserPhone"] = obju.userPhone;
        //            return RedirectToAction("UserCenter", "ZhaoGong", obju);

        //        }
        //        else
        //        {
        //            obj = new UserInfo
        //            {
        //                userName = obj.userPhone,
        //                //userPwd = obj.userPhone.Substring(obj.userPhone.Length - 6, 6),
        //                userPwd = obj.Code.ToString(),
        //                userPhone = obj.userPhone
        //            };
        //            int result = new UserInfoBLL().Add(obj);
        //            string info = "已成功注册，请登录！";
        //            string userName = obj.userName;
        //            FormsAuthentication.SetAuthCookie(userName, true);
        //            Session["UserName"] = userName;
        //            return RedirectToAction("UserCenter", "ZhaoGong", new { info });


        //        }


        //    }
        //    else
        //    {
        //        ViewBag.info = "*验证码错误！";
        //        return View("Reg");
        //    }


        //}
        //#endregion

        #region 退出
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null;
            Session["UserPhone"] = null;
            return RedirectToAction("Index", "ZhaoGong");
        }
        #endregion

        #region 发送验证码
        public ActionResult SendSms(string telphone)
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
            string smsMeg = "甘肃建投人力网用户注册";


            //单发短信
            try
            {
                SmsSingleSender ssender = new SmsSingleSender(appid, appkey);
                var result = ssender.send(0, "86", "" + telphone + "",
                      "【" + smsSign + "】验证码" + smsCode + "，用于" + smsMeg + "，5分钟内有效。验证码提供给他人可能导致帐号被盗，请勿泄露，谨防被骗。", "", "");
                Console.WriteLine(result);
                ViewBag.code = smsCode;
                ViewBag.msg = "消息已发送！";
                Sms obj = new Sms()
                {
                    Code = smsCode,
                    TelPhone = telphone
                };
                var result2 = new SmsBLL().AddCoreInfo(obj);

            }

            catch (JSONException e)
            {
                Console.WriteLine(e);
                ViewBag.msg = e;
            }
            catch (HTTPException e)
            {
                Console.WriteLine(e);
                ViewBag.msg = e;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.msg = e;
            }

            return View("Reg");


        }
        #endregion

        #region 返回页面
        public ActionResult Login(string info)
        {
            ViewBag.info = info;
            return View();
        }
        public ActionResult Reg()
        {
            return View();
        }
        #endregion

        #region 编辑页面
        public ActionResult EditUser(string userPhone, string info)
        {
            // ViewBag.info = info;
            UserInfo obj = new UserInfoBLL().GetObjByTel(userPhone);
            return View(obj);
        }
        #endregion

        #region 编辑对像
        public ActionResult GetEdit(UserInfo obj)
        {
            obj = new UserInfo()
            {
                userName = obj.userName,
                userArea = obj.userArea

            };
            int result = new UserInfoBLL().Edit(obj);
            string info = "已修改一条记录！";
            return RedirectToAction("EditUser", "UserInfo", new { info });

        }
        #endregion

        #region 忘记密码
        public ActionResult fgPwd(UserInfo obj)
        {
            obj = new UserInfo()
            {
                userPhone = obj.userPhone,
                userPwd = obj.userPwd

            };
            int result = new UserInfoBLL().EditPwd(obj);
            //string info = "已修改一条记录！";
            //return RedirectToAction("EditUser", "UserInfo", new { info });
            return this.Content("密码修改成功，请重新登录！");

        }
        #endregion

        #region 用户列表
        public ActionResult aUserList(string info)
        {
            List<UserInfo> List = new UserInfoBLL().GetList();
            ViewBag.info = info;
            ViewBag.list = List;
            return View();
        }
        #endregion

        #region 删除
        public ActionResult Del(string id)
        {
            int result = new UserInfoBLL().Del(id);

            if (result == 1)
            {
                string info = "删除成功！";
                return RedirectToAction("aUserList", "UserInfo", new { info });

            }
            else
            {
                return this.Content("删除失败！");
            }
        }
        #endregion

        #region 设为管理员
        public ActionResult isGly(string id)
        {
            int result = new UserInfoBLL().isGly(id);

            if (result == 1)
            {
                string info = "设置成功！";
                return RedirectToAction("aUserList", "UserInfo", new { info });
            }
            else
            {
                return this.Content("设置失败！");
            }
        }
        #endregion

        #region 取消管理员
        public ActionResult isNoGly(string id)
        {
            int result = new UserInfoBLL().isNoGly(id);

            if (result == 1)
            {
                string info = "设置成功！";
                return RedirectToAction("aUserList", "UserInfo", new { info });
            }
            else
            {
                return this.Content("设置！");
            }
        }
        #endregion



    }
}