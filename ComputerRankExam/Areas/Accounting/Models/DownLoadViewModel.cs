using System.Collections.Generic;
using Sower.Model;

namespace ComputerRankExam.Areas.Accounting.Models
{
    public class DownLoadViewModel
    {
        public List<T_ExamFile> downloadfiles { get; set; }
        public string examDomain { get; set; }
    }
}