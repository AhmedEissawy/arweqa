using OA.Repo.Dtos;
using System;
using System.Collections.Generic;

namespace OA.Service.Implementation.SubjectGradeServices.Dtos
{
    public class SubjectResponseDto
    {
        public Guid TempSubjectId { get; set; }
        public Guid SubjectId { get; set; }

        public string SubjectName { get; set; }
       
        public string SubjectImage { get; set; }

       // public Guid SectionId { get; set; }

      //  public string SectionName { get; set; }

        public Guid StageId { get; set; }
        
        public string StageName { get; set; }

        public Guid GradeId { get; set; }
       
        public string GradeName { get; set; }

        public bool IsActive { get; set; }

        public int Index { get; set; }

        public List<PermessionsModel> Permessions { get; set; } = new List<PermessionsModel>();

        public List<SubjectSectionDto> SubjectSections { get; set; } = new List<SubjectSectionDto>();
        public List<SubjectBranchDto> SubjectBranches { get; set; } = new List<SubjectBranchDto>();
        public List<SubjectMzhbDto> SubjectMzhbs { get; set; } = new List<SubjectMzhbDto>();

    }

    public class SubjectResponsePermessions 
    {
        public string ModuleName { get; set; }
        public List<string> Permession { get; set; }
    }

    public class SubjectSectionDto
    {
        public Guid SectionId { get; set; }
    }
    public class SubjectBranchDto
    {
        public Guid BranchId { get; set; }
    }
    public class SubjectMzhbDto
    {
        public Guid MzhbId { get; set; }
    }
}
