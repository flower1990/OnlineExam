using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.IDataAccess;
using Sower.Model;
using System.Data;
using Sower.CommFunction;

namespace Sower.DataAccess
{
    public class DB_Product:IDB_Product
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<T_Product> GetProductModels(string where, string top)
        {
            List<T_Product> ProductList = new List<T_Product>();

            string strSql = "select ";
            if (top != "")
            {
                strSql += " top " + top;
            }
            strSql += " * from T_Product ";
            if (where != "")
            {
                strSql += "where 1=1 " + where;
            }
            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(strSql, dt);
            T_Product model = new T_Product();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = new T_Product();
                    #region Model

                    if (dr["Id"].ToString() != "" || dr["Id"] != DBNull.Value)
                    {
                        model.Id = Convert.ToInt32(dr["Id"]);
                    }
                    if (dr["ColumnId"].ToString() != "" || dr["ColumnId"] != DBNull.Value)
                    {
                        model.ColumnId = int.Parse(dr["ColumnId"].ToString());
                    }
                    if (dr["ColumnId"].ToString() != "" || dr["ColumnId"] != DBNull.Value)
                    {
                        model.ColumnId = int.Parse(dr["ColumnId"].ToString());
                    }
                    if (dr["ColumnTitle"].ToString() != "" || dr["ColumnTitle"] != DBNull.Value)
                    {
                        model.ColumnTitle = dr["ColumnTitle"].ToString();
                    }
                    if (dr["Title"].ToString() != "" || dr["Title"] != DBNull.Value)
                    {
                        model.Title = dr["Title"].ToString();
                    }
                    if (dr["SubTitle"].ToString() != "" || dr["SubTitle"] != DBNull.Value)
                    {
                        model.SubTitle = dr["SubTitle"].ToString();
                    }
                    if (dr["Thumbnail"].ToString() != "" || dr["Thumbnail"] != DBNull.Value)
                    {
                        model.Thumbnail = dr["Thumbnail"].ToString();
                    }
                    if (dr["Description"].ToString() != "" || dr["Description"] != DBNull.Value)
                    {
                        model.Description = dr["Description"].ToString();
                    }
                    if (dr["Keyword"].ToString() != "" || dr["Keyword"] != DBNull.Value)
                    {
                        model.Keyword = dr["Keyword"].ToString();
                    }
                    if (dr["Content"].ToString() != "" || dr["Content"] != DBNull.Value)
                    {
                        model.Content = dr["Content"].ToString();
                    }
                    if (dr["Clicks"].ToString() != "" || dr["Clicks"] != DBNull.Value)
                    {
                        model.Clicks = int.Parse(dr["Clicks"].ToString());
                    }
                    if (dr["Source"].ToString() != "" || dr["Source"] != DBNull.Value)
                    {
                        model.Source = dr["Source"].ToString();
                    }
                    if (dr["Quote"].ToString() != "" || dr["Quote"] != DBNull.Value)
                    {
                        model.Quote = dr["Quote"].ToString();
                    }
                    if (dr["Annex"].ToString() != "" || dr["Annex"] != DBNull.Value)
                    {
                        model.Annex = dr["Annex"].ToString();
                    }
                    if (dr["Publisher"].ToString() != "" || dr["Publisher"] != DBNull.Value)
                    {
                        model.Publisher = dr["Publisher"].ToString();
                    }
                    if (dr["IsValid"].ToString() != "" || dr["IsValid"] != DBNull.Value)
                    {
                        model.IsValid = bool.Parse(dr["IsValid"].ToString());
                    }
                    if (dr["CreateTime"].ToString() != "" || dr["CreateTime"] != DBNull.Value)
                    {
                        model.CreateTime = Convert.ToDateTime(dr["CreateTime"].ToString());
                    }
                    if (dr["ModifyTime"].ToString() != "" || dr["ModifyTime"] != DBNull.Value)
                    {
                        model.ModifyTime = Convert.ToDateTime(dr["ModifyTime"].ToString());
                    }
                    if (dr["ExamTypeID"].ToString() != "" || dr["ExamTypeID"] != DBNull.Value)
                    {
                        model.ExamTypeID = int.Parse(dr["ExamTypeID"].ToString());
                    }
                    if (dr["ExamTypeName"].ToString() != "" || dr["ExamTypeName"] != DBNull.Value)
                    {
                        model.ExamTypeName = dr["ExamTypeName"].ToString();
                    }
                    if (dr["beta"].ToString() != "" || dr["beta"] != DBNull.Value)
                    {
                        model.beat = dr["beta"].ToString();
                    }
                    if (dr["Price"].ToString() != "" || dr["Price"] != DBNull.Value)
                    {
                        model.Price = decimal.Parse(dr["Price"].ToString());
                    }
                    #endregion
                    ProductList.Add(model);
                }

            }
            return ProductList;
        }

        /// <summary>
        /// 获取产品Model
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T_Product GetModel(int Id)
        {
            string sql = "select * from T_Product where Id=" + Id;
            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(sql, dt);
            T_Product model = new T_Product();
            if (dt != null && dt.Rows.Count > 0)
            {
                #region Model

                if (dt.Rows[0]["Id"].ToString() != "" || dt.Rows[0]["Id"] != DBNull.Value)
                {
                    model.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                }
                if (dt.Rows[0]["ColumnId"].ToString() != "" || dt.Rows[0]["ColumnId"] != DBNull.Value)
                {
                    model.ColumnId = int.Parse(dt.Rows[0]["ColumnId"].ToString());
                }
                if (dt.Rows[0]["ColumnId"].ToString() != "" || dt.Rows[0]["ColumnId"] != DBNull.Value)
                {
                    model.ColumnId = int.Parse(dt.Rows[0]["ColumnId"].ToString());
                }
                if (dt.Rows[0]["ColumnTitle"].ToString() != "" || dt.Rows[0]["ColumnTitle"] != DBNull.Value)
                {
                    model.ColumnTitle = dt.Rows[0]["ColumnTitle"].ToString();
                }
                if (dt.Rows[0]["Title"].ToString() != "" || dt.Rows[0]["Title"] != DBNull.Value)
                {
                    model.Title = dt.Rows[0]["Title"].ToString();
                }
                if (dt.Rows[0]["SubTitle"].ToString() != "" || dt.Rows[0]["SubTitle"] != DBNull.Value)
                {
                    model.SubTitle = dt.Rows[0]["SubTitle"].ToString();
                }
                if (dt.Rows[0]["Thumbnail"].ToString() != "" || dt.Rows[0]["Thumbnail"] != DBNull.Value)
                {
                    model.Thumbnail = dt.Rows[0]["Thumbnail"].ToString();
                }
                if (dt.Rows[0]["Description"].ToString() != "" || dt.Rows[0]["Description"] != DBNull.Value)
                {
                    model.Description = dt.Rows[0]["Description"].ToString();
                }
                if (dt.Rows[0]["Keyword"].ToString() != "" || dt.Rows[0]["Keyword"] != DBNull.Value)
                {
                    model.Keyword = dt.Rows[0]["Keyword"].ToString();
                }
                if (dt.Rows[0]["Content"].ToString() != "" || dt.Rows[0]["Content"] != DBNull.Value)
                {
                    model.Content = dt.Rows[0]["Content"].ToString();
                }
                if (dt.Rows[0]["Clicks"].ToString() != "" || dt.Rows[0]["Clicks"] != DBNull.Value)
                {
                    model.Clicks = int.Parse(dt.Rows[0]["Clicks"].ToString());
                }
                if (dt.Rows[0]["Source"].ToString() != "" || dt.Rows[0]["Source"] != DBNull.Value)
                {
                    model.Source = dt.Rows[0]["Source"].ToString();
                }
                if (dt.Rows[0]["Quote"].ToString() != "" || dt.Rows[0]["Quote"] != DBNull.Value)
                {
                    model.Quote = dt.Rows[0]["Quote"].ToString();
                }
                if (dt.Rows[0]["Annex"].ToString() != "" || dt.Rows[0]["Annex"] != DBNull.Value)
                {
                    model.Annex = dt.Rows[0]["Annex"].ToString();
                }
                if (dt.Rows[0]["Publisher"].ToString() != "" || dt.Rows[0]["Publisher"] != DBNull.Value)
                {
                    model.Publisher = dt.Rows[0]["Publisher"].ToString();
                }
                if (dt.Rows[0]["IsValid"].ToString() != "" || dt.Rows[0]["IsValid"] != DBNull.Value)
                {
                    model.IsValid = bool.Parse(dt.Rows[0]["IsValid"].ToString());
                }
                if (dt.Rows[0]["CreateTime"].ToString() != "" || dt.Rows[0]["CreateTime"] != DBNull.Value)
                {
                    model.CreateTime = Convert.ToDateTime(dt.Rows[0]["CreateTime"].ToString());
                }
                if (dt.Rows[0]["ModifyTime"].ToString() != "" || dt.Rows[0]["ModifyTime"] != DBNull.Value)
                {
                    model.ModifyTime = Convert.ToDateTime(dt.Rows[0]["ModifyTime"].ToString());
                }
                if (dt.Rows[0]["ExamTypeID"].ToString() != "" || dt.Rows[0]["ExamTypeID"] != DBNull.Value)
                {
                    model.ExamTypeID = int.Parse(dt.Rows[0]["ExamTypeID"].ToString());
                }
                if (dt.Rows[0]["ExamTypeName"].ToString() != "" || dt.Rows[0]["ExamTypeName"] != DBNull.Value)
                {
                    model.ExamTypeName = dt.Rows[0]["ExamTypeName"].ToString();
                }
                if (dt.Rows[0]["beta"].ToString() != "" || dt.Rows[0]["beta"] != DBNull.Value)
                {
                    model.beat = dt.Rows[0]["beta"].ToString();
                }
                if (dt.Rows[0]["Price"].ToString() != "" || dt.Rows[0]["Price"] != DBNull.Value)
                {
                    model.Price = decimal.Parse(dt.Rows[0]["Price"].ToString());
                }
                #endregion

                return model;
            }
            else
            {
                return null;
            }
        }

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
        public List<T_Product> GetPageProductModels(int PageSize, int page, string ExamTypeID, string where, bool asc, ref int totocount)
        {
            List<T_Product> articles = new List<T_Product>();

            string contentSqlWhere = "1=1 and ExamTypeID=" + ExamTypeID + " and " + where;
            totocount = SqlHelper.getRowsCount("T_Product", contentSqlWhere);
            string sql = "";
            if (page == 1)
            {
                sql = "select top " + PageSize + " * from T_Product where " + contentSqlWhere;
                sql += " order by Id " + (asc == true ? "asc" : "desc");
            }
            if (page > 1)
            {
                sql = "select top " + PageSize + " * from T_Product where " + contentSqlWhere;
                if (asc)
                {
                    sql += "and Id >(select Max(Id) from(select top " + PageSize * (page = 1) + " Id from T_Product where " + contentSqlWhere + " order by Id asc) tab)";
                }
                else
                {
                    sql += "and Id <(select Min(Id) from(select top " + PageSize * (page = 1) + " Id from T_Product where " + contentSqlWhere + " order by Id Desc) tab)";
                }
                sql += " order by Id " + (asc == true ? "asc" : "desc");
            }

            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(sql, dt);
            T_Product model = new T_Product();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = new T_Product();
                    #region Model

                    if (dr["Id"].ToString() != "" || dr["Id"] != DBNull.Value)
                    {
                        model.Id = Convert.ToInt32(dr["Id"]);
                    }
                    if (dr["ColumnId"].ToString() != "" || dr["ColumnId"] != DBNull.Value)
                    {
                        model.ColumnId = int.Parse(dr["ColumnId"].ToString());
                    }
                    if (dr["ColumnId"].ToString() != "" || dr["ColumnId"] != DBNull.Value)
                    {
                        model.ColumnId = int.Parse(dr["ColumnId"].ToString());
                    }
                    if (dr["ColumnTitle"].ToString() != "" || dr["ColumnTitle"] != DBNull.Value)
                    {
                        model.ColumnTitle = dr["ColumnTitle"].ToString();
                    }
                    if (dr["Title"].ToString() != "" || dr["Title"] != DBNull.Value)
                    {
                        model.Title = dr["Title"].ToString();
                    }
                    if (dr["SubTitle"].ToString() != "" || dr["SubTitle"] != DBNull.Value)
                    {
                        model.SubTitle = dr["SubTitle"].ToString();
                    }
                    if (dr["Thumbnail"].ToString() != "" || dr["Thumbnail"] != DBNull.Value)
                    {
                        model.Thumbnail = dr["Thumbnail"].ToString();
                    }
                    if (dr["Description"].ToString() != "" || dr["Description"] != DBNull.Value)
                    {
                        model.Description = dr["Description"].ToString();
                    }
                    if (dr["Keyword"].ToString() != "" || dr["Keyword"] != DBNull.Value)
                    {
                        model.Keyword = dr["Keyword"].ToString();
                    }
                    if (dr["Content"].ToString() != "" || dr["Content"] != DBNull.Value)
                    {
                        model.Content = dr["Content"].ToString();
                    }
                    if (dr["Clicks"].ToString() != "" || dr["Clicks"] != DBNull.Value)
                    {
                        model.Clicks = int.Parse(dr["Clicks"].ToString());
                    }
                    if (dr["Source"].ToString() != "" || dr["Source"] != DBNull.Value)
                    {
                        model.Source = dr["Source"].ToString();
                    }
                    if (dr["Quote"].ToString() != "" || dr["Quote"] != DBNull.Value)
                    {
                        model.Quote = dr["Quote"].ToString();
                    }
                    if (dr["Annex"].ToString() != "" || dr["Annex"] != DBNull.Value)
                    {
                        model.Annex = dr["Annex"].ToString();
                    }
                    if (dr["Publisher"].ToString() != "" || dr["Publisher"] != DBNull.Value)
                    {
                        model.Publisher = dr["Publisher"].ToString();
                    }
                    if (dr["IsValid"].ToString() != "" || dr["IsValid"] != DBNull.Value)
                    {
                        model.IsValid = bool.Parse(dr["IsValid"].ToString());
                    }
                    if (dr["CreateTime"].ToString() != "" || dr["CreateTime"] != DBNull.Value)
                    {
                        model.CreateTime = Convert.ToDateTime(dr["CreateTime"].ToString());
                    }
                    if (dr["ModifyTime"].ToString() != "" || dr["ModifyTime"] != DBNull.Value)
                    {
                        model.ModifyTime = Convert.ToDateTime(dr["ModifyTime"].ToString());
                    }
                    if (dr["ExamTypeID"].ToString() != "" || dr["ExamTypeID"] != DBNull.Value)
                    {
                        model.ExamTypeID = int.Parse(dr["ExamTypeID"].ToString());
                    }
                    if (dr["ExamTypeName"].ToString() != "" || dr["ExamTypeName"] != DBNull.Value)
                    {
                        model.ExamTypeName = dr["ExamTypeName"].ToString();
                    }
                    if (dr["beta"].ToString() != "" || dr["beta"] != DBNull.Value)
                    {
                        model.beat = dr["beta"].ToString();
                    }
                    if (dr["Price"].ToString() != "" || dr["Price"] != DBNull.Value)
                    {
                        model.Price = decimal.Parse(dr["Price"].ToString());
                    }
                    #endregion
                    articles.Add(model);
                }

            }
            return articles;
        }

        /// <summary>
        /// 获取栏目名称
        /// </summary>
        /// <param name="ColumnID"></param>
        /// <returns></returns>
        public string GetColumnTitle(int ColumnID)
        {
            string sql = "select Title from T_ArticleColumn where Id=" + ColumnID;
            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(sql, dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
