using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Application.Interface
{
    public interface IProgramService
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="programView">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总的数据条数</param>
        /// <returns></returns>
        List<ProgramView> Search(ProgramView programView, int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 添加模块信息
        /// </summary>
        /// <param name="programView"></param>
        /// <returns></returns>
        Task<bool> CreateProgram(ProgramView programView);

        /// <summary>
        /// 修改模块信息
        /// </summary>
        /// <param name="programView"></param>
        /// <returns></returns>
        Task<bool> ModifyProgram(ProgramView programView);

        /// <summary>
        /// 删除模块信息
        /// </summary>
        /// <param name="programId"></param>
        /// <returns></returns>
        Task<bool> DeleteProgram(int programId);
    }
}
