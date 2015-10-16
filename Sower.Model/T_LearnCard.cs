using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sower.Model
{
    public class T_LearnCard
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "卡号")]
        public string Code { get; set; }
        public string Password { get; set; }
        public int? UserId { get; set; }
        public string Publisher { get; set; }
        /// <summary>
        /// 全部点数
        /// </summary>
        [Display(Name = "全部点数")]
        public int TotalLicense { get; set; }
        /// <summary>
        /// 剩余点数
        /// </summary>
        [Display(Name = "剩余点数")]
        public int LeftLicense { get; set; }
        public bool Approved { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [Display(Name = "登陆次数")]
        public int LoginTimes { get; set; }
        public bool IsSold { get; set; }
        /// <summary>
        /// 导入文件记录id
        /// </summary>
        public int FileId { get; set; }
        /// <summary>
        /// 生成卡规则id
        /// </summary>
        public int CreateCardRuleId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public bool? Simulation { get; set; }
        public string CardType { get; set; }
        /// <summary>
        /// 面值
        /// </summary>
        [Display(Name = "卡片面值")]
        public int CardPrice { get; set; }
        /// <summary>
        /// 是否授权
        /// </summary>
        public bool IsEmpower { get; set; }
        public string RealName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime SoldTime { get; set; }
    }
}
