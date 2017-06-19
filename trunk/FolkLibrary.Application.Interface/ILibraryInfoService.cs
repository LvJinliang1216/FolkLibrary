using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;
using FolkLibrary.DataTransferObject.QueryModels;

namespace FolkLibrary.Application.Interface
{
    public interface ILibraryInfoService
    {
        /// <summary>
        /// 图书馆信息列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        IList<LibraryInfoView> Search(LibraryInfoQueryView query, int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 添加项目分类信息
        /// </summary>
        /// <param name="libraryInfoView"></param>
        /// <returns></returns>
        Task<bool> CreateLibraryInfo(LibraryInfoView libraryInfoView);

        /// <summary>
        /// 修改项目分类信息
        /// </summary>
        /// <param name="libraryInfoView"></param>
        /// <returns></returns>
        Task<bool> ModifyLibraryInfo(LibraryInfoView libraryInfoView);

        /// <summary>
        /// 删除项目分类信息
        /// </summary>
        /// <param name="libraryInfoId"></param>
        /// <returns></returns>
        Task<bool> DeleteLibraryInfo(int libraryInfoId);
    }
}
