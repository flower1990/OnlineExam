using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.IDataAccess;

namespace Sower.DataAccess
{
    /// <summary>
    /// 简单工厂
    /// <remarks>创建：2015.09.18</remarks>
    /// </summary>
    public static class RepositoryFactory
    {
        public static InterfaceAverageUserRepository AverageUserRepository
        {
            get
            {
                return new AverageUserRepository();
            }
        }

        public static InterfaceLearnCardRepository LearnCardRepository
        {
            get 
            {
                return new LearnCardRepository();
            }
        }

        public static InterfaceActionLogRepository ActionLogRepository
        {
            get 
            {
                return new ActionLogRepository();
            }
        }
    }
}
