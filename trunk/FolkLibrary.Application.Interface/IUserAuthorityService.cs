using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Application.Interface
{
    public interface IUserAuthorityService
    {

        /// <summary>
        /// 权限信息列表
        /// </summary>
        /// <param name="userAuthorityView"></param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        IList<UserAuthorityView> Search(UserAuthorityView userAuthorityView, int pageIndex, int pageSize, out  int total);

        /// <summary>
        /// 添加用户权限
        /// </summary>
        /// <param name="userAuthorityView"></param>
        /// <returns></returns>
        Task<bool> CreateUserAuthority(UserAuthorityView userAuthorityView);

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userAuthorityId"></param>
        /// <returns></returns>
        Task<bool> DeleteUserAuthority(int userAuthorityId);
    }
}
