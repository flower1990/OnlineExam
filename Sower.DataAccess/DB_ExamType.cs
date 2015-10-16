using Sower.IDataAccess;
using Sower.Model;
using Sower.CommFunction;

namespace Sower.DataAccess
{
    public class DB_ExamType:IDB_ExamType
    {
        /// <summary>
        /// 获取模块model
        /// </summary>
        /// <param name="ExamTypeID"></param>
        /// <returns></returns>
        public T_ExamType GetExamType(string ExamTypeID)
        {
            T_ExamType model = SqlHelper.SelectSingleEntityInReader<T_ExamType>("ExamTypeID=" + ExamTypeID, "T_ExamType");
            return model.ExamTypeID > 0 ? model : null;
        }
    }
}
