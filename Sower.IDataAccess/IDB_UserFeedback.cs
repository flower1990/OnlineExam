using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.Model;

namespace Sower.IDataAccess
{
    public interface IDB_UserFeedback
    {
        /// <summary>
        /// 获取单个留言信息
        /// </summary>
        /// <param name="userFeedbackID"></param>
        /// <returns></returns>
        T_UserFeedback GetModel(int userFeedbackID);


        /// <summary>
        /// 获取分页留言信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderBy"></param>
        /// <param name="asc"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<T_UserFeedback> GetUserFeedbackListByPage(string where, int pageIndex, int pageSize, string orderBy, bool asc, ref int count);

        /// <summary>
        /// 增加留言
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int AddFeedback(T_UserFeedback entity);

        /// <summary>
        /// 判断是否有未审核的留言信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        int IsNopassMessage(string code);
    }
}
