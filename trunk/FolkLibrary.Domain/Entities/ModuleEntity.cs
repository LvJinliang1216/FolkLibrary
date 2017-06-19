﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class ModuleEntity:IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortCode { get; set; }

        /// <summary>
        /// 模块图标
        /// </summary>
        public string ModuleIcon { get; set; }

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
        /// 页面列表
        /// </summary>
        public IList<ProgramEntity> ProgramEntities { get; set; }
    }
}
