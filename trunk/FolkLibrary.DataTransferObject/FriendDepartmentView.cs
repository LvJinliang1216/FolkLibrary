using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FolkLibrary.DataTransferObject
{
  public  class FriendDepartmentView
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 相关单位的官网地址
        /// </summary>
        public string FriendDepartmentUrl { get; set; }

        /// <summary>
        /// 单位描述
        /// </summary>
        public string DepartmentDescn { get; set; }

        /// <summary>
        /// 网站信息Id
        /// </summary>
        public int WebSitInfoId { get; set; }

      /// <summary>
        /// 操作人Id
        /// </summary>
        public int UserInfoId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? CreateDateTime { get; set; }
    }
}
