using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.Model
{
    public class T_ExamFile
    {
        public T_ExamFile() { }

        private int m_FileID;
        private Guid m_UniqueFileID;
        public int ExamTypeID { get; set; }
        public string ExamTypeName { get; set; }
        public int ExamSubjectID { get; set; }
        public string ExamSubjectName { get; set; }

        private String m_FileType;
        private String m_FileShowName;
        private String m_FileRealName;
        private String m_FileExt;
        private String m_FileTitle;
        private String m_FileIntroduction;
        private String m_SavePath;
        private String m_Operator;
        private Boolean m_Disuse;
        private DateTime m_CreateTime;
        public DateTime ModifyTime { get; set; }
        public int ExamFileTypeID { get; set; }
        public int FileSize { get; set; }
        public string FileInfo { get; set; }

        public int FileID
        {
            get { return m_FileID; }
            set { m_FileID = value; }
        }

        public Guid UniqueFileID
        {
            get { return m_UniqueFileID; }
            set { m_UniqueFileID = value; }
        }

        public String FileType
        {
            get { return m_FileType; }
            set { m_FileType = value; }
        }

        public String FileShowName
        {
            get { return m_FileShowName; }
            set { m_FileShowName = value; }
        }

        public String FileRealName
        {
            get { return m_FileRealName; }
            set { m_FileRealName = value; }
        }

        public String FileExt
        {
            get { return m_FileExt; }
            set { m_FileExt = value; }
        }

        public String FileTitle
        {
            get { return m_FileTitle; }
            set { m_FileTitle = value; }
        }

        public String FileIntroduction
        {
            get { return m_FileIntroduction; }
            set { m_FileIntroduction = value; }
        }

        public String SavePath
        {
            get { return m_SavePath; }
            set { m_SavePath = value; }
        }

        public String Operator
        {
            get { return m_Operator; }
            set { m_Operator = value; }
        }

        public Boolean Disuse
        {
            get { return m_Disuse; }
            set { m_Disuse = value; }
        }

        public DateTime CreateTime
        {
            get { return m_CreateTime; }
            set { m_CreateTime = value; }
        }
    }
}
