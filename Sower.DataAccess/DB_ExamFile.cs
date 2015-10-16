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
    public class DB_ExamFile : IDB_ExamFile
    {
        public List<T_ExamFile> GetExamFileList(string where, int top)
        {
            List<T_ExamFile> list = new List<T_ExamFile>();
            string sqlstr = "select ";
            if (top > 0)
            {
                sqlstr += " top " + top;
            }
            sqlstr += " * from T_ExamFile where 1=1 and " + where;

            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(sqlstr, dt);
            T_ExamFile model = new T_ExamFile();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = new T_ExamFile();
                    model = GetModel(int.Parse(dr["FileID"].ToString()));
                    list.Add(model);
                }
            }

            return list;
        }

        public T_ExamFile GetModel(int fileId)
        {
            T_ExamFile model = SqlHelper.SelectSingleEntityInReader<T_ExamFile>("FileID=" + fileId, "T_ExamFile");
            return model.FileID > 0 ? model : null;
        }
    }
}
