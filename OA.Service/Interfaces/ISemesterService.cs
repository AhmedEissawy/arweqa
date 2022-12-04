using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SemesterServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ISemesterService
    {
        Task<List<SemesterResponseDto>> GetSemesters();
        Task<SemesterResponseDto> GetSemesterById(Guid semesterId);
        Task<SemesterResponseDto> AddSemester(CreateSemesterDto semester);
        Task<SemesterResponseDto> EditSemester(EditSemesterDto semester);
        Task<(object, int)> DeleteSemester(Guid semesterId);
        Task<ActivationDto> SemesterActivation(Guid semesterId);
    }
}
