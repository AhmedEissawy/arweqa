using OA.Data.Domain;
using OA.Service.Implementation.SectionServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class SectionProfile : MappingProfileBase
    {
        public SectionProfile()
        {
            CreateMap<CreateSectionDto,Section>().ReverseMap();

            CreateMap<Section, SectionResponseDto>()
                .ForMember(dest => dest.SectionId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.SectionName))
                .ForMember(dest => dest.Index, opts => opts.MapFrom(src => src.Index))
                .ForMember(dest => dest.IsActive, opts => opts.MapFrom(src => src.IsActive))
                .ReverseMap();

            CreateMap<Section, EditSectionDto>()
                .ForMember(dest => dest.SectionId, opts => opts.MapFrom(src => src.Id)).ReverseMap();

            

        }

    }
}