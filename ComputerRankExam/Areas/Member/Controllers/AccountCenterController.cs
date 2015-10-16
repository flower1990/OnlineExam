using ComputerRankExam.App_Start;
using ComputerRankExam.Areas.Member.Models;
using ComputerRankExam.Filters;
using Sower.Business;
using Sower.CommFunction;
using Sower.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Member.Controllers
{
    /// <summary>
    /// 账户中心
    /// <remarks>创建：2015.10.10</remarks>
    /// </summary>
    [IsLogin]
    public class AccountCenterController : Controller
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

        //
        // GET: /Member1/AccountCenter/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LearnCardRecharge()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LearnCardRecharge(LearnCardRechargeViewMode learnCardViewMode)
        {
            if (ModelState.IsValid)
            {
                //验证验证码
                if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() == "")
                {
                    ModelState.AddModelError("VerificationCode", "验证码错误");
                    return View(learnCardViewMode);
                }
                else if (TempData["VerificationCode"].ToString() != learnCardViewMode.VerificationCode.Trim().ToUpper())
                {
                    ModelState.AddModelError("VerificationCode", "验证码错误");
                    return View(learnCardViewMode);
                }

                var _card = cardService.Find(learnCardViewMode.LearnCard);
                if (_card.Approved == false)
                {
                    ModelState.AddModelError("", "充值卡无效");
                    return View(learnCardViewMode);
                }
                if (_card.Password != DES.EncryStrHexUTF8(learnCardViewMode.Password, _card.Code))
                {
                    ModelState.AddModelError("", "充值密码错误");
                    return View(learnCardViewMode);
                }

                var _user = userService.Find(UserName); 
                _user.Cach += _card.CardPrice;
                _card.Approved = false;
                if (userService.Update(_user) && cardService.Update(_card))
                {
                    pageHelper.AddLog<T_AverageUser>(ActionLogType.LearnCardRecharge, _user.AverageUserID, "充值成功" + _user.UserName);
                    ModelState.AddModelError("", "充值成功");
                }
                else
                {
                    pageHelper.AddLog<T_AverageUser>(ActionLogType.LearnCardRecharge, _user.AverageUserID, "充值失败" + _user.UserName);
                    ModelState.AddModelError("", "充值失败");
                }
            }
            return View(learnCardViewMode);
        }
    }
}
