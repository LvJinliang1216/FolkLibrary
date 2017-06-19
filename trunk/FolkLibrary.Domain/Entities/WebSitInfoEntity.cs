using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class WebSiteInfoEntity : IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 网站名称
        /// </summary>
        public string WebSiteName { get; set; }

        /// <summary>
        /// 网站简介
        /// </summary>
        public string WebSiteBrief { get; set; }

        /// <summary>
        /// 网站介绍
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 相关单位信息
        /// </summary>
        public List<FriendDepartmentEntity> FriendDepartments{get;set;}

        /// <summary>
        /// 相关新闻信息
        /// </summary>
        public List<FriendNewsInfoEntity> FriendNewsInfoes { get; set; }
    }
}
