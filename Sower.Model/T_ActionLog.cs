using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.Model
{
    public class T_ActionLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Intro { get; set; }
        public int ActionType { get; set; }
        public string TableName { get; set; }
        public int TableItemId { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
    }
}
