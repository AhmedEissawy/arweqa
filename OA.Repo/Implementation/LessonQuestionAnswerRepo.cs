using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class LessonQuestionAnswerRepo : GenericRepository<LessonQuestionAnswer>, ILessonQuestionAnswerRepo
    {
        private readonly ProjectContext _dbContext;
        public LessonQuestionAnswerRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LessonQuestionAnswer>> GetLessonQuestionAnswer(Guid lessonQuestionId)
        {
            List<LessonQuestionAnswer> answers = await _dbContext.LessonQuestionAnswers.Include(q => q.LessonQuestion).Where(q => !q.Deleted && !q.LessonQuestion.Deleted && q.LessonQuestionId == lessonQuestionId).ToListAsync();

            return answers;
        }
    }
}
