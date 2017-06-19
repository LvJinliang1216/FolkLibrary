using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class AreaEntity : IAggregateRoot
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
        /// 城市编码
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 图书馆列表
        /// </summary>
        public List<LibraryInfoEntity> LibraryInfo { get; set; }

        /// <summary>
        /// 所属城市
        /// </summary>
        public CityEntity City { get; set; }

        /// <summary>
        /// 线索信息
        /// </summary>
        public List<ClueLibraryInfoEntity> ClueLibraryInfoEntities { get; set; }
    }
}
