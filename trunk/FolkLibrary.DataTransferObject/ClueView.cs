using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
   public class ClueView
    {
        public int Id { get; set; }
        /// <summary>
        /// 图书馆名
        /// </summary>
        public string LibraryName { get; set; }

        /// <summary>
        /// 图书馆长
        /// </summary>
        public string LibrarianName { get; set; }

        /// <summary>
        /// 建管时间
        /// </summary>
        public DateTime? BuilDateTime { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Brief { get; set; }

        /// <summary>
        /// 区县信息ID
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
