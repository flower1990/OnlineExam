using System;
using System.Web;
using System.Web.Mvc;
using Sower.CommFunction;
using ComputerRankExam.Models;
using Sower.Business;
using ComputerRankExam.App_Start;

namespace ComputerRankExam.Controllers
{
    public class LoginController : Controller
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
        [ChildActionOnly]
        public ActionResult LoginTop()
        {
            if (UserName != "")
            {
                if (CommonUnits.CheckNumber(UserName))
                {
                    var _card = cardService.Find(UserName);
                    return PartialView("~/Views/Login/LoginTopCardPass.cshtml", _card);
                }
                else
                {
                    var _user = userService.Find(UserName);
                    return PartialView("~/Views/Login/LoginTopUserPass.cshtml", _user);
                }
            }
            else
            {
                return PartialView();
            }
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LoginExit()
        {
            HttpCookie cookie = Request.Cookies["AverageUser"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Set(cookie);

            }
            Notice _n = new Notice
            {
                Title = "成功退出",
                Details = "您已经成功退出！",
                DwellTime = 5,
                NavigationName = "网站首页",
                NavigationUrl = Url.Action("Index", "Home")
            };
            return RedirectToAction("Notice", "Prompt", _n);
        }
    }
}
