using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.IDataAccess;
using Sower.Model;

namespace Sower.Business
{
    public class BLL_LearnCard
    {
        private IDB_LearnCard idal = Sower.IDataAccess.DataAccess.CreateIDB_LearnCard();

        /// <summary>
        /// 卡号登陆
        /// </summary>
        /// <param name="code"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int Login(string code, string Password)
        {
            return idal.Login(code, Password);
        }

        /// <summary>
        /// 获取卡号Model
        /// </summary>
        /// <param name="CardId"></param>
        /// <returns></returns>
        public T_LearnCard GetCardModel(int CardId)
        {
            return idal.GetCardModel(CardId);
        }
    }
}
