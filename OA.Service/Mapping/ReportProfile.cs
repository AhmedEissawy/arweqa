using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Service.Implementation.ReportServices.Dtos;

namespace OA.Service.Mapping
{
    public class ReportProfile : MappingProfileBase
    {
        public ReportProfile()
        {

            CreateMap<ReportFilter, ReportFilterDto>().ReverseMap();

            CreateMap<TeacherReportFilter, TeacherReportFilterDto>().ReverseMap();

            CreateMap<Request, RequestsReportDto>()
                .ForMember(dest => dest.RequestId, opts => opts.MapFrom(src => src.Id))
              //  .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.Subject.Section.SectionName))
                .ForMember(dest => dest.SubjectName, opts => opts.MapFrom(src => src.Subject.SubjectName))
                .ForMember(dest => dest.GradeName, opts => opts.MapFrom(src => src.Subject.Grade.GradeName))
                .ForMember(dest => dest.TeacherName, opts => opts.MapFrom(src => src.Teacher.User.UserFullName))
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt")))
                .ForMember(dest => dest.TeacherName, opts => opts.MapFrom(src => src.Teacher.User.UserFullName))
                .ForMember(dest => dest.StudentName, opts => opts.MapFrom(src => src.Student.User.UserFullName)).ReverseMap();

            CreateMap<DashboardReport, DashboardReportDto>().ReverseMap();

        }

    }
}
