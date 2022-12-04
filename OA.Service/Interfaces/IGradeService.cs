using OA.Repo.Dtos;
using OA.Service.Implementation.GradeServices.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IGradeService
    {
        Task<GradeResponseDto> AddGrade(CreateGradeDto grade);
        Task<(List<GradeResponseDto> , int count)> GetGrades(FilterDto filterDto);
        Task<List<GradeResponseDto>> GetAllGrades();
        Task<List<GradeResponseDto>> GetGradesByStageIdAdmin(Guid stageId);
        Task<List<GradeResponseDto>> GetGradesByStageId(Guid stageId);
        Task<GradeResponseDto> GetGradeById(Guid gradeId);
        Task<GradeResponseDto> EditGrade(EditGradeDto grade);
        Task DeleteGrade(Guid gradeId);
        Task<ActivationDto> GradeActivation(Guid gradeId);
    }
}
