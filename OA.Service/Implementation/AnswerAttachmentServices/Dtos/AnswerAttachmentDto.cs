using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.AnswerAttachmentServices.Dtos
{
    public class AnswerAttachmentDto
    {
        public Guid AttachmentId { get; set; }

        public Guid AnswerId { get; set; }

        public string File { get; set; }
     
        public string Type { get; set; }

    }
}
