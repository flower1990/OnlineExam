using System.Web;

namespace ComputerRankExam.App_Start
{
    public class CheckLogin
    {
        public static bool IsLogin()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["AverageUser"];
            if (cookie == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static int CookieUserID()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["AverageUser"];
            if (cookie != null)
            {
                return int.Parse(cookie["UserName"]);
            }
            else
            {
                return 0;
            }
        }

        public static string CookieCode()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["AverageUser"];
            if (cookie != null)
            {
                return cookie["Password"].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}