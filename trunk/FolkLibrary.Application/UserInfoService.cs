using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Domain.Entities;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Repository.Interface.IRepository;
using FolkLibrary.Util;

namespace FolkLibrary.Application
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public UserInfoService(IUnitOfWork unitOfWork,
            IUserInfoRepository userInfoRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._userInfoRepository = userInfoRepository;
            this._mapper = mapper;
        }

        public async Task<IList<UserInfoView>> GetAll()
        {
            var entityList = _userInfoRepository.GetAll();
            return _mapper.Map<IList<UserInfoView>>(entityList).ToList();
        }
        public async Task<UserInfoView> Get(int id)
        {
            var userInfoEntity = _userInfoRepository.Get(id).FirstOrDefault();
            return _mapper.Map<UserInfoView>(userInfoEntity);
        }


        public async Task<bool> Add(UserInfoView userInfoView)
        {
            userInfoView.Password = userInfoView.Password.Md5Encode();
            var userInfoEntity = _mapper.Map<UserInfoEntity>(userInfoView);
            await _unitOfWork.RegisterNew<UserInfoEntity>(userInfoEntity);
            return await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// 验证登录信息
        /// </summary>
        /// <param name="userInfoView"></param>
        /// <returns>验证通过，则返回用户信息；否则，返回null</returns>
        public UserInfoView ValidateLogin(UserInfoView userInfoView)
        {
            var encodePwd = userInfoView.Password.Md5Encode();
            var tempData = _userInfoRepository.GetAll();
            if (!string.IsNullOrEmpty(userInfoView.AccountName))
            {
                tempData = tempData.Where(x => x.AccountName.Contains(userInfoView.AccountName));
            }

            if (!string.IsNullOrEmpty(userInfoView.UserName))
            {
                tempData = tempData.Where(x => x.UserName.Contains(userInfoView.UserName));
            }
            var userEntity = tempData.FirstOrDefault();
            if (tempData.Count() == 1 && userEntity != null)
            {
                return _mapper.Map<UserInfoView>(userEntity);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分页获取用户信息
        /// </summary>
        /// <param name="userInfo">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总记录数</param>
        /// <returns></returns>
        public IList<UserInfoView> SearchUserInfo(UserInfoView userInfo, int pageIndex, int pageSize, out int total)
        {
            var tempData = _userInfoRepository.GetAll();
            if (!string.IsNullOrEmpty(userInfo.AccountName))
            {
                tempData = tempData.Where(x => x.AccountName.Contains(userInfo.AccountName));
            }

            if (!string.IsNullOrEmpty(userInfo.UserName))
            {
                tempData = tempData.Where(x => x.UserName.Contains(userInfo.UserName));
            }
            total = tempData.Count();
            var dataList = tempData.OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return _mapper.Map<List<UserInfoView>>(dataList);
        }

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<bool> SaveUserInfo(UserInfoView userInfo)
        {
            var entity = _mapper.Map<UserInfoEntity>(userInfo);
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterNew(entity);
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <returns></returns>
        public async Task<bool> ResetPassword(string userInfoId)
        {
            var entity = _userInfoRepository.Get(Convert.ToInt32(userInfoId)).FirstOrDefault();
            if (entity != null)
            {
                entity.Password = StringHelper.Md5Encode("123456");
                _unitOfWork.BeginTransaction();
                await _unitOfWork.RegisterDirty(entity);
                bool flag = await _unitOfWork.CommitAsync();
                return flag;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userInfoId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserInfo(string userInfoId)
        {
            var entity = _userInfoRepository.Get(Convert.ToInt32(userInfoId)).FirstOrDefault();
            if (entity != null)
            {
                _unitOfWork.BeginTransaction();
                await _unitOfWork.RegisterDeleted(entity);
                bool flag = await _unitOfWork.CommitAsync();
                return flag;
            }
            else
            {
                return false;
            }
        }
    }
}
