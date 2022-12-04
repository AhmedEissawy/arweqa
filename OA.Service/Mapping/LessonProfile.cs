using OA.Data.Domain;
using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using OA.Service.Implementation.LessonServices.Dtos;
using OA.Service.Implementation.UnitServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class LessonProfile : MappingProfileBase
    {
        public LessonProfile()
        {

            CreateMap<Lesson, LessonResponseDto>()
                .ForMember(dest => dest.LessonId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.UnitName, opts => opts.MapFrom(src => src.Unit.UnitName)).ReverseMap();

            CreateMap<LessonVideoRoom, LessonVideoRoomDto>().ReverseMap();
            CreateMap<Lesson, CreateLessonDto>().ForMember(a=>a.Rooms,d=>d.MapFrom(a=>a.Rooms)).ReverseMap();

           
        }
    }
}