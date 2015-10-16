using System.Collections.Generic;
using Sower.Model;

namespace ComputerRankExam.Areas.Accounting.Models
{
    public class LeftViewModel
    {
        public List<T_Article> userHelpArticles { get; set; }

        public List<T_Article> zhinanArticles { get; set; }
        public string phone { get; set; }
    }
}