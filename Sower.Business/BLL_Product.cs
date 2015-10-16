using Sower.IDataAccess;
using System.Collections.Generic;
using Sower.Model;


namespace Sower.Business
{
    public class BLL_Product
    {
        private IDB_Product idal = Sower.IDataAccess.DataAccess.CreateIDB_Product();

        /// <summary>
        /// 根据搜索条件获取文章信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<T_Product> GetArticleModels(string where, string top)
        {
            return idal.GetProductModels(where, top);
        }

        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T_Product GetModel(int Id)
        {
            return idal.GetModel(Id);
        }

        /// <summary>
        /// 获取文章分页信息
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="page"></param>
        /// <param name="ExamTypeID"></param>
        /// <param name="where"></param>
        /// <param name="asc"></param>
        /// <param name="totocount"></param>
        /// <returns></returns>
        public List<T_Product> GetPageArticleModels(int PageSize, int page, string ExamTypeID, string where, bool asc, ref int totocount)
        {
            return idal.GetPageProductModels(PageSize, page, ExamTypeID, where, asc, ref totocount);
        }

        /// <summary>
        /// 获取栏目名称
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        public string GetColumnTitle(int ColumnID)
        {
            return idal.GetColumnTitle(ColumnID);
        }
    }
}
