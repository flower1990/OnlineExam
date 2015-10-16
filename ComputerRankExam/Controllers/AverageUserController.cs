using ComputerRankExam.App_Start;
using ComputerRankExam.Models;
using Sower.Business;
using Sower.CommFunction;
using Sower.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Controllers
{
    public class AverageUserController : Controller
    {
        AverageUserService userService = new AverageUserService();
        LearnCardService cardService = new LearnCardService();
        ActionLogService actionLogService = new ActionLogService();
        PageHelper pageHelper = new PageHelper();

        /// <summary>
        /// 获取验证码
        /// </summary>
        public string ValidateCode
        {
            get
            {
                HttpCookie _cookie = Request.Cookies["ValidateCode1"];
                if (_cookie == null) return "";
                else return _cookie["ValCode"];
            }
        }
        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult VerificationCode()
        {
            string verificationCode = Picture.CreateVerificationText(6);
            Bitmap _img = Picture.CreateVerificationImage(verificationCode, 160, 30);
            _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="emailViewModel"></param>
        /// <returns></returns>
        public JsonResult SendEmail(ValidatePasswordViewModel emailViewModel)
        {
            Random rd = new Random();
            int num = rd.Next(100000, 999999);

            HttpCookie _cookie = new HttpCookie("ValidateCode1");
            _cookie.Path = "/";
            _cookie.Expires = DateTime.Now.AddHours(1);
            _cookie.Values.Add("ValCode", num.ToString());
            Response.Cookies.Add(_cookie);

            string content = string.Format("亲爱的用户：您好！感谢您使用朔日测评，您正在进行邮箱验证，本次请求的验证码为：{0}（为了保障您帐号的安全性，请在1小时内完成验证。）", num);
            CommonUnits.SendEmail(emailViewModel.Email, "朔日测评--邮箱身份验证", content);

            return Json("");
        }
        /// <summary>
        /// 检查电子邮箱是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public JsonResult CheckEmail(string email)
        {
            var result = userService.FindByEmail(email) != null;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="returnUrl">返回Url</param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                int loginresult = 0;

                #region 验证验证码
                if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != login.VerificationCode.ToUpper())
                {
                    ModelState.AddModelError("VerificationCode", "您输入的验证码不正确");
                    return View(login);
                }
                #endregion

                #region 验证账号密码
                bool checkResult = CommonUnits.CheckNumber(login.UserName);
                if (checkResult)
                {
                    loginresult = cardService.Authentication(login.UserName, DES.EncryStrHexUTF8(login.Password, login.UserName));
                }
                else
                {
                    loginresult = userService.Authentication(login.UserName, DES.EncryStrHexUTF8(login.Password, login.UserName));
                }

                if (loginresult == 1)
                {
                    ModelState.AddModelError("UserName", "用户名或卡号不存在");
                    return View();
                }
                else if (loginresult == 2)
                {
                    ModelState.AddModelError("Password", "密码不正确");
                    return View();
                }
                else if (loginresult == 3)
                {
                    ModelState.AddModelError("UserName", "考号被禁用");
                    return View();
                }
                #endregion

                #region 保存Cookie
                HttpCookie _cookie = new HttpCookie("AverageUser");
                _cookie.Expires = DateTime.Now.AddDays(7);
                if (SysFun.isstartdomain) _cookie.Domain = SysFun.cookiedomain;
                _cookie.Values.Add("UserName", login.UserName);
                _cookie.Values.Add("Password", DES.EncryStrHexUTF8(login.Password, login.UserName));
                Response.Cookies.Add(_cookie);
                #endregion

                #region 登录日志
                PageHelper pageHelper = new PageHelper();

                if (checkResult)
                {
                    var _card = cardService.Find(login.UserName);
                    pageHelper.AddLog<T_LearnCard>(ActionLogType.UserLogin, _card.Id, "卡号登录：" + _card.Code);
                }
                else
                {
                    var _user = userService.Find(login.UserName);
                    pageHelper.AddLog<T_AverageUser>(ActionLogType.UserLogin, _user.AverageUserID, "会员登录：" + _user.UserName);
                }
                #endregion

                if (Request.QueryString["ReturnUrl"] != null) return Redirect(Request.QueryString["ReturnUrl"]);
                else return RedirectToAction("Index", "Home", routeValues: new { Area = "Member" });
            }
            return View();
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != register.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
                return View(register);
            }

            if (ModelState.IsValid)
            {
                if (userService.Exist(register.UserName))
                {
                    ModelState.AddModelError("UserName", "用户名已存在");
                }
                else if (userService.Exist(register.UserName) && userService.Exist(register.Email))
                {
                    ModelState.AddModelError("UserName", "邮箱已存在");
                }
                else
                {
                    T_AverageUser _user = new T_AverageUser()
                    {
                        UserName = register.UserName,
                        Password = DES.EncryStrHexUTF8(register.Password, register.UserName),
                        Email = register.Email,
                        Sex = register.Sex,
                        Approved = true,
                        LoginTimes = 0,
                        CreateTime = DateTime.Now,
                        ModifyTime = DateTime.Now,
                        Cach = 0
                    };
                    _user = userService.Add(_user);
                    if (_user.AverageUserID > 0)
                    {
                        return RedirectToAction("Login", "AverageUser");
                    }
                    else { ModelState.AddModelError("", "注册失败！"); }
                }
            }

            return View(register);
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <returns></returns>
        public ActionResult FindPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult FindPassword(FindPasswordViewModel findPassword)
        {
            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != findPassword.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "您输入的验证码不正确");
                return View(findPassword);
            }

            if (ModelState.IsValid)
            {
                return View("~/Views/AverageUser/ValidatePassword.cshtml");
            }

            return View(findPassword);
        }
        /// <summary>
        /// 安全验证
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidatePassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidatePassword(ValidatePasswordViewModel validatePassword)
        {
            if (ModelState.IsValid)
            {
                if (ValidateCode == validatePassword.ValidateCode.Trim())
                {
                    HttpCookie _cookie = new HttpCookie("EncryptEmail");
                    _cookie.Expires.AddHours(1);
                    _cookie.Value = validatePassword.Email;
                    Response.Cookies.Add(_cookie);

                    return View("~/Views/AverageUser/ResetPassword.cshtml");
                }
                else
                {
                    ModelState.AddModelError("ValidateCode", "您输入的验证码有误");
                }
            }

            return View(validatePassword);
        }
        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (ModelState.IsValid)
            {
                string encryptEmail = Request.Cookies["EncryptEmail"].Value;
                var _user = userService.FindByEmail(encryptEmail);

                _user.Password = DES.EncryStrHexUTF8(resetPassword.ConfirmPassword, _user.UserName);
                if (userService.Update(_user))
                {
                    Notice _notice = new Notice { Title = "修改成功", Details = "恭喜您，密码修改成功", DwellTime = 3, NavigationName = "修改成功", NavigationUrl = @Url.Action("Login") };
                    return RedirectToAction("Notice", "Prompt", _notice);
                }
                else
                {
                    Error _error = new Error { Title = "修改失败", Details = "很遗憾，密码修改失败", Cause = Server.UrlEncode("<li>你在密码修改页停留的时间过久页已经超时</li><li>您绕开客户端验证向服务器提交数据</li>"), Solution = Server.UrlEncode("返回<a href='" + Url.Action("Login", "FindPassword") + "'>修改密码</a>页面，刷新后重新修改") };
                    return RedirectToAction("Error", "Prompt", _error);
                }
            }
            return View(resetPassword);
        }
    }
}
