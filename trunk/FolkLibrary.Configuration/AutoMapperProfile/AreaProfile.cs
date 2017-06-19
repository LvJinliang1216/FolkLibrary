using AutoMapper;
using FolkLibrary.DataTransferObject;
using FolkLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolkLibrary.Configuration.AutoMapperProfile
{
    public class AreaProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<AreaEntity, AreaView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<AreaView, AreaEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));
        }
    }
}
