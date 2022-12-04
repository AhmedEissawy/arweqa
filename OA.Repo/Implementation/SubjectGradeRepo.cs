using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class SubjectGradeRepo : GenericRepository<SubjectGrade>, ISubjectGradeRepo
    {
        private readonly ProjectContext _dbContext;
        public SubjectGradeRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<SubjectGrade>> GetSubjectsByGradeAndSection(FilterGradeAndSectionDto filter, IEnumerable<Guid> teacherSubjects = null)
        {
            IQueryable<SubjectGrade> SubjectsList =  _dbContext.SubjectGrades.Include(q => q.SubjectSections).Include(q => q.Grade).ThenInclude(q => q.Stage).Where(q => q.SubjectSections.Any(a => a.SectionId == filter.SectionId) && q.GradeId == filter.GradeId).OrderBy(q => q.Index);

            if (teacherSubjects != null)
                SubjectsList = SubjectsList.Where(a => teacherSubjects.Contains(a.Id));

            return await SubjectsList.ToListAsync();
        }



        public async Task<SubjectGrade> GetSubjectById(Guid subjectId)
        {
            SubjectGrade subject = await _dbContext.SubjectGrades.Include(q => q.SubjectSections).Include(q =>q.SubjectMzhbs).Include(q => q.SubjectBranches).Include(q => q.Grade).ThenInclude(q => q.Stage).FirstOrDefaultAsync(q => q.Id == subjectId);

            return subject;
        }


        public async Task<List<SubjectGrade>> GetStudentSubjectsByGradeId(Guid gradeId, Guid sectionId)
        {
            List<SubjectGrade> subjects = await _dbContext.SubjectGrades.Include(q => q.SubjectSections).Include(q => q.Grade).ThenInclude(q => q.Stage).Where(q => q.GradeId == gradeId && q.SubjectSections.Any(a=>a.SectionId==sectionId)  && q.IsActive && !q.Deleted).OrderBy(q => q.Index).ToListAsync();

            return subjects;

        }


        public async Task<(List<SubjectGrade>, int)> Subjects(FilterDto subjectFilter, IEnumerable<Guid> teacherSubjects = null)
        {
            int skip = subjectFilter.PageSize * (subjectFilter.PageNo - 1);

            IQueryable<SubjectGrade> subjectsList = _dbContext.SubjectGrades.Include(q => q.SubjectSections).ThenInclude(a=>a.Section).Include(q => q.Grade).ThenInclude(q => q.Stage).AsQueryable();

            if (subjectFilter.SectionId != null && subjectFilter.SectionId != Guid.Empty)
            {
                subjectsList = subjectsList.Where(q => q.SubjectSections.Any(a=>a.SectionId==subjectFilter.SectionId));
            }

            if (subjectFilter.GradeId != null && subjectFilter.GradeId != Guid.Empty)
            {
                subjectsList = subjectsList.Where(q => q.GradeId == subjectFilter.GradeId);
            }

            if (subjectFilter.StageId != null && subjectFilter.StageId != Guid.Empty)
            {
                subjectsList = subjectsList.Where(q => q.Grade.StageId == subjectFilter.StageId);
            }

            if (!string.IsNullOrEmpty(subjectFilter.Name) && !string.IsNullOrWhiteSpace(subjectFilter.Name))
            {
                subjectsList = subjectsList.Where(q => q.SubjectName.ToLower().Contains(subjectFilter.Name.ToLower()));
            }

            if (subjectFilter.IsActive != null)
            {
                subjectsList = subjectsList.Where(q => q.IsActive == subjectFilter.IsActive);
            }

            if (teacherSubjects != null)
                subjectsList = subjectsList.Where(a => teacherSubjects.Contains(a.Id));
           
            int rowCount = subjectsList.Count();
            
            return (await subjectsList.OrderBy(q => q.Index).Skip(skip).Take(subjectFilter.PageSize).ToListAsync(), rowCount);
        }

        public Task<SubjectGrade> GetSubjectWithSetions(Expression<Func<SubjectGrade, bool>> fiterPredicate)
        {
            return _dbSet.Include(a => a.TeacherSubjects).Include(a => a.SubjectMzhbs).Include(a => a.SubjectBranches).FirstOrDefaultAsync(fiterPredicate);
        }
    }
}
