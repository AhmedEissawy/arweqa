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
    public class TeacherSubjectRepo : GenericRepository<TeacherSubject>, ITeacherSubjectRepo
    {
        private readonly ProjectContext _dBContext;
        public TeacherSubjectRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dBContext = dbContext;
        }


        public async Task<List<TeacherSubject>> GetAllTeacherSubjects(Guid teacherId)
        {
            List<TeacherSubject> teacherSubject = await _dBContext.TeacherSubjects.Include(q => q.Subject).Where(q => q.TeacherId == teacherId).ToListAsync();

            return teacherSubject;

        }


        public async Task<int> GetLastTeacherRole(Guid subjectId)
        {
            List<TeacherSubject> teacherSubject = await _dBContext.TeacherSubjects.Where(q => q.SubjectId == subjectId).ToListAsync();

            int role = 0;

            if (teacherSubject.Count != 0 )
            {
                 role = teacherSubject.Max(q => q.Role);
            }

            return role;

        }
        public async Task<bool> ChangeTeacherSubjectPermession(Guid teacherId, Guid subjectId, string permession, bool status)
        {
            var subjectPermessions = await _dBContext.TeacherSubjects.Include(a => a.SubjectPermessions).FirstOrDefaultAsync(a => a.TeacherId == teacherId && a.Id == subjectId);

            if (status)
            {
                if (subjectPermessions.SubjectPermessions.Any(a => a.Permession == permession))
                    return false;

                subjectPermessions.SubjectPermessions.Add(new TeacherSubjectPermession { Id = Guid.NewGuid(), Permession = permession });
            }
            else
            {
                var delete = subjectPermessions.SubjectPermessions.FirstOrDefault(a => a.Permession == permession);
                if (delete != null)
                    subjectPermessions.SubjectPermessions.Remove(delete);

            }
            return true;
        }

        public  Task<TeacherSubject> GetTeacherSubjectByPermessions(Guid teacherId, Guid subjectId)
        {
            return _dbSet.Include(a => a.SubjectPermessions).FirstOrDefaultAsync(a => a.TeacherId == teacherId && a.Id == subjectId);
        }
    }
}
