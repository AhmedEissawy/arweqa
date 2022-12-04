using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.StudentServices.Dtos;
using OA.Service.Implementation.UserServices.Dtos;
using System.Collections.Generic;

namespace OA.Service.Mapping
{
    public class StudentProfile : MappingProfileBase
    {
        public StudentProfile()
        {
            CreateMap<RegisterStudentDto, Student>()
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender))
                .ForMember(dest => dest.GovernorateId, opts => opts.MapFrom(src => src.GovernId))
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.StageId))
                .ForMember(dest => dest.SectionId, opts => opts.MapFrom(src => src.SectionId))
                .ForMember(dest => dest.MzhbId, opts => opts.MapFrom(src => src.MzhbId))
                .ForMember(dest => dest.BranchId, opts => opts.MapFrom(src => src.BranchId)) 
                .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.GradeId)) 
                .ForMember(dest => dest.ProfileImage, opts => opts.MapFrom(src => src.Image)) 
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                .ForMember(dest => dest.Institue_Name, opts => opts.MapFrom(src => src.InstituteName));

            CreateMap<Governorate,GovernResponseDto>()
               .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ReverseMap();

            CreateMap<RegisterStudentDto, ApplicationUser>()
                .ForMember(dest => dest.UserFullName, opts => opts.MapFrom(src => src.UserFullName))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.Phone))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserImage, opts => opts.MapFrom(src => src.Image))
                .ForMember(dest => dest.Student, opts => opts.MapFrom(src => src));
               
            
            CreateMap<Student, CreateStudentDto>()
                .ForMember(a=>a.ProfileImage,d=>d.Ignore()).ReverseMap();


            CreateMap<Student, EditStudentDto>().ReverseMap();

            CreateMap<Student, AdminEditStudentDto>()
                .ForMember(dest => dest.StudentId, opts => opts.MapFrom(src => src.Id)).ReverseMap();


            CreateMap<StudentLoginResponseDto, StudentLoginDto>().ReverseMap();


            CreateMap<Student, StudentResponseDto>()
                .ForMember(dest => dest.Mobile, opts => opts.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.User.UserFullName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.SectionId, opts => opts.MapFrom(src => src.User.SectionId))
                .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.User.Section.SectionName))
                .ForMember(dest => dest.StudentId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.User.GradeId))
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.User.Grade.StageId))
                .ForMember(dest => dest.StageName, opts => opts.MapFrom(src => src.User.Grade.Stage.StageName))
                .ForMember(dest => dest.GradeName, opts => opts.MapFrom(src => src.User.Grade.GradeName))
                .ForMember(dest => dest.IsActive, opts => opts.MapFrom(src => src.User.IsActive))
                .ForMember(dest => dest.ProfileImage, opts => opts.MapFrom(src => src.ProfileImage))
                .ForMember(dest => dest.InstituteName, opts => opts.MapFrom(src => src.Institue_Name))
                .ForMember(dest => dest.MzhbName, opts => opts.MapFrom(src => src.Mzhb.Name))
                .ForMember(dest => dest.GovernmentName, opts => opts.MapFrom(src => src.Governorate.Name))
                .ForMember(dest => dest.BranchName, opts => opts.MapFrom(src => src.Branch.Name))
                .ForMember(dest => dest.CityName, opts => opts.MapFrom(src => src.City))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender))
                .ReverseMap();



        }
    }
}