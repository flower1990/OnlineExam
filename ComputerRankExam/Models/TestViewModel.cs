using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ComputerRankExam.Extensions;

namespace ComputerRankExam.Models
{
    public class TestViewModel
    {
        [Required(ErrorMessage = "必填")]
        [MaxWords(10)]
        public string UserName { get; set; }
    }
}