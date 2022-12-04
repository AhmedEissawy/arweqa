using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IStudentLessonQuestionAnswerRepo : IGenericRepository<StudentLessonQuestionAnswer>
    {
        Task<List<StudentLessonQuestionAnswer>> GetPreviousStudentAnswers(Guid lessonId);
        Task<List<StudentLessonQuestionAnswer>> CheckLessonQuestionAnswers(List<Guid> lessonQuestionAnswersId);
    }
}
