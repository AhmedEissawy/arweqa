using OA.Data.Domain;
using OA.Service.Implementation.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class AdminProfile : MappingProfileBase
    {
        public AdminProfile()
        {
            CreateMap<ApplicationUser, RegistrationDto>().ReverseMap();

            CreateMap<ApplicationUser, AdminResponseDto>()
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.UserFullName))
                .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.Section.SectionName)).ReverseMap();
        }

    }
}
