using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.StudentLessonQuestionAnswerServices.Dtos
{
    public class QuestionAnswerDto
    {
        public Guid AnswerId { get; set; }
        public string ContentType { get; set; }
        public string Answer { get; set; }
    }
}
