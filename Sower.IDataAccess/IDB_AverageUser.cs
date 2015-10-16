using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.Model;

namespace Sower.IDataAccess
{
    public interface IDB_AverageUser
    {
        /// <summary>
        /// 验证要注册的用户名或者邮箱是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        int IsHaveUserByNameOrEmail(string nameOrEmail, string stype);

        /// <summary>
        /// 登陆时候验证用户名和密码是否正确
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        int Login(string userName, string Password);

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="averageUserID"></param>
        /// <returns></returns>
        T_AverageUser GetUserModel(int averageUserID);


        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UserReg(T_AverageUser model);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int UpdateAverageUser(T_AverageUser user);

    }
}
