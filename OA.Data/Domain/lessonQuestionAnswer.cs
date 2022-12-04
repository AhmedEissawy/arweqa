using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
    public class LessonQuestionAnswer : BaseEntity
    {
        public LessonQuestionAnswer()
        {
            StudentLessonQuestionAnswers = new HashSet<StudentLessonQuestionAnswer>();
        }

        public Guid LessonQuestionId { get; set; }
        public string ContentType { get; set; }
        public string Answer { get; set; }
        public bool IsRight { get; set; }
        public int Index { get; set; }
        public LessonQuestion LessonQuestion { get; set; }
        public ICollection<StudentLessonQuestionAnswer> StudentLessonQuestionAnswers { get; set; }
    }
}
