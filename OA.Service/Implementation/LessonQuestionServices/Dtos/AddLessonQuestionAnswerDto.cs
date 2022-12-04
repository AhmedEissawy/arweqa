using Microsoft.AspNetCore.Http;
using System;

namespace OA.Service.Implementation.LessonQuestionServices.Dtos
{
    public class AddLessonQuestionAnswerDto
    {
        public Guid lessonQuestionId { get; set; }
        public string Answer { get; set; }
        public IFormFile AnswerFile { get; set; }
        public bool IsRight { get; set; }
        public int Index { get; set; }
    }
}
