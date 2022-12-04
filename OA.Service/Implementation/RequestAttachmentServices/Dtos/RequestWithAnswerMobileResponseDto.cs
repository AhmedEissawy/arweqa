using OA.Service.Implementation.AnswerServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.RequestAttachmentServices.Dtos
{
    public class RequestWithAnswerMobileResponseDto
    {
        public List<RequestAttachmentDto> request { get; set; }
        public List<MobileFullAnswerResponseDto> Answer { get; set; }
    }
}
