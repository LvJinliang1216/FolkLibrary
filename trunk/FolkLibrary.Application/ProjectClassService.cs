using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class ProjectClassService : IProjectClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectClassRepository _projectClassRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IMapper _mapper;

        public ProjectClassService(IUnitOfWork unitOfWork,
            IProjectClassRepository projectClassRepository,
            IProvinceRepository provinceRepository,
            IMapper mapper, IProjectRepository projectRepository, IUserInfoRepository userInfoRepository)
        {
            this._provinceRepository = provinceRepository;
            this._unitOfWork = unitOfWork;
            this._projectClassRepository = projectClassRepository;
            this._mapper = mapper;
            _projectRepository = projectRepository;
            _userInfoRepository = userInfoRepository;
        }

        public IList<ProjectClassView> GetAll()
        {
            var entityList = _projectClassRepository.GetAll().ToList();
            return _mapper.Map<IList<ProjectClassView>>(entityList).ToList();
        }

        /// <summary>
        /// 按照省份进行查询获取数据
        /// </summary>
        /// <param name="provinceCode"></param>
        /// <returns></returns>
        public IList<ProjectClassView> Search(string provinceCode)
        {
            var entityList = _projectClassRepository.Search(provinceCode).ToList();
            return _mapper.Map<IList<ProjectClassView>>(entityList);
        }

        /// <summary>
        /// 查询项目分类信息
        /// </summary>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public IList<ProjectClassView> Search(ProjectQuery query, int pageIndex, int pageSize, out int total)
        {
            var entityList = _projectClassRepository.GetAll();
            if (!string.IsNullOrEmpty(query.CreateDatetime))
            {
                entityList = entityList.Where(x => x.CreateDateTime.ToString().Contains(query.CreateDatetime));
            }
            if (!string.IsNullOrEmpty(query.ProvinceId))
            {
                entityList = entityList.Where(x => x.ProvinceId.ToString() == query.ProvinceId);
            }
            if (!string.IsNullOrEmpty(query.Title))
            {
                entityList = entityList.Where(x => x.Title.Contains(query.Title));
            }
            total = entityList.Count();
            var tempData = entityList.OrderBy(x => x.SortCode).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var dataList = _mapper.Map<IList<ProjectClassView>>(tempData);
            foreach (var item in dataList)
            {
                item.UserInfoView = _mapper.Map<UserInfoView>(_userInfoRepository.Get(item.UserInfoId).FirstOrDefault());
                item.ProvinceView = _mapper.Map<ProvinceView>(_provinceRepository.Get(item.ProvinceId).FirstOrDefault());
            }
            return dataList;
        }

        /// <summary>
        /// 获取项目分类信息【按照省份进行分组】
        /// </summary>
        /// <returns></returns>
        public IList<ProvinceWithProjectClassView> GroupByProvince()
        {
            List<ProvinceWithProjectClassView> dataList = new List<ProvinceWithProjectClassView>();
            var data = _provinceRepository.GetAll();
            foreach (var item in data)
            {
                if (dataList.Count(x => x.ProvinceCode == item.ProvinceCode) == 0)
                {
                    dataList.Add(new ProvinceWithProjectClassView()
                    {
                        Id = item.Id,
                        ProvinceName = item.ProvinceName,
                        ProvinceCode = item.ProvinceCode,
                        ProjectViews = _mapper.Map<List<ProjectClassView>>(_projectClassRepository.Search(item.ProvinceCode).ToList())
                    });
                }
            }
            return dataList;
        }


        /// <summary>
        /// 添加项目分类信息
        /// </summary>
        /// <param name="projectClassView"></param>
        /// <returns></returns>
        public async Task<bool> CreateProjectClass(ProjectClassView projectClassView)
        {
            var entity = _mapper.Map<ProjectClassEntity>(projectClassView);
            entity.CreateDateTime = DateTime.Now;
            entity.ModifyDateTime = DateTime.Now;
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterNew(entity);
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }

        /// <summary>
        /// 修改项目分类信息
        /// </summary>
        /// <param name="projectClassView"></param>
        /// <returns></returns>
        public async Task<bool> ModifyProjectClass(ProjectClassView projectClassView)
        {
            var entity = _projectClassRepository.Get(projectClassView.ProjectClassId).FirstOrDefault();
            if (entity != null)
            {
                entity.ProvinceId = projectClassView.ProvinceId;
                entity.Title = projectClassView.Title;
                entity.Description = projectClassView.Description;
                entity.SortCode = projectClassView.SortCode;
                entity.UserInfoId = projectClassView.UserInfoId;
                entity.ModifyDateTime = DateTime.Now;
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
        /// 删除项目分类信息
        /// </summary>
        /// <param name="projectClassId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProjectClass(int projectClassId)
        {
            var projectClassEntity = _projectClassRepository.Get(projectClassId).FirstOrDefault();
            if (projectClassEntity != null)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var projectEntities = _projectRepository.GetAll().Where(x => x.ProjectClassId == projectClassEntity.Id).ToList();
                    foreach (var projectItem in projectEntities)
                    {
                        await _unitOfWork.RegisterDeleted(projectItem);
                    }
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
