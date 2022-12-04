using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UserServices.Dtos
{
   public class AdminResponseDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public Guid? SectionId { get; set; }

        public string SectionName { get; set; }
        
        public string Email { get; set; }

    }
}
