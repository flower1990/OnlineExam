using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.IDataAccess;
using Sower.Model;
using Sower.CommFunction;
using System.Data;

namespace Sower.DataAccess
{
    public class DB_LearnCard : IDB_LearnCard
    {
        /// <summary>
        /// 登陆学习卡
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int Login(string code, string Password)
        {
            int result = -1;
            string sql = string.Format("select * from T_LearnCard where Code='{0}'", code);
            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(sql, dt);
            if (dt == null || dt.Rows.Count == 0)
            {
                result = -1;
                return result;
            }
            else
            {
                if (dt.Rows[0]["Password"].ToString() != DES.EncryStrHexUTF8(Password, code))
                {
                    result = -2;
                    return result;
                }
                else if ((bool)dt.Rows[0]["Approved"] == false) //卡号被禁用
                {
                    result = -3;
                    return result;
                }
                else
                {
                    //登陆成功 记录登陆日志


                    result = int.Parse(dt.Rows[0]["Id"].ToString());
                    //更新登陆次数
                    string sqlstr = "update T_LearnCard set LoginTimes = (case when LoginTimes is null then 1  when LoginTimes >=0 then LoginTimes+1 end) where Id = '" + result + "'";
                    SqlHelper.ExecuteScalar(sqlstr);
                    return result;
                }
            }
        }

        /// <summary>
        /// 获取卡号信息
        /// </summary>
        /// <param name="CardId"></param>
        /// <returns></returns>
        public T_LearnCard GetCardModel(int CardId)
        {
            T_LearnCard model = SqlHelper.SelectSingleEntityInReader<T_LearnCard>("Id=" + CardId, "T_LearnCard");
            return model.Id > 0 ? model : null;
        }
    }
}
