using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LessonQuestionServices.Dtos
{
    public class LessonQuestionDto
    {
        public Guid LessonQuestionId { get; set; }
        public Guid LessonId { get; set; }
        public string ContentType { get; set; }
        public string Question { get; set; }
        public int Index { get; set; }
        public List<lessonQuestionAnswerDto> Answers { get; set; }
    }
}
