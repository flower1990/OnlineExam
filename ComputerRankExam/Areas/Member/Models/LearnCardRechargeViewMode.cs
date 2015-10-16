using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerRankExam.Areas.Member.Models
{
    public class LearnCardRechargeViewMode
    {
        /// <summary>
        /// 学习卡
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "学习卡")]
        public string LearnCard { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "验证码不正确")]
        [Display(Name = "验证码")]
        public string VerificationCode { get; set; }
    }
}