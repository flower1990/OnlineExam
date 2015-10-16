using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerRankExam.Areas.Member.Models 
{
    public class ChangeEmailViewMode
    {
        /// <summary>
        /// 密保邮箱
        /// </summary>
        [Display(Name = "密保邮箱")]
        public string OriginalEmail { get; set; }

        /// <summary>
        /// 确认邮箱
        /// </summary>
        [Required(ErrorMessage = "请输入当前邮箱地址")]
        [Display(Name = "确认邮箱")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{2}到{1}个字符")]
        public string ConfirmEmail { get; set; }
    }
}