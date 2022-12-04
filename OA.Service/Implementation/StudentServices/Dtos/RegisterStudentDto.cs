using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.StudentServices.Dtos
{
    public class RegisterStudentDto
    {
        public string UserType { get; set; }

        public string UserFullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        public string InstituteName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public Guid GovernId { get; set; }
        public Guid SectionId { get; set; }
        public Guid GradeId { get; set; }
        public Guid? BranchId { get; set; }
        public Guid? MzhbId { get; set; }
        public Guid StageId { get; set; }

        public IFormFile Image { get; set; }

    }
}