using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Member.Models
{
    public class ChangePasswordQuestionViewMode
    {
        /// <summary>
        /// 安全问题
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "安全问题")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        public string PasswordQuestion { get; set; }

        /// <summary>
        /// 答案
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "答案")]
        public string PasswordAnswer { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "登陆密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}