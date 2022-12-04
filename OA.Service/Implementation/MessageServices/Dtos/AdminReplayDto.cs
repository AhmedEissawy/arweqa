using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.MessageServices.Dtos
{
    public class AdminReplayDto
    {
        public Guid ReceiverIdentityId { get; set; }

        public string Message { get; set; }

        public IFormFile Attachment { get; set; }

    }

}
