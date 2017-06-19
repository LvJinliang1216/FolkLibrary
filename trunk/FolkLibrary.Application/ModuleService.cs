using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ModuleService : IModuleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModuleRepository _moduleRepository;
        private readonly IProgramRepository _programRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public ModuleService(IUnitOfWork unitOfWork,
            IModuleRepository moduleRepository,
            IProgramRepository programRepository,
            IMapper mapper, IUserInfoRepository userInfoRepository)
        {
            this._unitOfWork = unitOfWork;
            this._programRepository = programRepository;
            this._moduleRepository = moduleRepository;
            this._mapper = mapper;
            this._userInfoRepository = userInfoRepository;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="moduleView">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总的数据条数</param>
        /// <returns></returns>
        public List<ModuleView> Search(ModuleView moduleView, int pageIndex, int pageSize, out int total)
        {
            var entityList = _moduleRepository.GetAll().OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            total = entityList.Count();
            var dataList = _mapper.Map<List<ModuleView>>(entityList);
            foreach (var item in dataList)
            {
                var userInfoEntity = _userInfoRepository.Get(item.UserInfoId).FirstOrDefault();
                var programEntities = _programRepository.GetAll().Where(x => x.ModuleId == item.ModuleId).ToList();
                item.UserInfoView = _mapper.Map<UserInfoView>(userInfoEntity);
                item.ProgramViews = _mapper.Map<List<ProgramView>>(programEntities);
            }
            return dataList;
        }

        /// <summary>
        /// 添加模块信息
        /// </summary>
        /// <param name="moduleView"></param>
        /// <returns></returns>
        public async Task<bool> CreateModule(ModuleView moduleView)
        {
            var entity = _mapper.Map<ModuleEntity>(moduleView);
            entity.CreateDateTime = DateTime.Now;
            entity.ModifyDateTime = DateTime.Now;
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterNew(entity);
            bool flag = await _unitOfWork.CommitAsync();
            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 修改模块信息
        /// </summary>
        /// <param name="moduleView"></param>
        /// <returns></returns>
        public async Task<bool> ModifyModule(ModuleView moduleView)
        {
            var entity = _moduleRepository.Get(moduleView.ModuleId).FirstOrDefault();
            if (entity != null)
            {
                entity.ModifyDateTime = DateTime.Now;
                entity.ModuleIcon = moduleView.ModuleIcon;
                entity.ModuleName = moduleView.ModuleName;
                entity.SortCode = moduleView.SortCode;
                entity.UserInfoId = moduleView.UserInfoId;
                _unitOfWork.BeginTransaction();
                await _unitOfWork.RegisterDirty(entity);
                bool flag = await _unitOfWork.CommitAsync();
                if (flag)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


        /// <summary>
        /// 删除模块信息
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteModule(int moduleId)
        {
            var entity = _moduleRepository.Get(moduleId).FirstOrDefault();
            if (entity != null)
            {
                var programList = _programRepository.GetAll().Where(x => x.ModuleId == entity.Id).ToList();
                _unitOfWork.BeginTransaction();
                foreach (var programItem in programList)
                {
                    await _unitOfWork.RegisterDeleted(programItem);
                }
                await _unitOfWork.RegisterDeleted(entity);
                bool flag = await _unitOfWork.CommitAsync();
                if (flag)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }
    }

}
