using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.StudentLessonQuestionAnswerServices.Dtos
{
    public class StudentLessonQuestionAnswerDto
    {
        public Guid LessonQuestionAnswerId { get; set; }
        public Guid AnswerId { get; set; }
    }
}
