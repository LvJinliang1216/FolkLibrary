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
    public class ProgramService : IProgramService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProgramRepository _programRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public ProgramService(IUnitOfWork unitOfWork,
            IProgramRepository programRepository,
            IMapper mapper, IUserInfoRepository userInfoRepository)
        {
            this._unitOfWork = unitOfWork;
            this._programRepository = programRepository;
            this._mapper = mapper;
            this._userInfoRepository = userInfoRepository;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="programView">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总的数据条数</param>
        /// <returns></returns>
        public List<ProgramView> Search(ProgramView programView, int pageIndex, int pageSize, out int total)
        {
            var entityList = _programRepository.GetAll();
            if (programView != null && programView.ModuleId != 0)
            {
                entityList = entityList.Where(x => x.ModuleId == programView.ModuleId);
            }
            var tempData = entityList.OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            total = entityList.Count();
            var dataList = _mapper.Map<List<ProgramView>>(tempData);
            foreach (var item in dataList)
            {
                var userInfoEntity = _userInfoRepository.Get(item.UserInfoId).FirstOrDefault();
                var programEntities = _programRepository.GetAll().Where(x => x.ModuleId == item.ModuleId).ToList();
                item.UserInfoView = _mapper.Map<UserInfoView>(userInfoEntity);
            }
            return dataList;
        }

        /// <summary>
        /// 添加模块信息
        /// </summary>
        /// <param name="programView"></param>
        /// <returns></returns>
        public async Task<bool> CreateProgram(ProgramView programView)
        {
            var entity = _mapper.Map<ProgramEntity>(programView);
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
        /// <param name="programView"></param>
        /// <returns></returns>
        public async Task<bool> ModifyProgram(ProgramView programView)
        {
            var entity = _programRepository.Get(programView.ProgramId).FirstOrDefault();
            if (entity != null)
            {
                entity.ModifyDateTime = DateTime.Now;
                entity.PageIcon = programView.PageIcon;
                entity.ProgramName = programView.ProgramName;
                entity.SortCode = programView.SortCode;
                entity.UserInfoId = programView.UserInfoId;
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
        /// <param name="programId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProgram(int programId)
        {
            var entity = _programRepository.Get(programId).FirstOrDefault();
            if (entity != null)
            {
                _unitOfWork.BeginTransaction();
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
