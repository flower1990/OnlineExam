using Sower.Model;
using Sower.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.Business
{
    /// <summary>
    /// 充值卡服务类
    /// <remarks>
    /// 创建：2015.09.23
    /// </remarks>
    /// </summary>
    public class LearnCardService : BaseService<T_LearnCard>
    {
        public LearnCardService() : base(RepositoryFactory.LearnCardRepository) { }

        public bool Exist(string code)
        {
            return CurrentRepository.Exist(u => u.Code == code);
        }

        public T_LearnCard Find(string code)
        {
            return CurrentRepository.Find(c => c.Code == code);
        }

        /// <summary>
        /// 用户验证【0-成功；1-用户名不存在；2-密码错误；3-用户被禁用】
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWrod"></param>
        /// <returns></returns>
        public int Authentication(string code, string passWrod)
        {
            var _user = CurrentRepository.Find(c => c.Code == code);
            if (_user == null) return 1;
            else if (_user.Password != passWrod) return 2;
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
