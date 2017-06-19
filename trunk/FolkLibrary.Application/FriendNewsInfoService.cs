using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FolkLibrary.Application.Interface;
using FolkLibrary.Infrastructure.Interface;
using FolkLibrary.Repository.Interface.IRepository;

namespace FolkLibrary.Application
{
    public class FriendNewsInfoService : IFriendNewsInfoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFriendNewsInfoService _friendNewsInfoService;
        private readonly IMapper _mapper;

        public FriendNewsInfoService(IUnitOfWork unitOfWork,
            IFriendNewsInfoService friendNewsInfoService,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._friendNewsInfoService = friendNewsInfoService;
            this._mapper = mapper;
        }
    }
}
