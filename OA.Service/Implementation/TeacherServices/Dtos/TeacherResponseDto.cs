using OA.Service.Implementation.SubjectGradeServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.TeacherServices.Dtos
{
    public class TeacherResponseDto
    {
        public Guid TeacherId { get; set; }
       
        public string IdentityId { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }

        public bool PremiumSubscription { get; set; }

        public List<SubjectResponseDto> Subjects { get; set; } = new List<SubjectResponseDto>();

    }
}
