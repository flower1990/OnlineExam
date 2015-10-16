using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Member.Models
{
    public class ChangeEmailConfirmViewMode
    {
        /// <summary>
        /// 新邮箱
        /// </summary>
        [Required(ErrorMessage = "请输入邮箱地址")]
        [Display(Name = "邮箱地址")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        public string Email { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "请输入邮箱验证码")]
        [Display(Name = "验证码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        public string ValidateCode { get; set; }
    }
}