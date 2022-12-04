using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface ISubjectGradeRepo : IGenericRepository<SubjectGrade>
    {
        Task<List<SubjectGrade>> GetSubjectsByGradeAndSection(FilterGradeAndSectionDto filter,IEnumerable<Guid> teacherSubjects =null );
        Task<SubjectGrade> GetSubjectById(Guid subjectId);
        Task<List<SubjectGrade>> GetStudentSubjectsByGradeId(Guid gradeId , Guid sectionId);
        Task<(List<SubjectGrade>, int)> Subjects(FilterDto subjectFilter, IEnumerable<Guid> teacherSubjects = null);

        Task<SubjectGrade> GetSubjectWithSetions(Expression<Func<SubjectGrade, bool>> fiterPredicate);
    }
}