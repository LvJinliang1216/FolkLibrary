using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Domain.Entities;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Application
{
    public class UserAuthorityService : IUserAuthorityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAuthorityRepository _userAuthorityRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IProgramRepository _programRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public UserAuthorityService(IUnitOfWork unitOfWork,
            IUserAuthorityRepository userAuthorityRepository,
            IMapper mapper, IUserInfoRepository userInfoRepository, IProgramRepository programRepository, IModuleRepository moduleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userAuthorityRepository = userAuthorityRepository;
            this._mapper = mapper;
            _userInfoRepository = userInfoRepository;
            _programRepository = programRepository;
            _moduleRepository = moduleRepository;
        }

        /// <summary>
        /// 权限信息列表
        /// </summary>
        /// <param name="userAuthorityView"></param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        public IList<UserAuthorityView> Search(UserAuthorityView userAuthorityView, int pageIndex, int pageSize, out  int total)
        {
            var tempProgramData = _programRepository.GetAll().ToList();
            var tempData = _userAuthorityRepository.GetAll();
            if (userAuthorityView.UserInfoId != 0)
            {
                tempData = tempData.Where(x => x.UserInfoId == userAuthorityView.UserInfoId);
                total = tempProgramData.Count();
                var entities = tempData.OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                var dataList = _mapper.Map<IList<UserAuthorityView>>(tempProgramData);
                foreach (var userAuthority in dataList)
                {
                    var userAuthorityEntity = entities.FirstOrDefault(x => x.ProgramId == userAuthority.ProgramId);
                    if (userAuthorityEntity != null)
                        userAuthority.UserAuthorityId = userAuthorityEntity.Id;
                    userAuthority.UserInfoId = userAuthorityView.UserInfoId;
                    userAuthority.IsAuthority = entities.Count(x => x.ProgramId == userAuthority.ProgramId) > 0;
                    userAuthority.UserInfoView = _mapper.Map<UserInfoView>(_userInfoRepository.Get(userAuthorityView.UserInfoId).FirstOrDefault());
                    userAuthority.ProgramView = _mapper.Map<ProgramView>(_programRepository.Get(userAuthority.ProgramId).FirstOrDefault());
                    userAuthority.ProgramView.ModuleView = _mapper.Map<ModuleView>(_moduleRepository.Get(userAuthority.ProgramView.ModuleId).FirstOrDefault());
                }
                return dataList;
            }
            total = 0;

            return new List<UserAuthorityView>();
        }

        /// <summary>
        /// 添加用户权限
        /// </summary>
        /// <param name="userAuthorityView"></param>
        /// <returns></returns>
        public async Task<bool> CreateUserAuthority(UserAuthorityView userAuthorityView)
        {
            var entity = _mapper.Map<UserAuthorityEntity>(userAuthorityView);
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterNew(entity);
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="userAuthorityId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserAuthority(int userAuthorityId)
        {
            var projectEntity = _userAuthorityRepository.Get(userAuthorityId).FirstOrDefault();
            if (projectEntity != null)
            {
                _unitOfWork.BeginTransaction();
                await _unitOfWork.RegisterDeleted(projectEntity);
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
