using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
    public class LibraryInfoView
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int LibraryInfoId { get; set; }

        /// <summary>
        /// 信息来源
        /// </summary>
        public string InformationFrom { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string BuildUserName { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? BuildDate { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 图书馆名称
        /// </summary>
        public string LibraryName { get; set; }

        /// <summary>
        /// 图书馆介绍
        /// </summary>
        public string LibraryDescription { get; set; }

        /// <summary>
        /// 静态页面地址
        /// </summary>
        public string StaticPageUrl { get; set; }

        /// <summary>
        /// 操作人Id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyDateTime { get; set; }

        /// <summary>
        /// 区县编码
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public List<AttachmentView> AttachmentViews { get; set; }

        /// <summary>
        /// 所属区县
        /// </summary>
        public AreaView AreaView { get; set; }

        /// <summary>
        /// 操作人信息
        /// </summary>
        public UserInfoView UserInfoView { get; set; }
    }
}
