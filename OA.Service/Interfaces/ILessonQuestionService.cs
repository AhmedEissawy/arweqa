using OA.Service.Implementation.LessonQuestionServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ILessonQuestionService
    {
        Task<List<LessonQuestionDto>> LessonQuestions(Guid lessonId);
        Task<Guid> AddLessonQuestion(AddLessonQuestionDto lessonQuestion);
        Task<Guid> AddLessonQuestionAnswer(AddLessonQuestionAnswerDto lessonQuestionAnswer);
        Task EditLessonQuestion(EditLessonQuestionDto lessonQuestion);
        Task DeleteLessonQuestion(Guid questionId);
        Task DeleteLessonQuestionAnswer(Guid answerId);
    }
}
