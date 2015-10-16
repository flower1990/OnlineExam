using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sower.Model;

namespace ComputerRankExam.Areas.Accounting.Models
{
    public class DetailViewModel
    {
        public T_Article ArticleModel { get; set; }
        public string ExamDomain { get; set; }
    }
}