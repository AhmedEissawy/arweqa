using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LessonAttachmentServices.Dtos
{
    public class LessonAttachmentResponseDto
    {
        public List<LessonFilesDto> Files { get; set; }
        public List<LessonVideosDto> Videos { get; set; }
        public List<LessonVideoRoomDto> Rooms { get; set; }

    }
}
