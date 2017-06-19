using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.DataTransferObject.QueryModels;
using FolkLibrary.Domain.Entities;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Application
{
    public class LibraryInfoService : ILibraryInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryInfoRepository _libraryInfoRepository;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public LibraryInfoService(IUnitOfWork unitOfWork,
            IMapper mapper,
            ILibraryInfoRepository libraryInfoRepository,
            IAttachmentRepository attachmentRepository,
            IUserInfoRepository userInfoRepository,
            IAreaRepository areaRepository, ICityRepository cityRepository, IProvinceRepository provinceRepository)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._libraryInfoRepository = libraryInfoRepository;
            this._attachmentRepository = attachmentRepository;
            this._userInfoRepository = userInfoRepository;
            this._areaRepository = areaRepository;
            _cityRepository = cityRepository;
            _provinceRepository = provinceRepository;
        }
        /// <summary>
        /// 图书馆信息列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        public IList<LibraryInfoView> Search(LibraryInfoQueryView query, int pageIndex, int pageSize, out  int total)
        {
            var tempEntities = _libraryInfoRepository.GetAll();
            if (!string.IsNullOrEmpty(query.BuildUserName))
            {
                tempEntities = tempEntities.Where(x => x.BuildUserName.Contains(query.BuildUserName));
            }

            if (!string.IsNullOrEmpty(query.LibraryName))
            {
                tempEntities = tempEntities.Where(x => x.LibraryName.Contains(query.LibraryName));
            }

            if (query.StartDate.HasValue)
            {
                tempEntities = tempEntities.Where(x => x.BuildDate >= query.StartDate);
            }

            if (query.EndDate.HasValue)
            {
                tempEntities = tempEntities.Where(x => x.BuildDate <= query.EndDate);
            }
            total = tempEntities.Count();
            var tempData = tempEntities.OrderByDescending(x => x.ModifyDateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var dataList = _mapper.Map<IList<LibraryInfoView>>(tempData);
            foreach (var libraryInfoItem in dataList)
            {
                var item = libraryInfoItem;
                libraryInfoItem.AttachmentViews = _mapper.Map<List<AttachmentView>>(_attachmentRepository.GetAll().Where(x => x.FromId == item.LibraryInfoId && x.FromType == FromType.FolkLibray).ToList());
                libraryInfoItem.UserInfoView = _mapper.Map<UserInfoView>(_userInfoRepository.Get(libraryInfoItem.UserInfoId).FirstOrDefault());
                libraryInfoItem.AreaView = _mapper.Map<AreaView>(_areaRepository.Get(libraryInfoItem.AreaId).FirstOrDefault());
                libraryInfoItem.AreaView.CityView = _mapper.Map<CityView>(_cityRepository.Get(libraryInfoItem.AreaView.CityId).FirstOrDefault());
                libraryInfoItem.AreaView.CityView.ProvinceView = _mapper.Map<ProvinceView>(_provinceRepository.Get(libraryInfoItem.AreaView.CityView.ProvinceId).FirstOrDefault());
            }
            return dataList;
        }

        /// <summary>
        /// 添加项目分类信息
        /// </summary>
        /// <param name="libraryInfoView"></param>
        /// <returns></returns>
        public async Task<bool> CreateLibraryInfo(LibraryInfoView libraryInfoView)
        {
            var entity = _mapper.Map<LibraryInfoEntity>(libraryInfoView);
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
        /// <param name="libraryInfoView"></param>
        /// <returns></returns>
        public async Task<bool> ModifyLibraryInfo(LibraryInfoView libraryInfoView)
        {
            var entity = _libraryInfoRepository.Get(libraryInfoView.LibraryInfoId).FirstOrDefault();
            if (entity != null)
            {
                entity.BuildUserName = libraryInfoView.BuildUserName;
                entity.Address = libraryInfoView.Address;
                entity.AreaId = libraryInfoView.AreaId;
                entity.BuildDate = libraryInfoView.BuildDate;
                entity.BuildUserName = libraryInfoView.BuildUserName;
                entity.InformationFrom = libraryInfoView.InformationFrom;
                entity.LibraryDescription = libraryInfoView.LibraryDescription;
                entity.StaticPageUrl = libraryInfoView.StaticPageUrl;
                entity.UserInfoId = libraryInfoView.UserInfoId;
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
        /// <param name="libraryInfoId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLibraryInfo(int libraryInfoId)
        {
            var libraryInfoEntity = _libraryInfoRepository.Get(libraryInfoId).FirstOrDefault();
            if (libraryInfoEntity != null)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    var attachmentEntities = _attachmentRepository.GetAll().Where(x => x.FromId == libraryInfoEntity.Id && x.FromType == FromType.FolkLibray).ToList();
                    foreach (var attachmentItem in attachmentEntities)
                    {
                        await _unitOfWork.RegisterDeleted(attachmentItem);
                    }
                    await _unitOfWork.RegisterDeleted(libraryInfoEntity);
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
