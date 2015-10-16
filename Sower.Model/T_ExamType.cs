using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.Model
{
    public class T_ExamType
    {
        public T_ExamType() { }
        private Int32 m_ExamTypeID;
        private String m_ExamTypeCode;
        private String m_ExamTypeName;
        private Boolean m_Chargeable;
        private Boolean m_SameSubjectPrice;
        private Decimal m_SubjectUnitPrice;
        private Boolean m_AllowSignUp;
        private Boolean m_AllowExam;
        private Boolean m_Simulation;
        private DateTime m_CreateTime;
        private DateTime m_ModifyTime;
        private int m_CutLicense;
        private int m_CutLicenseType;
        private Boolean m_IsValid;
        public string ExamTypeInfo { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ExamDomain { get; set; }

        public Int32 ExamTypeID
        {
            get { return m_ExamTypeID; }
            set { m_ExamTypeID = value; }
        }

        public String ExamTypeCode
        {
            get { return m_ExamTypeCode; }
            set { m_ExamTypeCode = value; }
        }

        public String ExamTypeName
        {
            get { return m_ExamTypeName; }
            set { m_ExamTypeName = value; }
        }

        public Boolean Chargeable
        {
            get { return m_Chargeable; }
            set { m_Chargeable = value; }
        }

        public Boolean SameSubjectPrice
        {
            get { return m_SameSubjectPrice; }
            set { m_SameSubjectPrice = value; }
        }

        public Decimal SubjectUnitPrice
        {
            get { return m_SubjectUnitPrice; }
            set { m_SubjectUnitPrice = value; }
        }

        public Boolean AllowSignUp
        {
            get { return m_AllowSignUp; }
            set { m_AllowSignUp = value; }
        }

        public Boolean AllowExam
        {
            get { return m_AllowExam; }
            set { m_AllowExam = value; }
        }

        public Boolean Simulation
        {
            get { return m_Simulation; }
            set { m_Simulation = value; }
        }

        public DateTime CreateTime
        {
            get { return m_CreateTime; }
            set { m_CreateTime = value; }
        }
        public DateTime ModifyTime
        {
            get { return m_ModifyTime; }
            set { m_ModifyTime = value; }
        }
        public int CutLicense
        {
            get { return m_CutLicense; }
            set { m_CutLicense = value; }
        }
        public Boolean IsValid
        {
            get { return m_IsValid; }
            set { m_IsValid = value; }
        }
        public int CutLicenseType
        {
            get { return m_CutLicenseType; }
            set { m_CutLicenseType = value; }
        }
    }
}
