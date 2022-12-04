using OA.Data.Domain;
using OA.Service.Implementation.AnswerAttachmentServices.Dtos;
using OA.Service.Implementation.AnswerServices.Dtos;

namespace OA.Service.Mapping
{
    public class AnswerProfile : MappingProfileBase
    {
        public AnswerProfile()
        {
            CreateMap<Answer, CreateAnswerDto>().ReverseMap();

            CreateMap<AnswerAttachment, AnswerAttachmentDto>()
                .ForMember(dest => dest.AttachmentId, opts => opts.MapFrom(src => src.Id)).ReverseMap();



            CreateMap<Answer, AnswerResponseDto>()
                .ForMember(dest => dest.AnswerId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.SubjectName, opts => opts.MapFrom(src => src.Subject.SubjectName))
              //  .ForMember(dest => dest.SectionId, opts => opts.MapFrom(src => src.Subject.SectionId))
              //  .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.Subject.Section.SectionName))
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.Subject.Grade.StageId))
                .ForMember(dest => dest.StageName, opts => opts.MapFrom(src => src.Subject.Grade.Stage.StageName))
                .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.Subject.Grade.Id))
                .ForMember(dest => dest.GradeName, opts => opts.MapFrom(src => src.Subject.Grade.GradeName))
                .ForMember(dest => dest.Attachments, opts => opts.MapFrom(src => src.AnswerFiles))
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt"))).ReverseMap();

        }
    }
}
