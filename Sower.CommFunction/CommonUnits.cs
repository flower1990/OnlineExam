using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace Sower.CommFunction
{
    public class CommonUnits
    {
        public static string StringSubstring(string str, int length)
        {
            string result = "";

            if (str.Length > length)
            {
                result = str.Substring(0, length) + "...";
            }
            else
            {
                result = str;
            }

            return result;
        }

        /// <summary>
        /// 判断输入的字符串是否是一个超链接
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsURL(string input)
        {
            string pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&$%\$#\=~])*$";
            Regex r = new Regex(pattern);
            Match m = r.Match(input);
            return m.Success;
        }

        /// <summary>
        /// 验证数字
        /// </summary>
        /// <param name="number">数字内容</param>
        /// <returns>true 验证成功 false 验证失败</returns>
        public static bool CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }
            Regex regex = new Regex(@"^(-)?\d+(\.\d+)?$");
            if (regex.IsMatch(number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 验证输入字符串为身份证号码
        /// </summary>
        /// <param name="idStr"></param>
        /// <returns></returns>
        public static bool CheckIdCard(string idStr)
        {
            string date = "", Ai = "";
            string verify = "10x98765432";
            int[] Wi = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
            string[] area = { "", "", "", "", "", "", "", "", "", "", "", "北京", "天津", "河北", "山西", "内蒙古", "", "", "", "", "", "辽宁", "吉林", "黑龙江", "", "", "", "", "", "", "", "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", "", "", "", "河南", "湖北", "湖南", "广东", "广西", "海南", "", "", "", "重庆", "四川", "贵州", "云南", "西藏", "", "", "", "", "", "", "陕西", "甘肃", "青海", "宁夏", "新疆", "", "", "", "", "", "台湾", "", "", "", "", "", "", "", "", "", "香港", "澳门", "", "", "", "", "", "", "", "", "国外" };
            string[] re = Regex.Split(idStr, @"^(\d{2})\d{4}(((\d{2})(\d{2})(\d{2})(\d{3}))|((\d{4})(\d{2})(\d{2})(\d{3}[x\d])))$", RegexOptions.IgnoreCase);
            if (re.Length != 9) return false;
            int ProvId = int.Parse(re[1]);
            if (ProvId >= area.Length || area[ProvId] == "") return false;
            if (re[2].Length == 12)
            {
                Ai = idStr.Substring(0, 17);
                date = re[4] + "-" + re[5] + "-" + re[6];
            }
            else
            {
                Ai = idStr.Substring(0, 6) + "19" + idStr.Substring(6);
                date = "19" + re[4] + "-" + re[5] + "-" + re[6];
            }
            try
            {
                DateTime.Parse(date);
            }
            catch
            {
                return false;
            }
            int sum = 0;
            for (int i = 0; i <= 16; i++)
            {
                sum += int.Parse(Ai.Substring(i, 1)) * Wi[i];
            }
            Ai += verify.Substring(sum % 11, 1);
            return (idStr.Length == 15 || idStr.Length == 18 && idStr.ToLower() == Ai);
        }
        #region
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">要发送的邮箱</param>
        /// <param name="mailSubject">邮箱主题</param>
        /// <param name="mailContent">邮箱内容</param>
        /// <returns>返回发送邮箱的结果</returns>
        public static bool SendEmail(string mailTo, string mailSubject, string mailContent)
        {
            // 设置发送方的邮件信息,例如使用网易的smtp
            string smtpServer = "smtp.sina.cn"; //SMTP服务器
            string mailFrom = "13613823517@sina.cn"; //登陆用户名
            string userPassword = "mr.flower";//登陆密码

            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new NetworkCredential(mailFrom, userPassword);//用户名和密码

            // 发送邮件设置        
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Low;//优先级

            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
        #endregion
        public static string GetEmail(string email)
        {
            int index = email.LastIndexOf('@');
            email = email.Substring(0, 2) + "****" + email.Substring(index - 1, 1) + email.Substring(index);
            return email;
        }
    }
}
