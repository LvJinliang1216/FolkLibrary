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
    public class ProjectDonationRefService : IProjectDonationRefService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectDonationRefRespository _projectDonationRefRespository;
        private readonly IMapper _mapper;

        public ProjectDonationRefService(IUnitOfWork unitOfWork,
            IProjectDonationRefRespository projectDonationRefRespository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._projectDonationRefRespository = projectDonationRefRespository;
            this._mapper = mapper;
        }

        public ProjectDonationRefEntity Get(int id)
        {
            return _projectDonationRefRespository.Get(id).FirstOrDefault();
        }

        public IList<ProjectDonationRefEntity> GetAll()
        {
            return _projectDonationRefRespository.GetAll().ToList();
        }

        /// <summary>
        /// 添加项目分类信息
        /// </summary>
        /// <param name="projectDonationRefEntity"></param>
        /// <returns></returns>
        public async Task<bool> CreateProjectClass(ProjectDonationRefEntity projectDonationRefEntity)
        {
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterNew(projectDonationRefEntity);
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }

        /// <summary>
        /// 删除项目分类信息
        /// </summary>
        /// <param name="projectDonationRefId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProjectClass(int projectDonationRefId)
        {
            var projectClassEntity = _projectDonationRefRespository.Get(projectDonationRefId).FirstOrDefault();
            if (projectClassEntity != null)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    await _unitOfWork.RegisterDeleted(projectClassEntity);
                    bool flag = await _unitOfWork.CommitAsync();
                    return flag;
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    throw ex;
                }

            }
            else
            {
                return false;
            }


        } 
    }
}
