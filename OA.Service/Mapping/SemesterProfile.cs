using OA.Data.Domain;
using OA.Service.Implementation.SemesterServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class SemesterProfile : MappingProfileBase
    {
        public SemesterProfile()
        {
            CreateMap<Semester, CreateSemesterDto>().ReverseMap();


            CreateMap<Semester, SemesterResponseDto>()
                .ForMember(dest => dest.SemesterId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.StartDate, opts => opts.MapFrom(src => src.StartDate.ToString("yyyy/MM/dd")))
                .ForMember(dest => dest.EndDate, opts => opts.MapFrom(src => src.EndDate.ToString("yyyy/MM/dd"))).ReverseMap();  
            
     
        }
    }
}
