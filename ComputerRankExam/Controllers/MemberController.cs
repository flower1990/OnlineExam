using ComputerRankExam.Filters;
using ComputerRankExam.Models;
using Sower.Business;
using Sower.CommFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Controllers
{
    public class MemberController : Controller
    {
        BLL_LearnCard bllLearnCard = new BLL_LearnCard();
        BLL_AverageUser bllAverageUser = new BLL_AverageUser();

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

        [IsLoginAttribute]
        public ActionResult MemberInfo()
        {
            bool checkResult = false;

            @ViewBag.CurrentId = "MemberInfo";
            @ViewBag.DisplayTab = "MemberInfo";

            //if (UserName != "")
            //{
            //    checkResult = CommonUnits.CheckNumber(UserName);

            //    if (checkResult)
            //    {
            //        cardRsy = new LearnCardRepository();
            //        var _card = cardRsy.Find(UserName);
            //        return PartialView("~/Views/Member/MemberCardInfo.cshtml", _card);
            //    }
            //    else
            //    {
            //        userRsy = new AverageUserRepository();
            //        var _user = userRsy.Find(UserName);
            //        return PartialView("~/Views/Member/MemberUserInfo.cshtml", _user);
            //    }
            //}

            return View();
        }
        [IsLoginAttribute]
        public ActionResult MemberInfoPartial()
        {
            bool checkResult = false;

            //@ViewBag.CurrentId = "MemberInfo";
            //@ViewBag.DisplayTab = "MemberInfo";

            //if (UserName != "")
            //{
            //    checkResult = CommonUnits.CheckNumber(UserName);

            //    if (checkResult)
            //    {
            //        cardRsy = new LearnCardRepository();
            //        var _card = cardRsy.Find(UserName);
            //        Session.Add("MemberInfo", _card);
            //        return PartialView("~/Views/Member/MemberCardInfoPartial.cshtml", _card);
            //    }
            //    else
            //    {
            //        userRsy = new AverageUserRepository();
            //        var _user = userRsy.Find(UserName);
            //        Session.Add("MemberInfo", _user);
            //        return PartialView("~/Views/Member/MemberUserInfoPartial.cshtml", _user);
            //    }
            //}

            return View();
        }
        [IsLoginAttribute]
        public ActionResult MemberUserUpdate()
        {
            //@ViewBag.CurrentId = "MemberInfo";
            //@ViewBag.DisplayTab = "MemberInfo";

            //T_AverageUser _user = Session["MemberInfo"] as T_AverageUser;

            //return View(_user);
            return null;
        }

        [HttpPost]
        //public ActionResult MemberUserUpdate(T_AverageUser model)
        //{
        //    @ViewBag.CurrentId = "MemberInfo";
        //    @ViewBag.DisplayTab = "MemberInfo";
        //    T_AverageUser averageUser = new T_AverageUser();

        //    if (ModelState.IsValid)
        //    {
        //        averageUser = userRsy.Find(model.AverageUserID);

        //        if (bllAverageUser.IsHaveUserByNameOrEmail(model.Phone, "phone") > 0 && model.Phone != averageUser.Phone)
        //        {
        //            ModelState.AddModelError("averageUser.Phone", "手机已经被注册");
        //            return View(averageUser);
        //        }

        //        if (bllAverageUser.IsHaveUserByNameOrEmail(model.Email, "email") > 0 && model.Email != averageUser.Email)
        //        {
        //            ModelState.AddModelError("averageUser.Email", "邮箱已经被注册");
        //            return View(averageUser);
        //        }

        //        averageUser.RealName = string.IsNullOrEmpty(model.RealName) == true ? "" : model.RealName;
        //        averageUser.Sex = model.Sex;
        //        averageUser.Phone = string.IsNullOrEmpty(model.Phone) == true ? "" : model.Phone;
        //        averageUser.Email = string.IsNullOrEmpty(model.Email) == true ? "" : model.Email;
        //        averageUser.PasswordQuestion = string.IsNullOrEmpty(model.PasswordQuestion) == true ? "" : model.PasswordQuestion;
        //        averageUser.PasswordAnswer = string.IsNullOrEmpty(model.PasswordAnswer) == true ? "" : model.PasswordAnswer;
        //        userRsy.Update(averageUser);

        //        return RedirectToAction("MemberInfo", "Member");
        //    }

        //    return View(averageUser);
        //}
        [IsLoginAttribute]
        public ActionResult Accounting()
        {
            @ViewBag.CurrentId = "Accounting";
            @ViewBag.DisplayTab = "AccountRecharge";
            return View();
        }
        [IsLoginAttribute]
        public ActionResult Computer()
        {
            @ViewBag.CurrentId = "Computer";
            @ViewBag.DisplayTab = "AccountRecharge";
            return View();
        }
        [IsLoginAttribute]
        public ActionResult AccountRecharge()
        {
            @ViewBag.CurrentId = "AccountRecharge";
            @ViewBag.DisplayTab = "AccountRecharge";
            return View();
        }
        [IsLoginAttribute]
        public ActionResult ConsumeQuery()
        {
            @ViewBag.CurrentId = "ConsumeQuery";
            @ViewBag.DisplayTab = "AccountRecharge";
            return View();
        }
    }
}
