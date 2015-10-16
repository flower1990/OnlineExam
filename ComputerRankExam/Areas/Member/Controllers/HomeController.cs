using ComputerRankExam.App_Start;
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
    [IsLogin]
    public class HomeController : Controller
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

        public ActionResult Index()
        {
            @ViewBag.UserType = UserType;
            return View();
        }

        public ActionResult UserInfo()
        {
            var _user = userService.Find(UserName);
            return View(_user);
        }

        public ActionResult CardInfo()
        {
            var _card = cardService.Find(UserName);
            return View(_card);
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies["AverageUser"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-2);
                Response.Cookies.Set(cookie);
            }
            return Redirect(Url.Content("~/"));
        }
    }
}
