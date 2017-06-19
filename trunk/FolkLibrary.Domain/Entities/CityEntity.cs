using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class CityEntity : IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 省份编码
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 所属省份
        /// </summary>
        public ProvinceEntity Province { get; set; }

        /// <summary>
        /// 区县列表
        /// </summary>
        public List<AreaEntity> Areas { get; set; }

    }
}
