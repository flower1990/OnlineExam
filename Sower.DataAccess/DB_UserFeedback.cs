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
    public class DB_UserFeedback : IDB_UserFeedback
    {
        /// <summary>
        /// 获取留言详情
        /// </summary>
        /// <param name="userFeedbackID"></param>
        /// <returns></returns>
        public T_UserFeedback GetModel(int userFeedbackID)
        {
            T_UserFeedback model = SqlHelper.SelectSingleEntityInReader<T_UserFeedback>("UserFeedbackID=" + userFeedbackID, "T_UserFeedback");
            return model.UserFeedbackID > 0 ? model : null;
        }

        /// <summary>
        /// 获取分页留言
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="asc"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<T_UserFeedback> GetUserFeedbackListByPage(string where, int pageIndex, int pageSize, string orderBy, bool asc, ref int count)
        {
            FenYeData fy = new FenYeData()
            {
                iPageIndex = pageIndex,
                iPageSize = pageSize,
                OrderKey = orderBy,
                OrderType = asc,
                PrimaryKey = "UserFeedbackID",
                SearchCondition = where,
                TableName = "T_UserFeedback",
                GetFields = SqlHelper.GetColumnString(typeof(T_UserFeedback))
            };
            DataTable dt = SqlHelper.GetFenYeDataTable(ref fy);
            count = fy.iTotalRecCount;
            List<T_UserFeedback> list = new List<T_UserFeedback>();

            T_UserFeedback model = new T_UserFeedback();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = new T_UserFeedback();
                    model = GetModel(int.Parse(dr[0].ToString()));
                    list.Add(model);
                }
            }


            return list;
        }

        /// <summary>
        /// 增加留言
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int AddFeedback(T_UserFeedback entity)
        {
            return SqlHelper.InsertEntity(entity, "T_UserFeedback", "UserFeedbackID");
        }

        /// <summary>
        /// 判断是否有未审核的留言信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsNopassMessage(string code)
        {
            return SqlHelper.getRowsCount("T_UserFeedback", " UserCode='" + code + "'");
        }
    }
}
