using Sower.IDataAccess;
using Sower.Model;

namespace Sower.Business
{
    public class BLL_ExamType
    {
        private IDB_ExamType idal = Sower.IDataAccess.DataAccess.CreateIDB_ExamType();
        /// <summary>
        /// 获取模块model
        /// </summary>
        /// <param name="examtypeid"></param>
        /// <returns></returns>
        public T_ExamType GetExamType(string examtypeid)
        {
            return idal.GetExamType(examtypeid);
        }
    }
}
