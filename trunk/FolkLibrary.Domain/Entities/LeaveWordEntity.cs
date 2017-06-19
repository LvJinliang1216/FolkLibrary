using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
   public class LeaveWordEntity:IAggregateRoot
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
       /// 创建时间
       /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}
