using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;
using AutoMapper;
using FolkLibrary.Repository.Interface;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Application.Interface;
using FolkLibrary.Domain.Entities;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Application
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IProjectClassRepository _projectClassRepository;
        private readonly IProjectRepository _projectRepository;
        private IDonationInformationRepository _donationInformationRepository;
        private readonly IProjectDonationRefRespository _projectDonationRefRespository;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork,
            IProjectRepository projectRepository,
            IMapper mapper,
            IProjectDonationRefRespository projectDonationRefRespository,
            IUserInfoRepository userInfoRepository,
            IProjectClassRepository projectClassRepository,
            IDonationInformationRepository donationInformationRepository)
        {
            this._unitOfWork = unitOfWork;
            this._projectRepository = projectRepository;
            this._mapper = mapper;
            this._projectDonationRefRespository = projectDonationRefRespository;
            this._userInfoRepository = userInfoRepository;
            this._projectClassRepository = projectClassRepository;
            _donationInformationRepository = donationInformationRepository;
        }

        public ProjectView Get(int id)
        {
            return _mapper.Map<ProjectView>(_projectRepository.Get(id).FirstOrDefault());
        }

        public IList<ProjectView> GetAll()
        {
            var entityList = _projectRepository.GetAll().ToList();
            return _mapper.Map<IList<ProjectView>>(entityList).ToList();
        }

        /// <summary>
        /// 查询项目
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<ProjectView> Search(ProjectQuery query, int pageIndex, int pageSize, out int total)
        {
            var entityList = _projectRepository.GetAll();
            if (!string.IsNullOrEmpty(query.Title))
            {
                entityList = entityList.Where(x => x.Title.Contains(query.Title));
            }
            if (!string.IsNullOrEmpty(query.Title))
            {
                entityList = entityList.Where(x => x.Title.Contains(query.Title));
            }
            total = entityList.Count();
            var tempData = entityList.OrderBy(x => x.CreateDateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var dataList = _mapper.Map<IList<ProjectView>>(tempData);
            foreach (var item in dataList)
            {
                item.UserInfoView = _mapper.Map<UserInfoView>(_userInfoRepository.Get(item.UserInfoId).FirstOrDefault());
                item.ProjectClassView = _mapper.Map<ProjectClassView>(_projectClassRepository.Get(item.ProjectClassId).FirstOrDefault());
                var itemCopy = item;
                var refEntities = _projectDonationRefRespository.GetAll().Where(x => x.ProjectId == itemCopy.ProjectId);
                List<DonationInformationEntity> donationInformationEntities=new List<DonationInformationEntity>();
                foreach (var refItem in refEntities)
                {
                    donationInformationEntities.Add(_donationInformationRepository.Get(refItem.DonationInfoId).FirstOrDefault());
                }
                item.DonationInformationViews = _mapper.Map<List<DonationInformationView>>(donationInformationEntities);
            }
            return dataList;
        }

        /// <summary>
        /// 添加项目信息
        /// </summary>
        /// <param name="projectView"></param>
        /// <returns></returns>
        public async Task<bool> CreateProject(ProjectView projectView)
        {
            var entity = _mapper.Map<ProjectEntity>(projectView);
            entity.CreateDateTime = DateTime.Now;
            entity.ModifyDateTime = DateTime.Now;
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterNew(entity);
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }

        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="projectView"></param>
        /// <returns></returns>
        public async Task<bool> ModifyProject(ProjectView projectView)
        {
            var entity = _projectRepository.Get(projectView.ProjectId).FirstOrDefault();
            if (entity != null)
            {
                entity.StaticPageUrl = projectView.StaticPageUrl;
                entity.ProjectContent = projectView.ProjectContent;
                entity.SortCode = projectView.SortCode;
                entity.Title = projectView.Title;
                entity.PublishedTime = projectView.PublishedTime;
                entity.UserInfoId = projectView.UserInfoId;
                entity.ModifyDateTime = DateTime.Now;
                entity.ReadCount = projectView.ReadCount;
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
        /// 删除项目信息
        /// </summary>
        /// <param name="projectClassId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProject(int projectClassId)
        {
            var projectEntity = _projectRepository.Get(projectClassId).FirstOrDefault();
            if (projectEntity != null)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var projectDonationRefEntities = _projectDonationRefRespository.GetAll().Where(x => x.ProjectId == projectEntity.Id).ToList();
                    foreach (var projectItem in projectDonationRefEntities)
                    {
                        await _unitOfWork.RegisterDeleted(projectItem);
                    }
                    await _unitOfWork.RegisterDeleted(projectEntity);
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
