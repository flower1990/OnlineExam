using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.Model
{
     public class T_Product
    {
         public T_Product() { }
      
       public int Id { get; set; }
       public int ColumnId { get; set; }
       public string ColumnTitle { get; set; }
       public string Title { get; set; }
       public string SubTitle { get; set; }
       public string Thumbnail { get; set; }
       public string beat { get; set; }
       public decimal Price { get; set; }
       public string Keyword { get; set; }
       public string Description { get; set; }
       public string Content { get; set; }
       public int Clicks { get; set; }
       public string Source { get; set; }
       public string Quote { get; set; }
       public string Annex { get; set; }
       public string Publisher { get; set; }
       public bool IsValid { get; set; }
       public int ExamTypeID { get; set; }
       public string ExamTypeName { get; set; }
       public DateTime CreateTime { get; set; }
       public DateTime ModifyTime { get; set; }
    }
}
