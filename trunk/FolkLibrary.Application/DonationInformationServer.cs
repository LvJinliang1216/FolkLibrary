using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Application
{
    public class DonationInformationServer : IDonationInformationServer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationInformationRepository _donationInformationRepository;
        private readonly IMapper _mapper;

        public DonationInformationServer(IUnitOfWork unitOfWork,
            IDonationInformationRepository donationInformationRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._donationInformationRepository = donationInformationRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// 获取详细信息
        /// </summary>
        /// <param name="donationInfoId"></param>
        /// <returns></returns>
        public DonationInformationView Get(int donationInfoId)
        {
            var entity = _donationInformationRepository.Get(donationInfoId).FirstOrDefault();
            return _mapper.Map<DonationInformationView>(entity);
        }

        /// <summary>
        /// 获取排名靠前的捐赠信息
        /// </summary>
        /// <param name="topAmount"></param>
        /// <returns></returns>
        public IList<DonationInformationView> GetHot(int topAmount)
        {

            var tempData = from data in _donationInformationRepository.GetAll()
                           orderby data.DonationAmount descending
                           select new DonationInformationView()
                           {
                               DonationAmount = data.DonationAmount,
                               DonationDatetime = data.DonationDatetime.ToString(),
                               DonationDetail = data.DonationDetail,
                               DonationInstruction = data.DonationInstruction,
                               DonationUserName = data.DonationUserName,
                               Id = data.Id
                               //ProjectViews = new List<ProjectView>()
                           };
            var dataList = tempData.Take(topAmount).ToList();
            foreach (var item in dataList)
            {
                var tempProject = _mapper.Map<List<ProjectView>>(_donationInformationRepository.GetAll().Where(x => x.Id == item.Id).FirstOrDefault().ProjectEntities);
                item.ProjectViews = tempProject;
            }
            return dataList;
        }

        /// <summary>
        /// 捐赠信息列表
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize"></param>
        /// <param name="total">总数</param>
        /// <returns></returns>
        public IList<DonationInformationView> Search(DonationInformationView query, int pageIndex, int pageSize, out  int total)
        {
            var tempData = _donationInformationRepository.GetAll();
            if (!string.IsNullOrEmpty(query.DonationDatetime))
            {
                tempData = tempData.Where(x => x.DonationDatetime.ToString("yyyyMMddhhmmss").Contains(query.DonationDatetime));
            }

            if (!string.IsNullOrEmpty(query.DonationUserName))
            {
                tempData = tempData.Where(x => x.DonationUserName.Contains(query.DonationUserName));
            }

            if (!string.IsNullOrEmpty(query.DonationInstruction))
            {
                tempData = tempData.Where(x => x.DonationInstruction.Contains(query.DonationInstruction));
            }
            total = tempData.Count();
            var dataList = tempData.OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return _mapper.Map<IList<DonationInformationView>>(dataList);
        }
    }
}
