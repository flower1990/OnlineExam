using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sower.CommFunction
{
    public class FenYeData
    {
        public FenYeData() { }
        /// <summary>
        /// 表名 必选
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 主键 必选
        /// </summary>
        public string PrimaryKey { get; set; }
        /// <summary>
        /// 排序字段 必选
        /// </summary>
        public string OrderKey { get; set; }
        /// <summary>
        /// 排序方式 必选
        /// </summary>
        public bool OrderType { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int iTotalRecCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int iPageCount { get; set; }
        /// <summary>
        /// 页码 必选
        /// </summary>
        public int iPageIndex { get; set; }
        /// <summary>
        /// 每页记录数默认15 必选
        /// </summary>
        public int iPageSize { get; set; }
        /// <summary>
        /// 条件 必选
        /// </summary>
        public string SearchCondition { get; set; }
        /// <summary>
        /// 获取的字段 必选
        /// </summary>
        public string GetFields { get; set; }
    }
}
