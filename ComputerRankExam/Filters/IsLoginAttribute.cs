using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComputerRankExam.App_Start;

namespace ComputerRankExam.Filters
{
    public class IsLoginAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool Pass = false;
            if (!CheckLogin.IsLogin())
            {
                httpContext.Response.StatusCode = 401;//无权限状态码  
                Pass = false;
            }
            else
            {
                Pass = true;
            }

            return Pass;
        }

        //protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        //{
        //    base.HandleUnauthorizedRequest(context);
        //    if (context.HttpContext.Response.StatusCode == 401)
        //    {
        //        string path = context.HttpContext.Request.Path;
        //        string strUrl = "/Account/Login?returnUrl={0}";

        //        context.HttpContext.Response.Redirect(string.Format(strUrl, HttpUtility.UrlEncode(path)), true);
        //    }
        //}
    }
}