using System.Collections.Generic;
using Sower.Model;

namespace ComputerRankExam.Areas.Accounting.Models
{
    public class MessageListViewModel
    {
        public List<T_UserFeedback> messageList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}