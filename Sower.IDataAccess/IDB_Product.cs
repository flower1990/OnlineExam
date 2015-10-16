using System.Data;
using Sower.Model;
using System.Collections.Generic;

namespace Sower.IDataAccess
{
    public interface IDB_Product
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        List<T_Product> GetProductModels (string where, string top);

        /// <summary>
        /// 获取产品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T_Product GetModel(int Id);

        /// <summary>
        /// 获取分页产品信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="page"></param>
        /// <param name="ExamTypeID"></param>
        /// <param name="where"></param>
        /// <param name="asc"></param>
        /// <param name="totocount"></param>
        /// <returns></returns>
        List<T_Product> GetPageProductModels(int PageSize, int page, string ExamTypeID, string where, bool asc, ref int totocount);


        /// <summary>
        /// 获取栏目名称
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        string GetColumnTitle(int ColumnID);
    }
}
