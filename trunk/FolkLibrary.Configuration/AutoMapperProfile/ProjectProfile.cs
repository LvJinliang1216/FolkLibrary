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
    public class ProjectProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<ProjectEntity, ProjectView>()
                .ForMember(dest => dest.ProjectId, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.CreateTime, src => src.MapFrom(x => x.CreateDateTime))
                .ForMember(dest => dest.ModifyTime, src => src.MapFrom(x => x.ModifyDateTime));

            CreateMap<ProjectView, ProjectEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.ProjectId));
        }
    }
}
