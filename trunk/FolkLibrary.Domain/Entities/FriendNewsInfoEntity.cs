using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class FriendNewsInfoEntity : IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 新闻标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 相关新闻的链接地址【若有文章内容，则此字段将会是本地网页地址，否则将是外链地址】
        /// </summary>
        public string FrindNewsUrl { get; set; }

        /// <summary>
        /// 网站信息Id
        /// </summary>
        public int WebSitInfoId { get; set; }

        /// <summary>
        /// 网站信息
        /// </summary>
        public WebSiteInfoEntity WebSitInfo { get; set; }

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
    }
}
