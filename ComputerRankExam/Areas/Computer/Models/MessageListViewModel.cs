using Sower.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerRankExam.Areas.Computer.Models
{
    public class MessageListViewModel
    {
        public List<T_UserFeedback> messageList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}