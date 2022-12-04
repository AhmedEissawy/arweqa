using OA.Repo.Dtos;
using OA.Service.Implementation.TeacherSubjectServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ITeacherSubjectService
    {
        Task AddSubjectToTeacher(AddSubjectsToTeacherDto subjects);
        Task RemoveSubjectFromTeacher(Guid subjectId);
        Task<List<PermessionsModel>> GetSubjectPermissions();
        Task<bool> DeleteOrAddSubjectPermession(Guid teacherId, Guid subjectId, string permession, bool status);
    }
}
