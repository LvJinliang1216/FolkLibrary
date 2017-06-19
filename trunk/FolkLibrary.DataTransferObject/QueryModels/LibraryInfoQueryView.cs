using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject.QueryModels
{
    public class LibraryInfoQueryView
    {
        /// <summary>
        /// 创建人
        /// </summary>
        public string BuildUserName { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 图书馆名称
        /// </summary>
        public string LibraryName { get; set; }
    }
}
