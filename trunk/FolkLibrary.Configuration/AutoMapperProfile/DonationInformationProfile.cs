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
    class DonationInformationProfile : Profile
    {
        [Obsolete("Create a constructor and configure inside of your profile\'s constructor instead. Will be removed in 6.0")]
        protected override void Configure()
        {
            CreateMap<DonationInformationEntity, DonationInformationView>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.DonationDatetime, src => src.MapFrom(x => x.DonationDatetime.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.ProjectViews, src => src.MapFrom(x => x.ProjectEntities));

            CreateMap<DonationInformationView, DonationInformationEntity>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.DonationDatetime, src => src.MapFrom(x => Convert.ToDateTime(x.DonationDatetime)));
        }
    }
}
