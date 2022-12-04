using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace OA.Service.Implementation.SubjectGradeServices.Dtos
{
    public class CreateSubjectDto
    {    
                  
        public Guid GradeId { get; set; }
        public Guid StageId { get; set; }
             

        public string SubjectName { get; set; }

       public IFormFile SubjectImage { get; set; }

        public int Index { get; set; }
        public List<CreateSubjectSectionDto> SubjectSections { get; set; } = new List<CreateSubjectSectionDto>();
        public List<CreateSubjectBranchDto> SubjectBranches { get; set; } = new List<CreateSubjectBranchDto>();
        public List<CreateSubjectMzhbDto> SubjectMzhbs { get; set; } = new List<CreateSubjectMzhbDto>();
    }

    public class CreateSubjectSectionDto
    {
        public Guid SectionId { get; set; }
    }
    public class CreateSubjectBranchDto 
    {
        public Guid BranchId { get; set;}
    }
   public class CreateSubjectMzhbDto
    {
        public Guid MzhbId { get; set; }
    }
}