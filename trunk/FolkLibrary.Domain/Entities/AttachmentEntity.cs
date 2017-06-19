using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class AttachmentEntity : IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FromId { get; set; }

        /// <summary>
        /// 附件的来源
        /// </summary>
        public FromType FromType { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件地址
        /// </summary>
        public string FileAddress { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? UploadTime { get; set; }

        ///// <summary>
        ///// 相关单位信息
        ///// </summary>
        //public FriendDepartmentEntity FriendDepartmentEntity { get; set; }

        ///// <summary>
        ///// 相关新闻
        ///// </summary>
        //public FriendNewsInfoEntity FriendNewsInfoEntity { get; set; }

        ///// <summary>
        ///// 图书馆信息
        ///// </summary>
        //public LibraryInfoEntity LibraryInfoEntity { get; set; }
    }
}
