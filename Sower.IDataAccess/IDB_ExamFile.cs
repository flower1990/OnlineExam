using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.Model;

namespace Sower.IDataAccess
{
    public interface IDB_ExamFile
    {
        /// <summary>
        /// 获取资源文件
        /// </summary>
        /// <param name="where"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        List<T_ExamFile> GetExamFileList(string where, int top);


        /// <summary>
        /// 获取model
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        T_ExamFile GetModel(int fileId);
    }
}
