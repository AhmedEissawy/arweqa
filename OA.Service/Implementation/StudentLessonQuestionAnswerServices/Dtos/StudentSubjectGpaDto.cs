using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.StudentLessonQuestionAnswerServices.Dtos
{
    public class StudentSubjectGpaDto
    {
        public int TotalGPA { get; set; }
        public int TotalRightAnswers { get; set; }
        public int TotalWrongAnswers { get; set; }
    }
}
