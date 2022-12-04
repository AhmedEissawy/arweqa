using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.MessageServices.Dtos
{
    public class AdminMessageResponseDto
    {
        public string SenderName { get; set; }

        public string SenderIdentityId { get; set; }
        
        public bool IsAdmin { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }

        public string Attachment { get; set; }

        public bool IsFile { get; set; }

        public string Type { get; set; }

    }
}
