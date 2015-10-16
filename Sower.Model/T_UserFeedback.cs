using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.Model
{
    public class T_UserFeedback
    {
        public T_UserFeedback() { }

        private Int32 m_UserFeedbackID;
        private String m_Name;
        private String m_Phone;
        private String m_QQ;
        private String m_Email;
        private String m_Title;
        private String m_Content;
        private String m_Replay;
        private DateTime m_CreateDate;
        private Boolean m_Approved;

        public Int32 UserFeedbackID
        {
            get { return m_UserFeedbackID; }
            set { m_UserFeedbackID = value; }
        }

        public string UserCode { get; set; }

        public String Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public String Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }

        public String QQ
        {
            get { return m_QQ; }
            set { m_QQ = value; }
        }

        public String Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public String Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public String Content
        {
            get { return m_Content; }
            set { m_Content = value; }
        }

        public String Replay
        {
            get { return m_Replay; }
            set { m_Replay = value; }
        }
        public int ExamTypeID { get; set; }
        public string ExamTypeName { get; set; }
        public DateTime CreateDate
        {
            get { return m_CreateDate; }
            set { m_CreateDate = value; }
        }

        public Boolean Approved
        {
            get { return m_Approved; }
            set { m_Approved = value; }
        }
    }
}
