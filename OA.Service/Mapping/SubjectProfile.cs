using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Service.Implementation.SubjectGradeServices.Dtos;
namespace OA.Service.Mapping
{
    public class SubjectProfile : MappingProfileBase
    {
        public SubjectProfile()
        {
            CreateMap <CreateSubjectDto, SubjectGrade> ()
                .ForMember(a=>a.SubjectSections,d=>d.MapFrom(a=>a.SubjectSections))
                .ForMember(a=>a.SubjectMzhbs,d=>d.MapFrom(a=>a.SubjectMzhbs))
                .ForMember(a=>a.SubjectBranches,d=>d.MapFrom(a=>a.SubjectBranches))
                .ReverseMap();

            CreateMap<CreateSubjectSectionDto, SubjectSection>()
                .ForMember(a => a.SectionId, d => d.MapFrom(a => a.SectionId)).ReverseMap();

            CreateMap<CreateSubjectMzhbDto, SubjectMzhb>()
                .ForMember(a => a.MzhbId, d => d.MapFrom(a => a.MzhbId)).ReverseMap();

            CreateMap<CreateSubjectBranchDto, SubjectBranch>()
               .ForMember(a => a.BranchId, d => d.MapFrom(a => a.BranchId)).ReverseMap();

            CreateMap<SubjectGrade, EditSubjectDto>()
                .ForMember(dest => dest.SubjectId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Index, opts => opts.MapFrom(src => src.Index))
                .ForMember(dest => dest.SubjectName, opts => opts.MapFrom(src => src.SubjectName))
                .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.GradeId))
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.Grade.StageId))
                .ForMember(dest => dest.SubjectSections, opts => opts.MapFrom(src => src.SubjectSections))
                .ForMember(a => a.SubjectMzhbs, d => d.MapFrom(a => a.SubjectMzhbs))
                .ForMember(a => a.SubjectBranches, d => d.MapFrom(a => a.SubjectBranches))
                .ReverseMap();

            CreateMap<SubjectSection, SubjectSectionDto>()
               .ForMember(des => des.SectionId, opts => opts.MapFrom(src => src.SectionId)).ReverseMap();

            CreateMap<SubjectMzhb, SubjectMzhbDto>()
              .ForMember(des => des.MzhbId, opts => opts.MapFrom(src => src.MzhbId)).ReverseMap();

            CreateMap<SubjectBranch, SubjectBranchDto>()
              .ForMember(des => des.BranchId, opts => opts.MapFrom(src => src.BranchId)).ReverseMap();



            CreateMap<SubjectGrade, SubjectResponseDto>()
                .ForMember(dest => dest.TempSubjectId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.SubjectId, opts => opts.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.SectionName, opts => opts.MapFrom(src => src.Section.SectionName))
                .ForMember(dest => dest.StageName, opts => opts.MapFrom(src => src.Grade.Stage.StageName))
                .ForMember(dest => dest.GradeName, opts => opts.MapFrom(src => src.Grade.GradeName))
                .ForMember(dest => dest.StageId, opts => opts.MapFrom(src => src.Grade.StageId))
                .ForMember(dest => dest.SubjectSections, opts => opts.MapFrom(src => src.SubjectSections))
                .ForMember(dest => dest.SubjectMzhbs, opts => opts.MapFrom(src => src.SubjectMzhbs))
                .ForMember(dest => dest.SubjectBranches, opts => opts.MapFrom(src => src.SubjectBranches))
                .ForMember(dest => dest.Permessions, opts => opts.Ignore())
                .ForMember(dest => dest.GradeId, opts => opts.MapFrom(src => src.GradeId)).ReverseMap();
            
            
            CreateMap<SubjectGrade, MobileSubjectResponseDto>()
                .ForMember(dest => dest.SubjectImage, opts => opts.MapFrom(src => src.SubjectImage == null ? ImageAvatar.PhotoAvatar : src.SubjectImage))
                .ForMember(dest => dest.SubjectId, opts => opts.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
