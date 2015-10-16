using ComputerRankExam.App_Start;
using ComputerRankExam.Areas.Member.Models;
using ComputerRankExam.Filters;
using Sower.Business;
using Sower.CommFunction;
using Sower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Member.Controllers
{
    /// <summary>
    /// 个人设置
    /// <remarks>创建：2015.09.18</remarks>
    /// </summary>
    [IsLogin]
    public class AverageUserController : Controller
    {
        AverageUserService userService = new AverageUserService();
        LearnCardService cardService = new LearnCardService();
        PageHelper pageHelper = new PageHelper();

        /// <summary>
        /// 获取用户名
        /// </summary>
        public string UserName
        {
            get
            {
                HttpCookie _cookie = Request.Cookies["AverageUser"];
                if (_cookie == null) return "";
                else return _cookie["UserName"];
            }
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType
        {
            get
            {
                if (CommonUnits.CheckNumber(UserName))
                {
                    return "card";
                }
                else
                {
                    return "user";
                }
            }
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        public string ValidateCode
        {
            get
            {
                HttpCookie _cookie = Request.Cookies["ValidateCode"];
                if (_cookie == null) return "";
                else return _cookie["ValCode"];
            }
        }
        /// <summary>
        /// 显示资料
        /// </summary>
        /// <returns></returns>
        public ActionResult Details()
        {
            var _user = userService.Find(UserName);

            return View(_user);
        }
        /// <summary>
        /// 修改资料
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Modify()
        {
            var _user = userService.Find(UserName);
            if (_user == null) ModelState.AddModelError("", "用户不存在");
            else
            {
                if (TryUpdateModel(_user, new string[] { "RealName", "Sex", "Address", "Phone", "IDNumber" }))
                {
                    if (ModelState.IsValid)
                    {
                        if (userService.Update(_user))
                        {
                            pageHelper.AddLog<T_AverageUser>(ActionLogType.UserModify, _user.AverageUserID, "修改基础信息成功");
                            ModelState.AddModelError("", "修改成功！");
                        }
                        else
                        {
                            ModelState.AddModelError("", "无需要修改的资料");
                        }
                    }
                }
                else
                {
                    pageHelper.AddLog<T_AverageUser>(ActionLogType.UserModify, _user.AverageUserID, "修改基础信息失败");
                    ModelState.AddModelError("", "更新模型数据失败");
                }
            }
            return View("Index", _user);
        }
        /// <summary>
        /// 安全设置
        /// </summary>
        /// <returns></returns>
        public ActionResult SecuritySetting()
        {
            return View();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel passwordViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = userService.Find(UserName);
                if (_user.Password == DES.EncryStrHexUTF8(passwordViewModel.OriginalPassword, _user.UserName))
                {
                    _user.Password = DES.EncryStrHexUTF8(passwordViewModel.Password, _user.UserName);
                    if (userService.Update(_user))
                    {
                        pageHelper.AddLog<T_AverageUser>(ActionLogType.UserModify, _user.AverageUserID, "修改密码成功");
                        ModelState.AddModelError("", "修改密码成功");
                    }
                    else
                    {
                        pageHelper.AddLog<T_AverageUser>(ActionLogType.UserModify, _user.AverageUserID, "修改密码失败");
                        ModelState.AddModelError("", "修改密码失败");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "原密码错误");
                }
            }
            return View(passwordViewModel);
        }
        /// <summary>
        /// 安全问题
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePasswordQuestion()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePasswordQuestion(ChangePasswordQuestionViewMode passwordViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = userService.Find(UserName);
                if (_user.Password == DES.EncryStrHexUTF8(passwordViewModel.Password, _user.UserName))
                {
                    _user.PasswordQuestion = passwordViewModel.PasswordQuestion;
                    _user.PasswordAnswer = passwordViewModel.PasswordAnswer;
                    if (userService.Update(_user))
                    {
                        pageHelper.AddLog<T_AverageUser>(ActionLogType.UserModify, _user.AverageUserID, "修改安全问题成功");
                        ModelState.AddModelError("", "修改成功");
                    }
                    else
                    {
                        pageHelper.AddLog<T_AverageUser>(ActionLogType.UserModify, _user.AverageUserID, "修改安全问题失败");
                        ModelState.AddModelError("", "修改失败");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "登陆密码错误");
                }
            }
            return View(passwordViewModel);
        }
        /// <summary>
        /// 修改邮箱
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangeEmail()
        {
            ChangeEmailViewMode emailViewMode = new ChangeEmailViewMode();

            var _user = userService.Find(UserName);

            emailViewMode.OriginalEmail = CommonUnits.GetEmail(_user.Email);

            return View(emailViewMode);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangeEmail(ChangeEmailViewMode emailViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = userService.Find(UserName);
                if (_user.Email == emailViewModel.ConfirmEmail.Trim())
                {
                    return View("ChangeEmailConfirm");
                }
                else
                {
                    ModelState.AddModelError("", "密保邮箱输入有误");
                }
            }
            return View(emailViewModel);
        }
        public ActionResult ChangeEmailConfirm()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangeEmailConfirm(ChangeEmailConfirmViewMode emailConfirmViewModel)
        {
            var _user = userService.Find(UserName);
            if (_user == null) ModelState.AddModelError("", "用户不存在");
            else
            {
                if (TryUpdateModel(_user, new string[] { "Email" }))
                {
                    if (ModelState.IsValid)
                    {
                        if (ValidateCode.Trim() == emailConfirmViewModel.ValidateCode.Trim())
                        {
                            if (userService.Update(_user))
                            {
                                pageHelper.AddLog<T_AverageUser>(ActionLogType.UserModify, _user.AverageUserID, "修改邮箱成功");
                                ModelState.AddModelError("", "修改成功！");
                                ChangeEmailViewMode emailViewMode = new ChangeEmailViewMode();
                                emailViewMode.OriginalEmail = CommonUnits.GetEmail(emailConfirmViewModel.Email.Trim());
                                return View("ChangeEmail", emailViewMode);
                            }
                            else
                            {
                                ModelState.AddModelError("", "无需要修改的资料");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "验证码输入有误");
                        }
                    }
                }
                else ModelState.AddModelError("", "更新模型数据失败");
            }
            return View("", emailConfirmViewModel);
        }
        public ActionResult ChangeEmailComplete()
        {
            return View();
        }
        public ActionResult SendEmail(ChangeEmailConfirmViewMode emailViewModel)
        {
            Random rd = new Random();
            HttpCookie _cookie = new HttpCookie("ValidateCode");

            int num = rd.Next(100000, 999999);
            _cookie.Expires = DateTime.Now.AddHours(1);
            _cookie.Values.Add("ValCode", num.ToString());
            Response.Cookies.Add(_cookie);

            string content = string.Format("亲爱的用户：您好！感谢您使用朔日测评，您正在进行邮箱验证，本次请求的验证码为：{0}（为了保障您帐号的安全性，请在1小时内完成验证。）", num);
            CommonUnits.SendEmail(emailViewModel.Email, "朔日测评--邮箱身份验证", content);

            return View();
        }

    }
}
