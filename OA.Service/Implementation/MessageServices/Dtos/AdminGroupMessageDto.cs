using Microsoft.AspNetCore.Http;
using System;

namespace OA.Service.Implementation.MessageServices.Dtos
{
    public class AdminGroupMessageDto
    {
        public string SectionId { get; set; }=null;
        public string GradeId { get; set; }  =null;
        public string StageId { get; set; }  =null;
        public bool? IsActive { get; set; } = null;
        public string Message { get; set; }

        public IFormFile Attachment { get; set; }
    }


    public class Test 
    {
        public bool? IsActive { get; set; }
        public string Message { get; set; }

        public IFormFile Attachment { get; set; }
    }
}
