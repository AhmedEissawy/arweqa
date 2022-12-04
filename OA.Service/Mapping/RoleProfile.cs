using Microsoft.AspNetCore.Identity;
using OA.Data.Domain;
using OA.Service.Implementation.RoleServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class RoleProfile : MappingProfileBase
    {

        public RoleProfile()
        {
            CreateMap<ApplicationRole, RoleResponseDto>()
                .ForMember(dest => dest.RoleId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoleName, opts => opts.MapFrom(src => src.Name)).ReverseMap();


        }
    }
}
