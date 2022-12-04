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
    public class LessonQuestionRepo : GenericRepository<LessonQuestion>, ILessonQuestionRepo
    {
        private readonly ProjectContext _dbContext;
        public LessonQuestionRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LessonQuestion>> GetRandomLessonQuestionsFromLesson(Guid lessonId)
        {
            List<LessonQuestion> lessonQuestions = await _dbContext.LessonQuestions.Include(q => q.LessonQuestionAnswers).Where(q => !q.Deleted && q.LessonId == lessonId).ToListAsync();
            return lessonQuestions;
        }


        public async Task<List<LessonQuestion>> LessonQuestions(Guid lessonId)
        {
            return await _dbContext.LessonQuestions.Include(q => q.LessonQuestionAnswers).Where(q => !q.Deleted && q.LessonId == lessonId).ToListAsync();
        }

        public async Task<LessonQuestion> LessonQuestionWithAnswers(Guid questionId)
        {
            return await _dbContext.LessonQuestions.Include(q => q.LessonQuestionAnswers).FirstOrDefaultAsync(q => !q.Deleted && q.LessonId == questionId);
        }

    }
}
