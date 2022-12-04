using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.AnswerServices.Dtos
{
    public class CreateAnswerDto
    {
        public Guid RequestId { get; set; }
       
        public string Description { get; set; }

    }
}
