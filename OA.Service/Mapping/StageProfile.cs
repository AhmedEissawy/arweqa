using OA.Data.Domain;
using OA.Service.Implementation.StageServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class StageProfile : MappingProfileBase
    {
        public StageProfile()
        {
            CreateMap <Stage , CreateStageDto> ().ReverseMap();
          
            CreateMap <Stage , EditStageDto> ()
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.Id)).ReverseMap();

            CreateMap <Stage , StageResponseDto> ()
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.Id)).ReverseMap();

        }
    }
}
