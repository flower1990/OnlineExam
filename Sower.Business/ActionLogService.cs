using Sower.Model;
using Sower.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.Business
{
    /// <summary>
    /// 操作日志服务类
    /// <remarks>
    /// 创建：2015.10.12
    /// </remarks>
    /// </summary>
    public class ActionLogService : BaseService<T_ActionLog>
    {
        public ActionLogService() : base(RepositoryFactory.ActionLogRepository) { }
    }
}
