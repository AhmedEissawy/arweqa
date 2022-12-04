using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Service.Implementation.SubjectGradeServices.Dtos;
using OA.Service.Implementation.TeacherServices.Dtos;
using OA.Service.Implementation.TeacherSubjectServices.Dtos;

namespace OA.Service.Mapping
{
    public class TeacherProfile : MappingProfileBase
    {
        public TeacherProfile()
        {
            CreateMap<ApplicationUser, CreateTeacherDto>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.UserFullName))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.PhoneNumber))
                .ReverseMap();


            CreateMap<Teacher, CreateTeacherDto>().ReverseMap();


            CreateMap<Teacher, EditTeacherDto>()
                .ForMember(dest => dest.TeacherId, opts => opts.MapFrom(src => src.Id))
                .ReverseMap();


            CreateMap<Teacher, AddSubjectsToTeacherDto>()
                .ForMember(dest => dest.TeacherId, opts => opts.MapFrom(src => src.Id)).ReverseMap();


            CreateMap<Teacher, TeacherResponseDto>()
                 .ForMember(dest => dest.TeacherId, opts => opts.MapFrom(src => src.Id))
                .ReverseMap();



            CreateMap<Teacher, TeacherResponseDto>()
                .ForMember(dest => dest.TeacherId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.User.UserFullName))
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.User.IsActive))
                .ForMember(dest => dest.Subjects, opts => opts.MapFrom(src => src.TeacherSubjects)).ReverseMap();


            CreateMap<TeacherSubject, SubjectResponseDto>()
                .ForMember(dest => dest.TempSubjectId, opts => opts.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.SubjectName, opts => opts.MapFrom(src => src.Subject.SubjectName))
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.Subject.Grade.StageId))
               // .ForMember(dest => dest.SectionId, opts => opts.MapFrom(src => src.Subject.SectionId))
               // .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.Subject.Section.SectionName))
                .ForMember(dest => dest.StageName, opts => opts.MapFrom(src => src.Subject.Grade.Stage.StageName))
                .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.Subject.GradeId))
                .ForMember(dest => dest.GradeName, opts => opts.MapFrom(src => src.Subject.Grade.GradeName)).ReverseMap();



        }
    }
}

