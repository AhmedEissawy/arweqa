using OA.Data.Domain;
using OA.Service.Implementation.RequestAttachmentServices.Dtos;
using OA.Service.Implementation.RequestServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class RequestProfile : MappingProfileBase
    {
        public RequestProfile()
        {
            CreateMap<Request, CreateRequestDto>().ReverseMap();


            CreateMap<RequestAttachment, RequestAttachmentDto>().ReverseMap();


            CreateMap<Request, MobileRequestResponseDto>()
                .ForMember(dest => dest.RequestId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.GradeName, opts => opts.MapFrom(src => src.Subject.Grade.GradeName))
                .ForMember(dest => dest.SubjectName, opts => opts.MapFrom(src => src.Subject.SubjectName))
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt"))).ReverseMap();


            CreateMap<Request, RequestResponseDto>()
                .ForMember(dest => dest.RequestId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.SubjectName, opts => opts.MapFrom(src => src.Subject.SubjectName))
                //.ForMember(dest => dest.SectionId, opts => opts.MapFrom(src => src.Subject.SectionId))
                //.ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.Subject.Section.SectionName))
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.Subject.Grade.StageId))
                .ForMember(dest => dest.StageName, opts => opts.MapFrom(src => src.Subject.Grade.Stage.StageName))
                .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.Subject.Grade.Id))
                .ForMember(dest => dest.GradeName, opts => opts.MapFrom(src => src.Subject.Grade.GradeName))
                .ForMember(dest => dest.Attachments, opts => opts.MapFrom(src => src.RequestFiles))
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt"))).ReverseMap();


            //Error Map 2020-10-19
           // ------------------------------------------------------------------------------------------------------------------------------
            CreateMap<Request, MobileTeacherRequestResponseDto>()
                .ForMember(dest => dest.Images, opts => opts.MapFrom(src => src.RequestFiles))
                .ReverseMap();

            CreateMap<RequestAttachment, MobileTeacherRequestResponseDto>()
               .ForMember(dest => dest.Images, opts => opts.MapFrom(src => src.Request.RequestFiles)).ReverseMap();
         
            // ------------------------------------------------------------------------------------------------------------------------------

        }
    }
}
