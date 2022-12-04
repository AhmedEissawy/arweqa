using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class TeacherRepo : GenericRepository<Teacher>, ITeacherRepo
    {
        private readonly ProjectContext _dbContext;
        public TeacherRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<(List<Teacher>, int count)> GetTeachers(FilterDto filter)
        {
            int skip = filter.PageSize * (filter.PageNo - 1);

            IQueryable<Teacher> dBTeachers = _dbContext.Teachers.Include(q => q.User).Include(q => q.TeacherSubjects).ThenInclude(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Where(q => !q.User.Deleted).AsQueryable();

            if (filter.StageId != null && filter.StageId != Guid.Empty)
            {
                dBTeachers = dBTeachers.Where(t => t.TeacherSubjects.Any(q => q.Subject.Grade.StageId == filter.StageId));
            }

            if (filter.GradeId != null && filter.GradeId != Guid.Empty)
            {
                dBTeachers = dBTeachers.Where(t => t.TeacherSubjects.Any(q => q.Subject.Grade.Id == filter.GradeId));
            }

            if (filter.SubjectId != null && filter.SubjectId != Guid.Empty)
            {
                dBTeachers = dBTeachers.Where(t => t.TeacherSubjects.Any(q => q.Subject.Id == filter.SubjectId));
            }

            if (!string.IsNullOrEmpty(filter.Name) && !string.IsNullOrWhiteSpace(filter.Name))
            {
                dBTeachers = dBTeachers.Where(t => t.User.UserFullName.ToLower().Contains(filter.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Mobile) && !string.IsNullOrWhiteSpace(filter.Mobile))
            {
                dBTeachers = dBTeachers.Where(t => t.User.PhoneNumber.Contains(filter.Mobile));
            }

            if (filter.IsActive != null)
            {
                dBTeachers = dBTeachers.Where(t => t.User.IsActive == filter.IsActive);
            }
           
            int rowCount = dBTeachers.Count();

            return (await dBTeachers.OrderBy(q => q.User.UserFullName).Skip(skip).Take(filter.PageSize).ToListAsync(), rowCount);
        }


        public async Task<Teacher> GetTeacherById(Guid teacherId)
        {

            Teacher teacher = await _dbContext.Teachers.Include(q => q.User).Include(q => q.TeacherSubjects).ThenInclude(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage)
                .Include(a=>a.TeacherSubjects).ThenInclude(a=>a.SubjectPermessions).FirstOrDefaultAsync(q => q.Id == teacherId && !q.User.Deleted);

            return teacher;
        }


        public async Task<List<TeacherSubject>> GetTeacherSubjects(Guid teacherId)
        {
            List<TeacherSubject> teacherSubjects = await _dbContext.TeacherSubjects.Include(q => q.Subject).ThenInclude(a=>a.SubjectSections).ThenInclude(q => q.Section).Include(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Include(a=>a.SubjectPermessions).Where(q => q.TeacherId == teacherId).ToListAsync();

            return teacherSubjects;
        }


        public async Task<bool> ExceptionLogger(string controler, string action, Exception ex)
        {
            var exception = new ExceptionLogger
            {
                Action = action,
                Controller = controler,
                Date = DateTime.Now,
                Text1 = ex.Message,
                Text2 = ex.StackTrace,
            };

            _dbContext.ExceptionLoggers.Add(exception);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        
    }
}
