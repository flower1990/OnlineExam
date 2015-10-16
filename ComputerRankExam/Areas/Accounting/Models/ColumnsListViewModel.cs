using System.Collections.Generic;
using Sower.Model;

namespace ComputerRankExam.Areas.Accounting.Models
{
    public class ColumnsListViewModel
    {
        public List<T_Article> Articles { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string ColumnTitle { get; set; }
        public string domain { get; set; }
        public string ExamDomain { get; set; }
    }
}