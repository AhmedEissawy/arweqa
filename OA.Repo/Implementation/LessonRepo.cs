using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class LessonRepo : GenericRepository<Lesson>, ILessonRepo
    {
        private readonly ProjectContext _dbContext;
        public LessonRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<Lesson>> GetLessonsAdmin(Guid unitId)
        {
            return await _dbContext.Lessons.Include(q => q.Unit).Where(q => !q.Unit.Deleted && !q.Deleted && q.UnitId == unitId).OrderBy(q => q.Index).ToListAsync();
        }



        public async Task<Lesson> GetLessonDetailsForAdmin(Guid lessonId)
        {
            return await _dbContext.Lessons.Include(q => q.Unit).Include(q => q.LessonAttachments).Include(a=>a.Rooms).FirstOrDefaultAsync(q => !q.Unit.Deleted && !q.Deleted && q.Id == lessonId);
        }


        public async Task<List<Lesson>> GetSubjectUnitsForStudent(Guid subjectId)
        {
            return await _dbContext.Lessons.Include(q => q.Unit).ThenInclude(q => q.Semester).Include(q => q.Unit).ThenInclude(q => q.Subject)
                .Where(q => !q.Deleted
                && q.IsActive
                && !q.Unit.Semester.Deleted
                && q.Unit.Semester.IsActive
                && !q.Unit.Subject.Deleted
                && q.Unit.Subject.IsActive
                && q.Unit.SubjectId == subjectId
                && q.Unit.Semester.StartDate.Date <= DateTime.Now.Date
                && q.Unit.Semester.EndDate.Date >= DateTime.Now.Date
                ).OrderBy(q => q.Index).ToListAsync();
        }


        public async Task<Lesson> GetLessonDetailsForStudent(Guid lessonId)
        {
            return await _dbContext.Lessons.Include(q => q.Unit).Include(q => q.LessonAttachments).Include(a=>a.Rooms).FirstOrDefaultAsync(q => !q.Unit.Deleted && q.Unit.IsActive && !q.Deleted && q.IsActive && q.Id == lessonId);
        }


    }
}

