using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IStudentRepo : IGenericRepository<Student>
    {
        Task<(List<Student>, int)> GetStudents(FilterDto filter);
        Task<Student> GetStudentById(Guid studentId);
        Task<Student> GetStudentByIdentityId(Guid studentIdentityId);
        Task<List<Student>> GetStudentsForGroup(FilterDto filter);
        Task<int> GetSTudentsCount(FilterDto filter);
        Task<Student> GetStudentAsync(string studentId);

    }

}