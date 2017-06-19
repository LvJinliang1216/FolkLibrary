using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
    public class WebSiteInfoView
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int WebSiteInfoId { get; set; }

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
    }
}
