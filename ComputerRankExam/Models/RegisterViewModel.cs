using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Models
{
    public class RegisterViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "请您输入用户名")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "长度为{2}~{1}个字符")]
        [Display(Name = "用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 性别【0-男；1-女；2-保密】
        /// </summary>
        [Display(Name = "性别")]
        [Required(ErrorMessage = "请您选择性别")]
        [Range(0, 2, ErrorMessage = "×")]
        public int Sex { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "请您输入密码")]
        [Display(Name = "密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "长度为{2}~{1}个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Required(ErrorMessage = "请您输入确认密码")]
        [Display(Name = "密码")]
        [Compare("Password", ErrorMessage = "您输入的密码与确认密码不一致")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage = "请您输入邮箱")]
        [Display(Name = "邮箱")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-z]{2,4}", ErrorMessage = "您输入的邮箱格式不正确")]
        public string Email { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "请您输入验证码")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "您输入的验证码不正确")]
        [Display(Name = "验证码")]
        public string VerificationCode { get; set; }
    }
}