using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Application
{
    public class AreaService:IAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaService(IUnitOfWork unitOfWork,
            IAreaRepository areaRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._areaRepository = areaRepository;
            this._mapper = mapper;
        }

        public IList<AreaView> GetAll()
        {
            var entityList = _areaRepository.GetAll().ToList();
            return _mapper.Map<IList<AreaView>>(entityList).ToList();
        }

        public IList<AreaView> Search(string cityId)
        {
            var entityList = _areaRepository.Search(cityId).ToList();
            return _mapper.Map<IList<AreaView>>(entityList).ToList();
        }
    }
}
