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
    public class AttachmentService : IAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public AttachmentService(IUnitOfWork unitOfWork,
            IMapper mapper, 
            IAttachmentRepository attachmentRepository)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            _attachmentRepository = attachmentRepository;
        }
    }
}
