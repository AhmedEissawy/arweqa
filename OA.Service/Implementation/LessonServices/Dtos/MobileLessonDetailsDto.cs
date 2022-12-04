using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LessonServices.Dtos
{
    public class MobileLessonDetailsDto
    {
        public LessonResponseDto Lesson { get; set; }

        public LessonMobileAttachmentResponseDto LessonAttachments { get; set; }
    }
}
