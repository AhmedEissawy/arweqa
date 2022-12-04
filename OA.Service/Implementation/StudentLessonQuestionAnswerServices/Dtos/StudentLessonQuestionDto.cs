using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.StudentLessonQuestionAnswerServices.Dtos
{
    public class StudentLessonQuestionDto
    {
        public Guid QuestionId { get; set; }
        public string ContentType { get; set; }
        public string Question { get; set; }
        public List<QuestionAnswerDto> Answers { get; set; }

    }
}
