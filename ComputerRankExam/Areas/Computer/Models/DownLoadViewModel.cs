using System.Collections.Generic;
using Sower.Model;

namespace ComputerRankExam.Areas.Computer.Models
{
    public class DownLoadViewModel
    {
        public List<T_ExamFile> downloadfiles { get; set; }

        public string phone { get; set; }
    }
}