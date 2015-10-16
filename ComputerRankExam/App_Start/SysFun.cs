using System.Configuration;

namespace ComputerRankExam.App_Start
{
    public class SysFun
    {
        public static int ExamTypID = 2;//模块ID
        public static string title = "计算机等级考试";//站点title
        public static string keywords = "计算机等级考试";//站点关键词
        public static string descripitons = "计算机等级考试";//站点描述
        public static string phone = "0371-63461180";
        public static bool isstartdomain = bool.Parse(ConfigurationManager.AppSettings["isStartCookieDomain"]);
        public static string cookiedomain = ConfigurationManager.AppSettings["cookieDomain"];

        public static string GetFilePath(string filePath)
        {
            string restring = filePath;
            if (!string.IsNullOrEmpty(restring))
            {
                restring.Replace(@"\", "/");
            }
            if (restring.LastIndexOf("/") < restring.Length - 1 && restring.LastIndexOf(@"\") < restring.Length - 1)
            {
                restring = restring + @"/";
            }
            return restring;
        }
    }
}