using System;
using System.Collections.Generic;

namespace OA.Service.Implementation.StudentLessonQuestionAnswerServices.Dtos
{
    public class StudentAnswerResultDto
    {
        public string LessonQuestion { get; set; }
        public string ContentType { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
        public List<QuestionAnswersDto> Answers { get; set; }
    }

    public class QuestionAnswersDto
    {
        
        public string ContentType { get; set; }
        public string Answer { get; set; }
        public bool IsRight { get; set; }

    }

}
