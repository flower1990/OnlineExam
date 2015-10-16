using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace Sower.DataAccess
{
    /// <summary>
    /// 上下文简单工厂
    /// <remarks>
    /// 创建：2015.09.18
    /// </remarks>
    /// </summary>
    class ContextFactory
    {
        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static SowerDbContext GetCurrentContext()
        {
            SowerDbContext _nContext = CallContext.GetData("SowerContext") as SowerDbContext;
            if (_nContext == null)
            {
                _nContext = new SowerDbContext();
                CallContext.SetData("SowerContext", _nContext);
            }
            return _nContext;
        }
    }
}
