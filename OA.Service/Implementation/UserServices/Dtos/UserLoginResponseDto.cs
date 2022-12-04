using OA.Service.Implementation.RoleServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UserServices.Dtos
{
    public class UserLoginResponseDto
    {
        public string Id { get; set; }

        public string Token { get; set; }

        public string UserName { get; set; }
       
        public Guid? SectionId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public List<string> Roles { get; set; }

        public bool Unauthorized { get; set; }

        public string Message { get; set; }
        public string UserType { get; set; }
        public List<string> TeacherPermession { get; set; }

    }
}
