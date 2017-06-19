using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
    public class ProjectClassView
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ProjectClassId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 项目描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortCode { get; set; }

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
        /// 省份编码
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 操作人信息
        /// </summary>
        public UserInfoView UserInfoView { get; set; }

        /// <summary>
        /// 省份信息
        /// </summary>
        public ProvinceView ProvinceView { get; set; }
    }

    public class ProjectQuery
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 省份编码
        /// </summary>
        public string ProvinceId { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 项目开展时间
        /// </summary>
        public string CreateDatetime { get; set; }
    }
}
