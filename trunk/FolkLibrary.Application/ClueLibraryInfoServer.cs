using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface;
using FolkLibrary.Repository.Interface.IRepository;
using FolkLibrary.Domain.Entities;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Application
{
    public class ClueLibraryInfoServer : IClueLibraryInfoServer
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClueLibraryInfoRepository _clueLibraryInfoRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public ClueLibraryInfoServer(IUnitOfWork unitOfWork,
            IAreaRepository areaRepository,
            IClueLibraryInfoRepository clueLibraryInfoRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._areaRepository = areaRepository;
            this._clueLibraryInfoRepository = clueLibraryInfoRepository;
            this._mapper = mapper;
        }
        /// <summary>
        /// 添加图书馆信息
        /// </summary>
        /// <param name="leaveWord"></param>
        /// <returns></returns>
        public async Task<bool> Save(ClueView clue)
        {
            var entity = _mapper.Map<ClueLibraryInfoEntity>(clue);
            //entity.AreaEntity = _areaRepository.Get(entity.AreaId).FirstOrDefault();
            _unitOfWork.BeginTransaction();
            await _unitOfWork.RegisterNew(entity);
            bool flag =  await _unitOfWork.CommitAsync();
            return flag;
        }

    }
}
