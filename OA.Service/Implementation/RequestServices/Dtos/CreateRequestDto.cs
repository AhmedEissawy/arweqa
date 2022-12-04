using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.RequestServices.Dtos
{
    public class CreateRequestDto
    {
        public string Description { get; set; }

        public Guid SubjectId { get; set; } 
      
    }
}
