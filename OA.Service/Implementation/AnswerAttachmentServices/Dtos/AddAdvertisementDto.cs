using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.AnswerAttachmentServices.Dtos
{
    public class AddAdvertisementDto
    {
        public IFormFile Advertisement { get; set; }

        public int index { get; set; }

    }
}
