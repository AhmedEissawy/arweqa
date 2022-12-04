using System;

namespace OA.Service.Implementation.LessonQuestionServices.Dtos
{
    public class lessonQuestionAnswerDto
    {
        public Guid lessonQuestionAnswerId { get; set; }
        public string ContentType { get; set; }
        public string Answer { get; set; }
        public bool IsRight { get; set; }
        public int Index { get; set; }
    }
}
