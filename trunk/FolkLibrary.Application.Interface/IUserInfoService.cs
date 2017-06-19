using FolkLibrary.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Application.Interface
{
    public interface IUserInfoService
    {
        Task<IList<UserInfoView>> GetAll();

        Task<UserInfoView> Get(int id);

        /// <summary>
        /// 验证登录信息
        /// </summary>
        /// <param name="userInfoView"></param>
        /// <returns>验证通过，则返回用户信息；否则，返回null</returns>
        UserInfoView ValidateLogin(UserInfoView userInfoView);

        /// <summary>
        /// 分页获取用户信息
        /// </summary>
        /// <param name="userInfo">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总记录数</param>
        /// <returns></returns>
        IList<UserInfoView> SearchUserInfo(UserInfoView userInfo, int pageIndex, int pageSize, out  int total);

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        Task<bool> SaveUserInfo(UserInfoView userInfo);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <returns></returns>
        Task<bool> ResetPassword(string userInfoId);

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <returns></returns>
        Task<bool> DeleteUserInfo(string userInfoId);
    }
}
