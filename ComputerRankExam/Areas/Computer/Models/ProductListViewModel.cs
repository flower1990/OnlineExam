using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sower.Model;

namespace ComputerRankExam.Areas.Computer.Models
{
    public class ProductListViewModel
    {
        public List<T_Product> prodcutList { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string ColumnTitle { get; set; }
    }
}