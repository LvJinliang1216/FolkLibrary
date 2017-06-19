using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Domain.Entities;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Application
{
    public class WebSitInfoService : IWebSitInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebSitInfoRepository _webSiteInfoRepository;
        private readonly IMapper _mapper;

        public WebSitInfoService(IUnitOfWork unitOfWork,
            IWebSitInfoRepository webSiteInfoRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._webSiteInfoRepository = webSiteInfoRepository;
            this._mapper = mapper;
        }

        public List<WebSiteInfoView> GetAll(int pageIndex, int pageSize, out int total)
        {
            var dataList =
                _webSiteInfoRepository.GetAll()
                    .OrderBy(x => x.Id)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            total = dataList.Count();
            return _mapper.Map<List<WebSiteInfoView>>(dataList);
        }

        /// <summary>
        /// 获取网站信息
        /// </summary>
        /// <param name="webSiteInfoId"></param>
        /// <returns></returns>
        public WebSiteInfoView Get(int webSiteInfoId)
        {
            return _mapper.Map<WebSiteInfoView>(_webSiteInfoRepository.Get(webSiteInfoId).FirstOrDefault());
        }

        /// <summary>
        /// 添加网站信息
        /// </summary>
        /// <param name="webSiteInfoView"></param>
        /// <returns></returns>
        public async Task<bool> CreateWebSiteInfo(WebSiteInfoView webSiteInfoView)
        {
            var entity = _mapper.Map<WebSiteInfoEntity>(webSiteInfoView);
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterNew(entity);
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }

        /// <summary>
        /// 删除网站信息
        /// </summary>
        /// <param name="webSiteInfoId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteWebSiteInfo(int webSiteInfoId)
        {
            var entity = _webSiteInfoRepository.Get(webSiteInfoId).FirstOrDefault();
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterDeleted(entity);
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }

        /// <summary>
        /// 修改网站信息
        /// </summary>
        /// <param name="webSiteInfoView"></param>
        /// <returns></returns>
        public async Task<bool> ModifyWebSiteInfo(WebSiteInfoView webSiteInfoView)
        {
            var entity = _webSiteInfoRepository.Get(webSiteInfoView.WebSiteInfoId).FirstOrDefault();
            if (entity != null)
            {
                entity.Introduction = webSiteInfoView.Introduction;
                entity.WebSiteBrief = webSiteInfoView.WebSiteBrief;
                entity.WebSiteName = webSiteInfoView.WebSiteName;
                _unitOfWork.BeginTransaction();
                await _unitOfWork.RegisterDirty(entity);
            }
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }
    }
}
