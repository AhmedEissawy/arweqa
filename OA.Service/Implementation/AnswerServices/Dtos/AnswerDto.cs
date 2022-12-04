using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.AnswerServices.Dtos
{
    public class AnswerDto
    {
        public string Discription { get; set; }
        public List<AttachmentDto> Attachments { get; set; }
    }
}
