using System;

namespace OA.Data.Domain
{
    public class LessonAttachment : BaseEntity
    {
        public Guid LessonId { get; set; }
        public string Title { get; set; }
        public string FileImage { get; set; }
        public string File { get; set; }
        public string Type { get; set; }
        public string ContentTypeFor { get; set; }
        public Lesson Lesson { get; set; }
    }
}
