using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerRankExam.Models
{
    public class LoginViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "请您输入用户名")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "长度为{2}~{1}个字符")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请您输入密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "长度为{2}~{1}个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        [Display(Name = "验证码")]
        [Required(ErrorMessage = "请您输入验证码")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "长度为{2}~{1}个字符")]
        public string VerificationCode { get; set; }
    }
}