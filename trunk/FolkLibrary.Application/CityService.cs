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
    public class CityService : ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityService(IUnitOfWork unitOfWork,
            ICityRepository cityRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._cityRepository = cityRepository;
            this._mapper = mapper;
        }

        public IList<CityView> GetAll()
        {
            var entityList = _cityRepository.GetAll().ToList();
            return _mapper.Map<IList<CityView>>(entityList).ToList();
        }

        public IList<CityView> Search(string provinceId)
        {
            var entityList = _cityRepository.Search(provinceId).ToList();
            return _mapper.Map<IList<CityView>>(entityList).ToList();
        }
    }
}
