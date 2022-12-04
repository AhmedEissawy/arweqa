using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.MessageServices.Dtos
{
    public class WebAttachmentDto
    {
        public IFormFile File { get; set; }
       
        public string StudentIdentityId { get; set; }
    }
}
