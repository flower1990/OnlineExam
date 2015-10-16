using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.Model;

namespace Sower.IDataAccess
{
    public interface IDB_ExamType
    {
        /// <summary>
        /// 获取模块model
        /// </summary>
        /// <param name="ExamTypeID"></param>
        /// <returns></returns>
        T_ExamType GetExamType(string ExamTypeID);

    }
}
