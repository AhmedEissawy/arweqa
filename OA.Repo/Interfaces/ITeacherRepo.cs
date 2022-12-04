using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface ITeacherRepo : IGenericRepository<Teacher>
    {
        Task<(List<Teacher>, int count)> GetTeachers(FilterDto filter);
        Task<Teacher> GetTeacherById(Guid teacherId);
        Task<List<TeacherSubject>> GetTeacherSubjects(Guid teacherId);
        Task<bool> ExceptionLogger(string controler , string action , Exception ex);
       
    }
}
