using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Application.Interface
{
    public interface IModuleService
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="moduleView">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总的数据条数</param>
        /// <returns></returns>
        List<ModuleView> Search(ModuleView moduleView, int pageIndex, int pageSize,out int total);

        /// <summary>
        /// 添加模块信息
        /// </summary>
        /// <param name="moduleView"></param>
        /// <returns></returns>
        Task<bool> CreateModule(ModuleView moduleView);

        /// <summary>
        /// 修改模块信息
        /// </summary>
        /// <param name="moduleView"></param>
        /// <returns></returns>
        Task<bool> ModifyModule(ModuleView moduleView);

        /// <summary>
        /// 删除模块信息
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        Task<bool> DeleteModule(int moduleId);
    }
}
