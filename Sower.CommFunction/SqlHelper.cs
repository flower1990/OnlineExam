using System;
using System.Collections.Generic;

using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace Sower.CommFunction
{
    public abstract class SqlHelper
    {
        private static string CONN_STRING = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
       // private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 360000;
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        public static int ExecuteNonQuery(string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }
        public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static SqlDataReader ExecuteReader(string cmdText, params SqlParameter[] cmdParms)
        {
            SqlDataReader tsdr;
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            SqlConnection conn = new SqlConnection(CONN_STRING);
            try
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                tsdr = rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
            return tsdr;
        }

        public static SqlDataReader ExecuteReader(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            SqlDataReader rdr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return rdr;
        }

        public static SqlDataReader ExecuteReader(SqlTransaction tran, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            PrepareCommand(cmd, tran.Connection, tran, cmdType, cmdText, cmdParms);
            SqlDataReader rdr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return rdr;
        }

        public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlDataReader tsdr;
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                tsdr = rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
            return tsdr;
        }
        public static object ExecuteScalar(string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
                object val = cmd.ExecuteScalar();
                return val;
            }
        }
        public static object ExecuteScalar(string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        public static object ExecuteScalar(SqlTransaction tran, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            PrepareCommand(cmd, tran.Connection, tran, cmdType, cmdText, cmdParms);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }


        #region 分页
        public static DataTable GetFenYeDataTable( ref FenYeData fyDataPara)
        {
            string countsql = "select count(" + fyDataPara.PrimaryKey + ") from " + fyDataPara.TableName + "";
            int pageSize = 15;//每页显示记录数
            if (fyDataPara.iPageSize > 0)
            {
                pageSize = fyDataPara.iPageSize;
            }
            int pageIndex = 1;//当前页
            if (fyDataPara.iPageIndex > 0)
            {
                pageIndex = fyDataPara.iPageIndex;
            }

            int recordCount = GetCount(fyDataPara);//获取总记录数
            int pageCount = ((recordCount - 1) / pageSize) + 1;//总页数

            fyDataPara.iTotalRecCount = recordCount;
            fyDataPara.iPageCount = pageCount;

            SqlParameter[] pars = new SqlParameter[] {
                 new SqlParameter("@tableName",fyDataPara.TableName),
                 new SqlParameter("@primaryKey",fyDataPara.PrimaryKey),
                 new SqlParameter("@orderKey",fyDataPara.OrderKey),
                 new SqlParameter("@orderType",fyDataPara.OrderType),
                 new SqlParameter("@allCount",fyDataPara.iTotalRecCount),
                 new SqlParameter("@pageCount",fyDataPara.iPageCount),
                 new SqlParameter("@pageIndex",fyDataPara.iPageIndex),
                 new SqlParameter("@pageSize",fyDataPara.iPageSize),
                 new SqlParameter("@strWhere",fyDataPara.SearchCondition),
                 new SqlParameter("@strGetFields",fyDataPara.GetFields)
            };

            DataTable dt = new DataTable();
            DataSet ds = RunProcedure("P_GetRecordByPage", pars, "ds");
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }


        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {

            SqlCommand cmd = new SqlCommand(storedProcName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
            return cmd;
        }
        public static int GetCount(FenYeData fyDataPara)
        {
            int rint = 0;
            string countsql = "select count(" + fyDataPara.PrimaryKey + ") from " + fyDataPara.TableName + "";
            if (!string.IsNullOrEmpty(fyDataPara.SearchCondition))
            {
                countsql += " where " + fyDataPara.SearchCondition;
            }

            object intObj = GetSingle(countsql);
            if (intObj != null && intObj != DBNull.Value)
            {
                rint = Convert.ToInt32(intObj);
            }
            return rint;

        } 
        #endregion

        public static bool Exists(string cmdText, params SqlParameter[] cmdParms)
        {
            int iCount = 0;
            object obj = ExecuteScalar(cmdText, cmdParms);
            if (obj.ToString() != "")
            {
                iCount = Convert.ToInt32(obj.ToString());
            }
            if (0 == iCount)
            {
                return false;
            }
            return true;
        }
        public static bool Exists(string cmdText)
        {
           
           return Exists(cmdText,null);
        }
        public static void FillDataSet(string cmdText, DataSet ds, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParms);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(ds);
                ada.Dispose();
            }
        }

        public static void FillDataTable(string cmdText, DataTable dt, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, cmdParms);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                ada.Dispose();
            }
        }
        public static void FillDataTable(string cmdText, DataTable dt)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                ada.Dispose();
            }
        }

        public static void FillDataTable(string cmdText, CommandType cmdType, DataTable dt, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                ada.Dispose();
            }
        }

        public static void FillDataTable(SqlTransaction tran, CommandType cmdType, string cmdText, DataTable dt, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.CommandTimeout = 360000;
            PrepareCommand(cmd, tran.Connection, tran, cmdType, cmdText, cmdParms);
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.Fill(dt);
            ada.Dispose();
        }


        private static string getMaxID(string strTableName, string strFields, string strKey, string strWhere, int currentPage, int pageSize)
        {
            int iTop = 0;
            iTop = (currentPage - 1) * pageSize;
            return ExecuteScalar("select max(" + strKey + ") from select top " + iTop.ToString() + " " + strKey + " from " + strTableName + " where " + strWhere, null).ToString();
        }

        public static int getRowsCount(string strTableName, string strWhere)
        {
            string strSql = string.Empty;
            strSql = "select count(1) from " + strTableName;
            if (strWhere != "")
            {
                strSql = strSql + " where " + strWhere;
            }
            return (Convert.ToInt32(ExecuteScalar(strSql, null).ToString()));
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

        public static string strConn
        {
            get
            {
                return CONN_STRING;
            }
        }

        public static void ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }

        public static void ExecuteNonQuery(string p, string[] value)
        {
            throw new NotImplementedException();
        }




        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataTable Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(dt);
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return dt;
            }
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="tableName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int InsertEntity(object Entity, string tableName, string key)
        {
            DataTable dt = Query("select * from " + tableName + " where 1=2");
            DataColumnCollection dataColumns = dt.Columns;
            int id = 0;
            string sqlClomun = "";
            string sqlParams = "";
            List<SqlParameter> list = new List<SqlParameter>();
            Type type = Entity.GetType();
            PropertyInfo[] props = type.GetProperties();

            foreach (var item in props)
            {
                if (dataColumns.Contains(item.Name))
                {
                    if (item.Name == key)
                    {
                        continue;
                    }
                    sqlClomun += item.Name + " , ";
                    sqlParams += "@" + item.Name + " , ";
                    list.Add(new SqlParameter("@" + item.Name, item.GetValue(Entity, null)));
                }
            }
            if (sqlClomun.LastIndexOf(",") > 0)
            {
                sqlClomun = sqlClomun.Remove(sqlClomun.LastIndexOf(","));
            }
            if (sqlParams.LastIndexOf(",") > 0)
            {
                sqlParams = sqlParams.Remove(sqlParams.LastIndexOf(","));
            }
            string sql = "insert into " + tableName + " ( " + sqlClomun + " ) values ( " + sqlParams + " ); select @@IDENTITY";

            object objid = GetSingle(sql, list.ToArray());
            if (objid != null && objid != DBNull.Value)
            {
                id = Convert.ToInt32(objid);
            }
            return id;
        }


        public static T SelectSingleEntityInReader<T>(string where, string tableName) where T : class, new()
        {
            T obj = new T();
            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();
            string sqlcolums = GetColumnString(type);
            using (SqlDataReader dr = ExecuteReader("select " + sqlcolums + " from " + tableName + " where " + where))
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        DataTable dt = dr.GetSchemaTable();
                        List<string> cols = new List<string>();
                        foreach (DataRow item in dt.Rows)
                        {
                            cols.Add(item[0].ToString());
                        }
                        foreach (PropertyInfo prop in props)
                        {
                            if (prop.CanWrite && cols.Contains(prop.Name))
                            {
                                if (dr[prop.Name] != DBNull.Value)
                                {
                                    prop.SetValue(obj, dr[prop.Name], null);
                                }
                            }
                        }
                    }
                }
            }
            return obj;

        }

        public static string GetColumnString(Type type)
        {
            string sqlClomun = "";
            PropertyInfo[] props = type.GetProperties();
            foreach (var item in props)
            {
                if (IsBaseType(item.PropertyType))
                {
                    sqlClomun += item.Name + " , ";
                }

            }
            if (sqlClomun.LastIndexOf(",") > 0)
            {
                sqlClomun = sqlClomun.Remove(sqlClomun.LastIndexOf(","));
            }

            return sqlClomun;
        }
        public static bool IsBaseType(Type type)
        {
            bool rebool = false;
            if (type.Equals(typeof(int)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Int32)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Int64)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(string)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(String)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(bool)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Boolean)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(DateTime)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(double)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(float)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(decimal)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Decimal)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(double)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Double)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(char)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Char)))
            {
                rebool = true;
            }
            if (type.Equals(typeof(Guid)))
            {
                rebool = true;
            }
            //if (type.Equals(typeof(ActionLogType)))
            //{
            //    rebool = true;
            //}
            //if (type.Equals(typeof(UserRoleType)))
            //{
            //    rebool = true;
            //}
            return rebool;
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }
        public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}
