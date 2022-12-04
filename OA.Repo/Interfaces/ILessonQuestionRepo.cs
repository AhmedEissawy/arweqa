using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface ILessonQuestionRepo : IGenericRepository<LessonQuestion>
    {
        Task<List<LessonQuestion>> LessonQuestions(Guid lessonId);
        Task<LessonQuestion> LessonQuestionWithAnswers(Guid questionId);
        Task<List<LessonQuestion>> GetRandomLessonQuestionsFromLesson(Guid lessonId);
    }
}
