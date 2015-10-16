using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.IDataAccess;
using System.Data;
using Sower.CommFunction;
using Sower.Model;

namespace Sower.DataAccess
{
    public class DB_Article : IDB_Article
    {
        /// <summary>
        /// 获取文章信息
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<T_Article> GetArticleModels(string where, string top)
        {
            List<T_Article> articleList = new List<T_Article>();

            string strSql = "select ";
            if (top != "")
            {
                strSql += " top " + top;
            }
            strSql += " * from T_Article ";
            if (where != "")
            {
                strSql += "where 1=1 " + where;
            }
            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(strSql, dt);
            T_Article model = new T_Article();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = new T_Article();
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
                    #endregion
                    articleList.Add(model);
                }

            }
            return articleList;
        }

        /// <summary>
        /// 获取文章详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T_Article GetModel(int Id)
        {
            T_Article model = SqlHelper.SelectSingleEntityInReader<T_Article>("Id=" + Id, "T_Article");
            return model.Id > 0 ? model : null;
        }

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
        public List<T_Article> GetPageArticleModels(int PageSize, int page, string ExamTypeID, string where, bool asc, ref int totocount)
        {
            List<T_Article> articles = new List<T_Article>();

            string contentSqlWhere = "1=1 and ExamTypeID=" + ExamTypeID + " and " + where;
            totocount = SqlHelper.getRowsCount("T_Article", contentSqlWhere);
            string sql = "";
            if (page == 1)
            {
                sql = "select top " + PageSize + " * from T_Article where " + contentSqlWhere;
                sql += " order by Id " + (asc == true ? "asc" : "desc");
            }
            if (page > 1)
            {
                sql = "select top " + PageSize + " * from T_Article where " + contentSqlWhere;
                if (asc)
                {
                    sql += "and Id >(select Max(Id) from(select top " + PageSize * (page = 1) + " Id from T_Article where " + contentSqlWhere + " order by Id asc) tab)";
                }
                else
                {
                    sql += "and Id <(select Min(Id) from(select top " + PageSize * (page = 1) + " Id from T_Article where " + contentSqlWhere + " order by Id Desc) tab)";
                }
                sql += " order by Id " + (asc == true ? "asc" : "desc");
            }

            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(sql, dt);
            T_Article model = new T_Article();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = new T_Article();
                    model = GetModel(int.Parse(dr["Id"].ToString()));
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


        /// <summary>
        /// 判断科目ID是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool isExistsColumnID(string ColumnID)
        {
            bool isexists = false;
            if (SqlHelper.getRowsCount("T_ArticleColumn", "Id="+ColumnID) > 0)
            {
                isexists = true;
            }
            return isexists;
        }

        /// <summary>
        /// 判断文章ID是否存在
        /// </summary>
        /// <param name="articleid"></param>
        /// <returns></returns>
        public bool isExistsArticleId(string articleid)
        {
            bool isexists = false;
            if (SqlHelper.getRowsCount("T_Article", " Id=" + articleid) > 0)
            {
                isexists = true;
            }
            return isexists;
        }

    }
}
