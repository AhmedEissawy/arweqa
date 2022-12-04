using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.TeacherServices.Dtos
{
    public class CreateTeacherDto
    {
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool PremiumSubscription { get; set; }

        public List<TeacherSubjectPermession> Subjects { get; set; }
    }

    public class TeacherSubjectPermession 
    {
        public Guid SubjectId { get; set; }

        public List<string> Permessions { get; set; }
    }
}
