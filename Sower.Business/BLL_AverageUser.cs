using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.IDataAccess;
using Sower.Model;

namespace Sower.Business
{
    public class BLL_AverageUser
    {
        private IDB_AverageUser idal = Sower.IDataAccess.DataAccess.CreateIDB_AverageUser();

        /// <summary>
        /// 验证要注册的用户名或者邮箱是否存在
        /// </summary>
        /// <param name="nameOrEmail"></param>
        /// <returns></returns>
        public int IsHaveUserByNameOrEmail(string nameOrEmail,string stype)
        {
            return idal.IsHaveUserByNameOrEmail(nameOrEmail,stype);
        }

        /// <summary>
        /// 登陆时候验证用户名和密码是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int Login(string userName, string Password) 
        {
            return idal.Login(userName, Password);
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="averageUserID"></param>
        /// <returns></returns>
        public T_AverageUser GetUserModel(int averageUserID)
        {
            return idal.GetUserModel(averageUserID);
        }

        /// <summary>
        /// 会员注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UserReg(T_AverageUser model)
        {
            return idal.UserReg(model);
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateAverageUser(T_AverageUser user)
        {
            return idal.UpdateAverageUser(user);
        }
    }
}
