using OA.Data.Domain;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using OA.Service.Implementation.LessonServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class GovernProfile : MappingProfileBase
    {
        public GovernProfile()
        {
            CreateMap<CreateGovernDto,Governorate>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}