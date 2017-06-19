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
    public class ModuleProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<ModuleEntity, ModuleView>()
                .ForMember(dest => dest.ModuleId, src => src.MapFrom(x => x.Id));

            CreateMap<ModuleView, ModuleEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.ModuleId));
        }
    }
}
