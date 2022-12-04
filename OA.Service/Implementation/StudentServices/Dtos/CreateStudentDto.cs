using Microsoft.AspNetCore.Http;
using System;


namespace OA.Service.Implementation.StudentServices.Dtos
{
    public class CreateStudentDto
    {
 
        public string Name { get; set; }

        public string Mobile { get; set; }

        public Guid SectionId { get; set; }

        public Guid StageId { get; set; }

        public Guid GradeId { get; set; }
        public IFormFile ProfileImage { get; set; }

    }
}
