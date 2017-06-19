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
    class LeaveWordProfile: Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<LeaveWordEntity, LeaveWordView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<LeaveWordView, LeaveWordEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));
        }
    }
}
