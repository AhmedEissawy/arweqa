using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LessonAttachmentServices.Dtos
{
    public class LessonAttachmentDto
    {
        public IFormFileCollection Files { get; set; }
 
        public List<LessonVideosDto>  Videos { get; set; }

    }

}
