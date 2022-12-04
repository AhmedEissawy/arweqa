using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
    public class LessonQuestion : BaseEntity
    {
        public LessonQuestion()
        {
            LessonQuestionAnswers = new HashSet<LessonQuestionAnswer>();
            StudentLessonQuestionAnswers = new HashSet<StudentLessonQuestionAnswer>();
        }

        public Guid LessonId { get; set; }
        public string ContentType { get; set; }
        public string Question { get; set; }
        public int Index { get; set; }
        public ICollection<LessonQuestionAnswer> LessonQuestionAnswers { get; set; }
        public ICollection<StudentLessonQuestionAnswer> StudentLessonQuestionAnswers { get; set; }
        public Lesson Lesson { get; set; }
    }
}
