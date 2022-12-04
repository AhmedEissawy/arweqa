using OA.Data.Domain;
using OA.Service.Implementation.GradeServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class GradeProfile : MappingProfileBase
    {
        public GradeProfile()
        {
            CreateMap <Grade , CreateGradeDto> ().ReverseMap();

            CreateMap<Grade, EditGradeDto>()
               .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<Grade, GradeResponseDto>()
                .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.Stage.Id))
                .ForMember(dest => dest.StageName, opts => opts.MapFrom(src => src.Stage.StageName)).ReverseMap();

        }
    }
}
