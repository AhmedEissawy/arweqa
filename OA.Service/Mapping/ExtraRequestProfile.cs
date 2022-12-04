using OA.Data.Domain;
using OA.Service.Implementation.ExtraRequestServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class ExtraRequestProfile : MappingProfileBase
    {
        public ExtraRequestProfile()
        {
            CreateMap<ExtraRequest, CreateExtraRequestDto>().ReverseMap();

            CreateMap<ExtraRequest, EditExtraRequestDto>()
                .ForMember(dest => dest.ExtraRequestId, opts => opts.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<ExtraRequest, ExtraRequestResponseDto>()
                .ForMember(dest => dest.ExtraRequestId, opts => opts.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
