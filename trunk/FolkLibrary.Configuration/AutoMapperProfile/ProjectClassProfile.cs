using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FolkLibrary.Domain.Entities;
using FolkLibrary.DataTransferObject;

namespace FolkLibrary.Configuration.AutoMapperProfile
{
    public class ProjectClassProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<ProjectClassEntity, ProjectClassView>()
                .ForMember(dest => dest.ProjectClassId, src => src.MapFrom(x => x.Id));

            CreateMap<ProjectClassView, ProjectClassEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.ProjectClassId));
        }
    }
}
