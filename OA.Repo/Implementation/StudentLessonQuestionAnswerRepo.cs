using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class StudentLessonQuestionAnswerRepo : GenericRepository<StudentLessonQuestionAnswer>, IStudentLessonQuestionAnswerRepo
    {
        private readonly ProjectContext _dbContext;
        public StudentLessonQuestionAnswerRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StudentLessonQuestionAnswer>> CheckLessonQuestionAnswers(List<Guid> lessonQuestionAnswersId)
        {
            List<StudentLessonQuestionAnswer> studentLessonQuestionAnswers = await _dbContext.StudentlessonQuestionAnswers.Include(q => q.LessonQuestion).ThenInclude(q => q.LessonQuestionAnswers).Where(q => !q.Deleted && lessonQuestionAnswersId.Contains(q.Id)).ToListAsync();
            return studentLessonQuestionAnswers;

        }

        public async Task<List<StudentLessonQuestionAnswer>> GetPreviousStudentAnswers(Guid lessonId)
        {
            return await _dbContext.StudentlessonQuestionAnswers.Include(q => q.LessonQuestionAnswer).ThenInclude(q => q.LessonQuestion).Where(q => !q.Deleted && q.LessonQuestionAnswer.LessonQuestion.LessonId == lessonId).ToListAsync();
        }
    }
}