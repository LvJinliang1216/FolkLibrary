using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class ProjectEntity : IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 静态页面的地址
        /// </summary>
        public string StaticPageUrl { get; set; }

        /// <summary>
        /// 项目简介
        /// </summary>
        public string ProjectContent { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortCode { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishedTime { get; set; }

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
        /// 阅读次数
        /// </summary>
        public int ReadCount { get; set; }

        /// <summary>
        /// 捐赠信息列表
        /// </summary>
        public List<ProjectDonationRefEntity> ProjectDonationRefs { get; set; }

        /// <summary>
        /// 项目分类ID
        /// </summary>
        public int ProjectClassId { get; set; }

        /// <summary>
        /// 项目所属分类
        /// </summary>
        public ProjectClassEntity ProjectClass { get; set; }


    }
}
