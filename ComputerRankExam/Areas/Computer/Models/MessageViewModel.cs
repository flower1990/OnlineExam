using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComputerRankExam.Areas.Computer.Models
{
    public class MessageViewModel
    {
        [Required(ErrorMessage = "请输入昵称")]
        public string sname { get; set; }

        public string Phone { get; set; }

        public string QQ { get; set; }

        [Required(ErrorMessage = "请输入邮箱")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-z]{2,4}", ErrorMessage = "请输入有效的电子邮箱")]
        public string Email { get; set; }

        [Required(ErrorMessage = "请输入标题")]
        public string stitle { get; set; }

        [Required(ErrorMessage = "请输入内容")]
        public string content { get; set; }

        [Required(ErrorMessage = "请输入验证码")]
        public string ValidCode { get; set; }
    }
}