using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace ComputerRankExam.Models
{
    public class FindPasswordViewModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        [Required(ErrorMessage = "请您输入邮箱")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-z]{2,4}", ErrorMessage = "您输入的邮箱格式不正确")]
        [Remote("CheckEmail", "AverageUser", ErrorMessage = "密保邮箱不存在，请重新输入")]
        public string Email { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Display(Name = "验证码")]
        [Required(ErrorMessage = "请您输入验证码")]
        public string VerificationCode { get; set; }
    }

    public class ValidatePasswordViewModel
    {
        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Display(Name = "验证码")]
        [Required(ErrorMessage = "请您输入验证码")]
        public string ValidateCode { get; set; }
    }

    public class ResetPasswordViewModel
    {
        /// <summary>
        /// 新密码
        /// </summary>
        [Display(Name = "新密码")]
        [Required(ErrorMessage = "请您输入密码")]
        [StringLength(14, MinimumLength = 4, ErrorMessage = "长度为{2}~{1}个字符")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Display(Name = "确认密码")]
        [Required(ErrorMessage = "请您输入确认密码")]
        [Compare("NewPassword", ErrorMessage = "您输入的密码与确认密码不一致")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}