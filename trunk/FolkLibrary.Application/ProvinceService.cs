using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Infrastructure.Interface;
using System.Collections.Generic;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Application
{
    public class ProvinceService:IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public ProvinceService(IUnitOfWork unitOfWork,
            IProvinceRepository provinceRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._provinceRepository = provinceRepository;
            this._mapper = mapper;
        }

        public List<ProvinceView> GetAll()
        {
            var entityList = _provinceRepository.GetAll();
            return _mapper.Map<List<ProvinceView>>(entityList);
        }
    }
}
