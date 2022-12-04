using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.StageServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IStageService
    {
        Task<StageResponseDto> AddStage(CreateStageDto stage);
        Task<List<StageResponseDto>> GetAllStagesAdmin();
        Task<List<StageResponseDto>> GetStages();
        Task<StageResponseDto> GetStageById(Guid stageId);
        Task<StageResponseDto> EditStage(EditStageDto stage);
        Task DeleteStage(Guid stageId);
        Task<ActivationDto> StageActivation(Guid stageId);
    }

}
