using System;
using System.Collections.Generic;

namespace OA.Data.Domain
{
    public class Lesson : BaseEntity
    {
        public Lesson()
        {
            LessonAttachments = new HashSet<LessonAttachment>();
            LessonQuestions = new HashSet<LessonQuestion>();
            Rooms = new HashSet<LessonVideoRoom>();
        }

        public Guid UnitId { get; set; }
        public string LessonName { get; set; }
        public int Index { get; set; }
        public Unit Unit { get; set; }
        public ICollection<LessonAttachment> LessonAttachments { get; set; }
        public ICollection<LessonQuestion> LessonQuestions { get; set; }
        public ICollection<LessonVideoRoom> Rooms { get; set; }
    }
}