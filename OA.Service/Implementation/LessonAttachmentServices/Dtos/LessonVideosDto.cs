using OA.Data.Enums;
using System;
using System.Collections.Generic;

namespace OA.Service.Implementation.LessonAttachmentServices.Dtos
{
    public class LessonVideosDto
    {
        public string  Title { get; set; }
        public string VideoLink { get; set; }
        public string ContentTypeFor { get; set; }
        public VideoType VideoType { get; set; }

    }

    public class LessonVideoRoomDto 
    {
        
            public string LiveDate { get; set; }
    }

    public class GetLessonVideosDto 
    {
        public List<LessonVideosDto> Videos { get; set; }
        public List<LessonVideoRoomDto> LiveVideos { get; set; }
    }
}
