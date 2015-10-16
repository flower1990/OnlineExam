using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.Model;
using Sower.IDataAccess;

namespace Sower.Business
{
    public class BLL_UserFeedback
    {
        private IDB_UserFeedback idal = Sower.IDataAccess.DataAccess.CreateIDB_UserFeedback();

        /// <summary>
        /// 获取留言详情
        /// </summary>
        /// <param name="userFeedbackID"></param>
        /// <returns></returns>
        public T_UserFeedback GetModel(int userFeedbackID)
        {
            return idal.GetModel(userFeedbackID);
        }

        /// <summary>
        /// 获取分页留言列表
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
            return idal.GetUserFeedbackListByPage(where, pageIndex, pageSize, orderBy, asc, ref count);
        }

        /// <summary>
        /// 增加留言
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int AddFeedback(T_UserFeedback entity)
        {
            return idal.AddFeedback(entity);
        }

        /// <summary>
        /// 判断是否有未审核的留言信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public int IsNopassMessage(string code)
        {
            return idal.IsNopassMessage(code);
        }
    }
}
