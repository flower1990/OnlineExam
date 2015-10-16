using System.Data;
using Sower.Model;
using System.Collections.Generic;

namespace Sower.IDataAccess
{
    public interface IDB_Article
    {
        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        List<T_Article> GetArticleModels (string where, string top);

        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T_Article GetModel(int Id);

        /// <summary>
        /// 获取分页文章信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="page"></param>
        /// <param name="ExamTypeID"></param>
        /// <param name="where"></param>
        /// <param name="asc"></param>
        /// <param name="totocount"></param>
        /// <returns></returns>
        List<T_Article> GetPageArticleModels(int PageSize, int page, string ExamTypeID, string where, bool asc, ref int totocount);


        /// <summary>
        /// 获取栏目名称
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        string GetColumnTitle(int ColumnID);

        /// <summary>
        /// 判断科目ID是否存在
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        bool isExistsColumnID(string ColumnID);

        /// <summary>
        /// 判断文章是否存在
        /// </summary>
        /// <param name="articleid"></param>
        /// <returns></returns>
        bool isExistsArticleId(string articleid);
    }
}
