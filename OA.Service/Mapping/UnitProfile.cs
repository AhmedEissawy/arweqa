using OA.Data.Domain;
using OA.Service.Implementation.UnitServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class UnitProfile : MappingProfileBase
    {
        public UnitProfile()
        {

            CreateMap<Unit, CreateUnitDto>().ReverseMap();
            
            
            CreateMap<Unit, UnitResponseDto>()
                .ForMember(dest => dest.UnitId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.SubjectName, opts => opts.MapFrom(src => src.Subject.SubjectName))
                .ForMember(dest => dest.SemesterName, opts => opts.MapFrom(src => src.Semester.SemesterName)).ReverseMap();
            

        }
    }
}
