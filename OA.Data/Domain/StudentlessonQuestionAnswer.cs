using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
    public class StudentLessonQuestionAnswer : BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid LessonQuestionId { get; set; }
        public Guid? LessonQuestionAnswerId { get; set; }
        public bool IsRight { get; set; }
        public LessonQuestionAnswer LessonQuestionAnswer { get; set; }
        public Student Student { get; set; }
        public LessonQuestion LessonQuestion { get; set; }
    }
}
