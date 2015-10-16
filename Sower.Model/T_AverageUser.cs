using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Sower.Model
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class T_AverageUser
    {
        [Key]
        public int AverageUserID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "必填")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "请输入{2}到{1}个字符")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [Required(ErrorMessage = "必填")]
        [StringLength(512)]
        public string Password { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "请输入{2}到{1}个字符")]
        public string RealName { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [Display(Name = "手机号码")]
        [RegularExpression(@"^[1]+[3,5]+\d{9}$", ErrorMessage = "手机号码格式不正确")]
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "电子邮箱")]
        [Required(ErrorMessage = "必填")]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-z]{2,4}", ErrorMessage = "电子邮箱格式不正确")]
        public string Email { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [Display(Name = "身份证号")]
        //[RegularExpression(@"/^[1-9]{1}[0-9]{14}$|^[1-9]{1}[0-9]{16}([0-9]|[xX])$/", ErrorMessage = "身份证号格式不正确")]
        public string IDNumber { get; set; }
        /// <summary>
        /// 性别【0-男；1-女；2-保密】
        /// </summary>
        [Display(Name = "性别")]
        [Required(ErrorMessage = "必填")]
        [Range(0, 2, ErrorMessage = "×")]
        public int Sex { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        [Display(Name = "联系地址")]
        [StringLength(80, MinimumLength = 4, ErrorMessage = "请输入{2}到{1}个字符")]
        public string Address { get; set; }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Approved { get; set; }
        /// <summary>
        /// 密保问题
        /// </summary>
        [Display(Name = "密保问题", Description = "请正确填写，在您忘记密码时用户找回密码。4-20个字符。")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "请输入{2}到{1}个字符")]
        public string PasswordQuestion { get; set; }
        /// <summary>
        /// 密保答案
        /// </summary>
        [Display(Name = "密保答案", Description = "请认真填写，忘记密码后回答正确才能找回密码。2-20个字符。")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "请输入{2}到{1}个字符")]
        public string PasswordAnswer { get; set; }
        /// <summary>
        /// 登陆次数
        /// </summary>
        [Display(Name = "登陆次数")]
        public int LoginTimes { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        /// 账户金额
        /// </summary>
        [Display(Name = "账户金额")]
        public int? Cach { get; set; }
    }
}
