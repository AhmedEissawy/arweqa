using OA.Service.Implementation.StudentLessonQuestionAnswerServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IStudentLessonQuestionAnswerService
    {
        Task<List<StudentLessonQuestionDto>> GetStudentLessonQuestions(Guid lessonId);
        Task<List<StudentAnswerResultDto>> AnswerLessonQuestions(List<StudentLessonQuestionAnswerDto> lessonQuestionAnswers);
    }
}
