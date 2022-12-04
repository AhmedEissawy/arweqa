using OA.Data.Domain;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.MzhbServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class MzhbProfile : MappingProfileBase
    {
        public MzhbProfile()
        {
            CreateMap<MzhbCreateDto,Mzhb>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Mzhb, MzhbResponseDto>()
                .ForMember(des => des.Id, d => d.MapFrom(src => src.Id))
                .ForMember(des => des.Name, d => d.MapFrom(src => src.Name))
                .ForMember(des => des.Message, d => d.MapFrom(src => "anything"));
        }
    }
}