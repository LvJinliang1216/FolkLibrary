using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Application.Interface
{
    public interface IFriendDepartmentService
    {
        /// <summary>
        /// 获取相关单位信息
        /// </summary>
        /// <param name="friendDepartmentId"></param>
        /// <returns></returns>
        FriendDepartmentView Get(int friendDepartmentId);

        /// <summary>
        /// 查询相关单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        List<FriendDepartmentView> Search(FriendDepartmentView friendDepartmentView, int pageIndex, int pageSize, out int total);

        /// <summary>
        /// 添加相关单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <returns></returns>
        Task<bool> CreateFriendDepartment(FriendDepartmentView friendDepartmentView);

        /// <summary>
        /// 修改相关单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <returns></returns>
        Task<bool> ModifyFriendDepartment(FriendDepartmentView friendDepartmentView);

        /// <summary>
        /// 删除相关单位信息
        /// </summary>
        /// <param name="friendDepartmentId"></param>
        /// <returns></returns>
        Task<bool> DeleteFriendDepartment(int friendDepartmentId);
    }
}
