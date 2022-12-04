using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface ITeacherSubjectRepo : IGenericRepository<TeacherSubject>
    {

        Task<int> GetLastTeacherRole(Guid subjectId);

        Task<List<TeacherSubject>> GetAllTeacherSubjects(Guid teacherId);
        Task<bool> ChangeTeacherSubjectPermession(Guid teacherId, Guid subjectId, string permession, bool status);
        Task<TeacherSubject> GetTeacherSubjectByPermessions(Guid teacherId, Guid subjectId);

    }
}
