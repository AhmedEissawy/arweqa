using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IGradeRepo : IGenericRepository<Grade>
    {
        Task<(List<Grade> , int count)> GetGrades(FilterDto filterDto);      
        Task<Grade> GetGradeById(Guid gradeId);      
        Task<int> GetLastGradeIndex();      
        Task<List<Grade>> GetGradesByStageIdAdmin(Guid stageId);
        Task<List<Grade>> GetGradesByStageId(Guid stageId);
    }
}
