using System.Collections.Generic;
using Sower.Model;

namespace ComputerRankExam.Models
{
    public class HomeViewModel
    {
        public List<T_Article> ArticleList { get; set; }

        public List<T_Article> ArticleList1 { get; set; }

        public List<T_Article> ArticleList2 { get; set; }

        public T_Article ArticleModel { get; set; }

        public string phone { get; set; }

        public List<T_ExamFile> kjExamFile { get; set; }
        public List<T_ExamFile> jsjExamFile { get; set; }
        public List<T_ExamFile> ExamFile { get; set; }

        public T_ExamType ExamType { get; set; }

        public List<T_Article> Articles { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string ColumnTitle { get; set; }
        public string ExamDomain { get; set; }
    }
}