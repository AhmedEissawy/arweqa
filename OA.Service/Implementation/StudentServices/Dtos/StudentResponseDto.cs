using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.StudentServices.Dtos
{
    public class StudentResponseDto
    {
        public Guid StudentId { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string GovernmentName { get; set; }
        public string CityName { get; set; }
        public string Gender { get; set; }
        public string MzhbName { get; set; }
        public string BranchName { get; set; }
        public string InstituteName { get; set; }


        public string StudentImage { get; set; }

        public string SectionName { get; set; }
       
        public string StageName { get; set; }

        public string GradeName { get; set; }

        public string IdentityId { get; set; }

        public bool IsActive { get; set; }

        public bool PremiumSubscription { get; set; }

        public Guid SectionId { get; set; }

        public Guid StageId { get; set; }

        public Guid GradeId { get; set; }

        public string Message { get; set; }

        public string ProfileImage { get; set; } = "";
    }
}