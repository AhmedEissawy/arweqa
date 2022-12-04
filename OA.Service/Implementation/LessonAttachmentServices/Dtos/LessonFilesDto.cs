using System;

namespace OA.Service.Implementation.LessonAttachmentServices.Dtos
{
    public class LessonFilesDto
    {
        public Guid FileId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string File { get; set; }
        public string FileImage { get; set; }
    }
}
