using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LessonAttachmentServices.Dtos
{
    public class LessonMobileAttachmentResponseDto
    {
        public List<MobileLessonFilesDto> Files { get; set; } 
        public List<LessonVideosDto> Videos { get; set; }
    }
}
