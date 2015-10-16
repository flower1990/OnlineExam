using ComputerRankExam.Areas.Member.Models;
using ComputerRankExam.Filters;
using Sower.Business;
using Sower.CommFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Member.Controllers
{
    /// <summary>
    /// 卡号设置
    /// <remarks>创建：2015.10.10</remarks>
    /// </summary>
    [IsLogin]
    public class LearnCardController : Controller
    {
        AverageUserService userService = new AverageUserService();
        LearnCardService cardService = new LearnCardService();

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
                var _card = cardService.Find(UserName);
                if (_card.Password == DES.EncryStrHexUTF8(passwordViewModel.OriginalPassword, _card.Code))
                {
                    _card.Password = DES.EncryStrHexUTF8(passwordViewModel.Password, _card.Code);
                    if (cardService.Update(_card)) ModelState.AddModelError("", "修改密码成功");
                    else ModelState.AddModelError("", "修改密码失败");
                }
                else ModelState.AddModelError("", "原密码错误");
            }
            return View(passwordViewModel);
        }
    }
}
