using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.CommFunction
{
    public class ActionLogType
    {
        /// <summary>
        /// //系统错误
        /// </summary>
        public const int ApplicationError = 0;
        /// <summary>
        /// 用户登录
        /// </summary>
        public const int UserLogin = 1;
        /// <summary>
        /// 用户退出
        /// </summary>
        public const int UserLogOff = 2;
        /// <summary>
        /// //管理员操作
        /// </summary>
        public const int ManagerAction = 3;
        /// <summary>
        /// 管理员添加操作
        /// </summary>
        public const int ManagerCreate = 4;
        /// <summary>
        /// 管理员删除操作
        /// </summary>
        public const int ManagerDelete = 5;
        /// <summary>
        /// 管理员修改操作
        /// </summary>
        public const int ManagerModify = 6;
        /// <summary>
        /// 入库
        /// </summary>
        public const int ManagerExportCard = 7;
        /// <summary>
        /// 导出文件
        /// </summary>
        public const int ManagerExportFile = 8;
        /// <summary>
        /// 卡号授权
        /// </summary>
        public const int ManagerEmpower = 9;
        /// <summary>
        /// 卡号移除授权
        /// </summary>
        public const int ManagerCancelPower = 10;
        /// <summary>
        /// 用户注册
        /// </summary>
        public const int UserRegedit = 11;
        /// <summary>
        /// 问题反馈
        /// </summary>
        public const int Feedback = 12;
        /// <summary>
        /// 找回密码
        /// </summary>
        public const int FindPassword = 13;
        /// <summary>
        /// 学习卡充值
        /// </summary>
        public const int LearnCardRecharge = 14;
        /// <summary>
        /// 用户修改操作
        /// </summary>
        public const int UserModify = 15;
        ///// <summary>
        ///// 生成学习卡
        ///// </summary>
        //CardCreate=7,
        //CardScordDelete=8,//
        //CardScordAdd = 9,//学习卡充值
        //CardScordReduce=10,//学习卡使用，减少点数
        //CardScordDisable=11,//学习卡禁用
        //CardScordEnable=12,//学习卡禁用
        //CardScordLogin=13, //

        ///// <summary>
        ///// 生成卡入库
        ///// </summary>
        //CardCreateExport = 14,
        ///// <summary>
        ///// 审核通过
        ///// </summary>
        //CardCreateCheckTrue = 15,
        ///// <summary>
        ///// 禁止
        ///// </summary>
        //CardCreateCheckFalse = 16,
        ///// <summary>
        ///// 生成卡导出文件
        ///// </summary>
        //CardCreateExportFile = 17,
        ///// <summary>
        ///// 生成卡删除
        ///// </summary>
        //CardCreateDel = 18,
        ///// <summary>
        ///// 学习卡导出文件
        ///// </summary>
        //CardExportFile = 19,
        ///// <summary>
        ///// 学习卡删除
        ///// </summary>
        //CardExportFile = 19,
    }
}
