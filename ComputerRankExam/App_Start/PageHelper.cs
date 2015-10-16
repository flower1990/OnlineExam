using Sower.Business;
using Sower.CommFunction;
using Sower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.App_Start
{
    public class PageHelper
    {
        ActionLogService actionLogService = new ActionLogService();
        AverageUserService userService = new AverageUserService();
        LearnCardService cardService = new LearnCardService();

        /// <summary>
        /// 获取用户名
        /// </summary>
        public string UserName
        {
            get
            {
                HttpCookie _cookie = HttpContext.Current.Request.Cookies["AverageUser"];
                if (_cookie == null) return "";
                else return _cookie["UserName"];
            }
        }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType
        {
            get
            {
                if (CommonUnits.CheckNumber(UserName))
                {
                    return "card";
                }
                else
                {
                    return "user";
                }
            }
        }
        /// <summary>
        /// 操作日志-添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aType">操作日志类型</param>
        /// <param name="id">主键ID</param>
        /// <param name="content">日志内容</param>
        public void AddLog<T>(int actionType, int id, string content) where T : class,new()
        {
            T t = new T();
            T_ActionLog actionLog = new T_ActionLog();

            if (UserType == "card")
            {
                var _card = cardService.Find(UserName);

                actionLog.CreateTime = DateTime.Now;
                actionLog.ActionType = actionType;
                actionLog.TableItemId = id;
                actionLog.TableName = t.GetType().Name;
                actionLog.UserId = _card.Id;
                actionLog.UserName = _card.Code;
                actionLog.RealName = _card.RealName;
                actionLog.Intro = content;

                actionLogService.Add(actionLog);
            }
            else
            {
                var _user = userService.Find(UserName);

                actionLog.CreateTime = DateTime.Now;
                actionLog.ActionType = actionType;
                actionLog.TableItemId = id;
                actionLog.TableName = t.GetType().Name;
                actionLog.UserId = _user.AverageUserID;
                actionLog.UserName = _user.UserName;
                actionLog.RealName = _user.RealName;
                actionLog.Intro = content;

                actionLogService.Add(actionLog);
            }
        }
    }
}