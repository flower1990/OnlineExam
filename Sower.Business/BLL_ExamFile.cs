using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.IDataAccess;
using Sower.Model;

namespace Sower.Business
{
    public class BLL_ExamFile
    {
        private IDB_ExamFile idal = Sower.IDataAccess.DataAccess.CreateIDB_ExamFile();

        /// <summary>
        /// 获取资源文件
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<T_ExamFile> GetExamFileList(string where, int top)
        {
            return idal.GetExamFileList(where, top);
        }

        /// <summary>
        /// 获取资源Model
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public T_ExamFile GetModel(int fileId)
        {
            return idal.GetModel(fileId);
        }
    }
}
