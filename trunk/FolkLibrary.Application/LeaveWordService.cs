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
    public class LeaveWordService : ILeaveWordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILeaveWordRepository _leaveWordRepository;
        private readonly IMapper _mapper;

        public LeaveWordService(IUnitOfWork unitOfWork,
            ILeaveWordRepository leaveWordRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._leaveWordRepository = leaveWordRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="leaveWord"></param>
        /// <returns></returns>
        public async Task<bool> Save(LeaveWordView leaveWord)
        {
            var entity = _mapper.Map<LeaveWordEntity>(leaveWord);
            _unitOfWork.BeginTransaction();
             await _unitOfWork.RegisterNew(entity);
            bool flag = await _unitOfWork.CommitAsync();
            return flag;
        }
        /// <summary>
        /// 获取全部留言信息
        /// </summary>
        /// <returns></returns>
        public async Task<IList<LeaveWordView>> GetAll()
        {
            var entityList = _leaveWordRepository.GetAll();
            return _mapper.Map<IList<LeaveWordView>>(entityList).ToList();
        }

        /// <summary>
        /// 分页获取留言信息
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="leaveWordQueryView"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IList<LeaveWordView> SearchLeaveWord(LeaveWordQueryView leaveWordQueryView, int pageIndex, int pageSize, out int total)
        {
            var tempData = _leaveWordRepository.GetAll();
            if (leaveWordQueryView.StarTime.HasValue)
            {
                tempData = tempData.Where(x => x.CreateDateTime >= leaveWordQueryView.StarTime);
            }

            if (leaveWordQueryView.EndTime.HasValue)
            {
                tempData = tempData.Where(x => x.CreateDateTime <= leaveWordQueryView.EndTime);
            }
            total = tempData.Count();
            var dataList = tempData.OrderBy(x => x.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return _mapper.Map<List<LeaveWordView>>(dataList);
        }
        /// <summary>
        /// 删除留言信息
        /// </summary>
        /// <param name="leaveWordId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteLeaveWord(string leaveWordId)
        {
            var entity = _leaveWordRepository.Get(Convert.ToInt32(leaveWordId)).FirstOrDefault();
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
