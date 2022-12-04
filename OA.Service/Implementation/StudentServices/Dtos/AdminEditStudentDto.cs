using System;

namespace OA.Service.Implementation.StudentServices.Dtos
{
    public class AdminEditStudentDto
    {
        public Guid StudentId { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public Guid? SectionId { get; set; }

        public Guid GradeId { get; set; }

    }
}
