using System.Collections.Generic;
using Sower.Model;

namespace ComputerRankExam.Areas.Computer.Models
{
    public class IndexViewModel
    {
        public List<T_Article> useHelpArticle { get; set; }
        public List<T_Article> newsArticle { get; set; }
        public List<T_Article> reviewGuidArticle { get; set; }
        public List<T_Article> examinationCenterArticle { get; set; }
        public List<T_Article> ExamNewsArticle { get; set; }
        public List<T_Article> TopOnePicArticle { get; set; }
        public List<T_Article> SignUpEntry { get; set; }
        public List<T_Product> productInfo { get; set; }

        public List<T_ExamFile> downLoadFile { get; set; }

        public string phone { get; set; }
    }
}