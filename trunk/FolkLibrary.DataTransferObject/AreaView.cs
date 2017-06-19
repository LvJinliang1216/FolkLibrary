using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.DataTransferObject
{
    public class AreaView
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 区县名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 区县编码
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 城市信息
        /// </summary>
        public CityView CityView { get; set; }
    }
}
