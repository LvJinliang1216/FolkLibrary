﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Domain.Entities
{
    public class ProgramEntity : IAggregateRoot
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 模块Id
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// 所属模块
        /// </summary>
        public ModuleEntity ModuleEntity { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int SortCode { get; set; }

        /// <summary>
        /// 页面名称
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 页面地址
        /// </summary>
        public string PageUrl { get; set; }

        /// <summary>
        /// 页面图标
        /// </summary>
        public string PageIcon { get; set; }

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
    }
}