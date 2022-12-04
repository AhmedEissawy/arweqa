using System.Collections.Generic;

namespace OA.Service.Implementation.AnswerServices.Dtos
{
    public class RequestDto
    {
        public string Discription { get; set; }
        public List<AttachmentDto> Attachments { get; set; }
    }
}
