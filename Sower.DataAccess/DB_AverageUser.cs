using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.IDataAccess;
using Sower.CommFunction;
using System.Data;
using Sower.Model;
using System.Data.SqlClient;

namespace Sower.DataAccess
{
    public class DB_AverageUser : IDB_AverageUser
    {
        /// <summary>
        /// 验证要注册的用户名或者邮箱是否存在
        /// </summary>
        /// <param name="nameOrEmail"></param>
        /// <returns></returns>
        public int IsHaveUserByNameOrEmail(string nameOrEmail, string type)
        {
            int result = 0;
            string sqlwhere = "";
            if (type == "username")
            {
                sqlwhere += string.Format(" UserName='{0}'", nameOrEmail);
            }
            if (type == "email")
            {
                sqlwhere += string.Format(" Email='{0}'", nameOrEmail);
            }
            if (type == "phone")
            {
                sqlwhere += string.Format(" Phone='{0}'", nameOrEmail);
            }
            result = SqlHelper.getRowsCount("T_AverageUser", sqlwhere);
            return result;

        }
        /// <summary>
        /// 登陆时候验证用户名和密码是否正确 -1:用户名不存在 -2：密码不正确 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int Login(string userName, string Password)
        {
            int result = -1;
            string sql = string.Format("select * from T_AverageUser where UserName='{0}'", userName);
            DataTable dt = new DataTable();
            SqlHelper.FillDataTable(sql, dt);
            if (dt == null || dt.Rows.Count == 0)
            {
                result = -1;
                return result;
            }
            else
            {
                if (dt.Rows[0]["Password"].ToString() != DES.EncryStrHexUTF8(Password, userName))
                {
                    result = -2;
                    return result;
                }
                else if ((bool)dt.Rows[0]["Approved"] == false) //用户被禁用
                {
                    result = -3;
                    return result;
                }
                else
                {
                    //登陆成功 记录登陆日志
                    result = int.Parse(dt.Rows[0]["AverageUserID"].ToString());
                    //更新登陆次数
                    string sqlstr = "update T_AverageUser set LoginTimes=LoginTimes+1 where AverageUserID=" + result;
                    SqlHelper.ExecuteScalar(sqlstr);
                    return result;
                }
            }
        }
        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="averageUserID"></param>
        /// <returns></returns>
        public T_AverageUser GetUserModel(int averageUserID)
        {
            Model.T_AverageUser model = SqlHelper.SelectSingleEntityInReader<Model.T_AverageUser>("AverageUserID=" + averageUserID, "T_AverageUser");
            return model.AverageUserID > 0 ? model : null;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UserReg(Model.T_AverageUser model)
        {
            return SqlHelper.InsertEntity(model, "T_AverageUser", "AverageUserID");
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateAverageUser(T_AverageUser user)
        {
            string sql = "update [T_AverageUser] set [RealName]=@RealName,[Phone]=@Phone,[Email]=@Email,[Sex]=@Sex,[PasswordQuestion]=@PasswordQuestion,[PasswordAnswer]=@PasswordAnswer where [AverageUserID]=@AverageUserID";
            SqlParameter[] param =
            {
                new SqlParameter("@RealName",user.RealName),
                new SqlParameter("@Phone",user.Phone),
                new SqlParameter("@Email",user.Email),
                new SqlParameter("@Sex",user.Sex),
                new SqlParameter("@PasswordQuestion",user.PasswordQuestion),
                new SqlParameter("@PasswordAnswer",user.PasswordAnswer),
                new SqlParameter("@AverageUserID",user.AverageUserID),
            };
            return SqlHelper.ExecuteNonQuery(sql, param);
        }
    }
}
