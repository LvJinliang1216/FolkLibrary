using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class ProvinceEntity : IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 省份编码
        /// </summary>
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 城市列表
        /// </summary>
        public List<CityEntity> Cities { get; set; }

        /// <summary>
        /// 项目分类列表
        /// </summary>
        public List<ProjectClassEntity> ProjectClasses { get; set; }
    }
}
