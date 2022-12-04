using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.MessageServices.Dtos
{
    public class CreateMessageDto
    {                    

        public bool IsTeacher { get; set; }

        public string Message { get; set; }
      
        public string SenderId { get; set; }

    }
}
