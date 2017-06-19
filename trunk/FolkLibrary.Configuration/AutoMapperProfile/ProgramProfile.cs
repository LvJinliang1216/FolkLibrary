using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Domain.Entities;

namespace FolkLibrary.Configuration.AutoMapperProfile
{
    class ProgramProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<ProgramEntity, ProgramView>()
                .ForMember(dest => dest.ProgramId, src => src.MapFrom(x => x.Id));

            CreateMap<ProgramView, ProgramEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.ProgramId));


            CreateMap<ProgramEntity, UserAuthorityView>()
                .ForMember(dest => dest.ProgramId, src => src.MapFrom(x => x.Id))
                .ForMember(x => x.UserInfoId, src => src.Ignore());
        }
    }
}
