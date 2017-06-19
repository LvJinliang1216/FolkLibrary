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
    public class FriendDepartmentService : IFriendDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFriendDepartmentRepository _friendDepartmentRepository;
        private readonly IMapper _mapper;

        public FriendDepartmentService(IUnitOfWork unitOfWork,
            IFriendDepartmentRepository friendDepartmentRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._friendDepartmentRepository = friendDepartmentRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// 获取相关单位信息
        /// </summary>
        /// <param name="friendDepartmentId"></param>
        /// <returns></returns>
        public FriendDepartmentView Get(int friendDepartmentId)
        {
            var entity = _friendDepartmentRepository.Get(friendDepartmentId).FirstOrDefault();
            if (entity != null)
            {
                return _mapper.Map<FriendDepartmentView>(entity);
            }
            else
            {
                return new FriendDepartmentView();
            }
        }

        /// <summary>
        /// 查询相关单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<FriendDepartmentView> Search(FriendDepartmentView friendDepartmentView, int pageIndex, int pageSize, out int total)
        {
            var tempData = _friendDepartmentRepository.GetAll();
            if (friendDepartmentView != null && !string.IsNullOrEmpty(friendDepartmentView.DepartmentDescn))
            {
                tempData = tempData.Where(x => x.DepartmentDescn.Contains(friendDepartmentView.DepartmentDescn));
            }
            total = tempData.Count();
            var dataList = tempData.OrderBy(x => x.ModifyDateTime).Skip((pageIndex - 1)* pageSize).Take(pageSize).ToList();
            return _mapper.Map<List<FriendDepartmentView>>(dataList);
        }

        /// <summary>
        /// 添加相关单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <returns></returns>
        public async Task<bool> CreateFriendDepartment(FriendDepartmentView friendDepartmentView)
        {
            if (friendDepartmentView != null)
            {
                var entity = _mapper.Map<FriendDepartmentEntity>(friendDepartmentView);
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
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改相关单位信息
        /// </summary>
        /// <param name="friendDepartmentView"></param>
        /// <returns></returns>
        public async Task<bool> ModifyFriendDepartment(FriendDepartmentView friendDepartmentView)
        {
            var entity = _friendDepartmentRepository.Get(friendDepartmentView.Id).FirstOrDefault();
            if (entity != null)
            {
                entity.ModifyDateTime = DateTime.Now;
                entity.DepartmentDescn = friendDepartmentView.DepartmentDescn;
                entity.FriendDepartmentUrl = friendDepartmentView.FriendDepartmentUrl;
                entity.UserInfoId = friendDepartmentView.UserInfoId;
                entity.WebSitInfoId = friendDepartmentView.WebSitInfoId;
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
        /// 删除相关单位信息
        /// </summary>
        /// <param name="friendDepartmentId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFriendDepartment(int friendDepartmentId)
        {
            var entity = _friendDepartmentRepository.Get(friendDepartmentId).FirstOrDefault();
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
    }
}
