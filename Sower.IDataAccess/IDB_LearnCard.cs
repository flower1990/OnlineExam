using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.Model;

namespace Sower.IDataAccess
{
    public interface IDB_LearnCard
    {
        /// <summary>
        /// 卡号登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        int Login(string userName, string Password);


        /// <summary>
        /// 获取卡号信息
        /// </summary>
        /// <param name="CardId"></param>
        /// <returns></returns>
        T_LearnCard GetCardModel(int CardId);
    }
}
