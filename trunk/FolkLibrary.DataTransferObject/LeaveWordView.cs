using System;

namespace FolkLibrary.DataTransferObject
{
    public class LeaveWordView
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string LeaveWordTitle { get; set; }

        /// <summary>
        /// 留言内容
        /// </summary>
        public string LeaveWordContent { get; set; }

        /// <summary>
        /// 电子邮件地址
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidateCode { get; set; }

        /// <summary>
        /// 留言时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}
