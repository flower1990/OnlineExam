
namespace Sower.CommFunction
{
    public class FilterClass
    {
        private static string sqlFileterStr = "delete|drop|select|null|where|sysadmin|db_owner|db_name|cmdshell" +
                                             "|and|exec|insert|update|count|master|truncate|char|declare|" +
                                             "--|net user|xp_cmdshell|add|exec master.dbo.xp_cmdshell|net "+
                                             "localgroup administrators|asc|from|waitfor|delay|ltrim" +
                                             "|drop table|truncate|exec master|netlocalgroup administrators|net user|or|and";
        private static string StrPassWord = @";|[|]|%|{|}|'|+|""";
        /// <summary>
        /// 过滤危险sql字符串
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool FilterSqlStringX(string content)
        {
            string[] pattenString = sqlFileterStr.Split('|');
            string[] pattenRegex = StrPassWord.Split('|');
            foreach (string sqlParam in pattenString)
            {
                if (content.Contains(sqlParam))
                {
                    return true;
                }
            }
            //验证特殊字符
            foreach (string sqlParam in pattenRegex)
            {
                if (content.Contains(sqlParam))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
