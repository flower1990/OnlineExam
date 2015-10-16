using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sower.Model;
using Sower.DataAccess;

namespace Sower.Business
{
    /// <summary>
    /// 用户服务类
    /// <remarks>
    /// 创建：2015.09.18
    /// </remarks>
    /// </summary>
    public class AverageUserService : BaseService<T_AverageUser>
    {
        public AverageUserService() : base(RepositoryFactory.AverageUserRepository) { }

        //public ClaimsIdentity CreateIdentity(User user, string authenticationType)
        //{
        //    ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
        //    _identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
        //    _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));
        //    _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
        //    _identity.AddClaim(new Claim("DisplayName", user.DisplayName));
        //    return _identity;
        //}

        public bool Exist(string userName)
        {
            return CurrentRepository.Exist(u => u.UserName == userName);
        }

        public T_AverageUser Find(string userName)
        {
            return CurrentRepository.Find(u => u.UserName == userName);
        }

        public T_AverageUser FindByEmail(string email)
        {
            return CurrentRepository.Find(u => u.Email == email);
        }

        public IQueryable<T_AverageUser> FindPageList(out int totalRecord, int pageIndex, int pageSize, int order)
        {
            IQueryable<T_AverageUser> _users = CurrentRepository.Entities;
            switch (order)
            {
                case 0:
                    _users = _users.OrderBy(c => c.AverageUserID);
                    break;
                case 1:
                    _users = _users.OrderByDescending(c => c.AverageUserID);
                    break;
                case 2:
                    _users = _users.OrderBy(c => c.CreateTime);
                    break;
                case 3:
                    _users = _users.OrderByDescending(c => c.CreateTime);
                    break;
                case 4:
                    _users = _users.OrderBy(c => c.ModifyTime);
                    break;
                case 5:
                    _users = _users.OrderByDescending(c => c.ModifyTime);
                    break;
                default:
                    _users = _users.OrderByDescending(c => c.AverageUserID);
                    break;
            }
            totalRecord = _users.Count();
            return PageList(_users, pageIndex, pageSize);
        }

        /// <summary>
        /// 用户验证【0-成功；1-用户名不存在；2-密码错误；3-用户被禁用】
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWrod"></param>
        /// <returns></returns>
        public int Authentication(string UserName, string PassWrod)
        {
            var _user = CurrentRepository.Find(u => u.UserName == UserName);
            if (_user == null) return 1;
            else if (_user.Password != PassWrod) return 2;
            else if (_user.Approved == false) return 3;
            else
            {
                _user.LoginTimes += 1;
                _user.ModifyTime = DateTime.Now;
                Update(_user);
                return 0;
            }
        }
    }
}
