using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using System;
using System.Collections.Generic;

namespace OA.Service.Implementation.LessonServices.Dtos
{
    public class EditLessonDto
    {
        public Guid LessonId { get; set; }
        public Guid UnitId { get; set; }
        public string LessonName { get; set; }
        public int Index { get; set; }
        public List<LessonVideosDto> Videos { get; set; }
        public List<LessonVideoRoomDto> Rooms { get; set; }
        public List<LessonPdfDto> pdf { get; set; }
    }
}
