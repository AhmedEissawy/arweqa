using Microsoft.AspNetCore.Routing.Constraints;
using OA.Data.Domain;
using OA.Service.Implementation.BranchServices.Dtos;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.MzhbServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class BranchProfile : MappingProfileBase
    {
        public BranchProfile()
        {
            CreateMap<CreateBranchDto,Branch>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Branch,ResponseBranchDto>()
               .ForMember(des => des.Id, d => d.MapFrom(src => src.Id))
               .ForMember(des => des.Name, d => d.MapFrom(src => src.Name))
               .ForMember(des => des.Message, d => d.MapFrom(Src => "anything"));
        }
    
    }
}