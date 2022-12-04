
using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.StageServices.Dtos;
using OA.Service.Implementation.TeacherServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.StageServices
{
    public class StageService : IStageService
    {
        private readonly IMapper _Mapper;
        private readonly IStageRepo _StageRepo;
        public StageService(IMapper mapper, IStageRepo stageRepo)
        {
            _Mapper = mapper;
            _StageRepo = stageRepo;
        }



        public async Task<StageResponseDto> AddStage(CreateStageDto stage)
        {
            if (stage.StageName == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The stage name cannot be empty ...!" });

            Stage newStage = _Mapper.Map<Stage>(stage);

            newStage.Id = Guid.NewGuid();

            await _StageRepo.AddAsync(newStage);

            return await _StageRepo.SaveChangesAsync() > 0 ? _Mapper.Map<StageResponseDto>(newStage) : throw new Exception("Error saving The data ...!");

        }



        public async Task<List<StageResponseDto>> GetAllStagesAdmin()
        {
            List<Stage> Stages = await _StageRepo.GetAllStagesAdmin();

            return _Mapper.Map<List<StageResponseDto>>(Stages);

        } 
        


        public async Task<List<StageResponseDto>> GetStages()
        {
            List<Stage> Stages = await _StageRepo.GetStages();

            return _Mapper.Map<List<StageResponseDto>>(Stages);

        }



        public async Task<StageResponseDto> GetStageById(Guid stageId)
        {
            Stage dbStage = (await _StageRepo.FindAsync(q => q.Id == stageId)).FirstOrDefault();

            if (dbStage == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The stage with id = {stageId} not found ...!" });

            return _Mapper.Map<StageResponseDto>(dbStage);

        }



        public async Task<StageResponseDto> EditStage(EditStageDto stage)
        {
            Stage oldStage = (await _StageRepo.FindAsync(q => q.Id == stage.StageId)).FirstOrDefault();

            if (oldStage == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The stage with id = {stage.StageId} not found ...!" });

            oldStage.StageName = stage.StageName;
            oldStage.Index = stage.Index;

            return await _StageRepo.SaveChangesAsync() > 0 ? _Mapper.Map<StageResponseDto>(oldStage) : throw new Exception("Error saving The data ...!");

        }



        public async Task DeleteStage(Guid stageId)
        {
            Stage oldStage = (await _StageRepo.FindAsync(q => q.Id == stageId)).FirstOrDefault();

            if (oldStage == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The stage with id = {stageId} not found ...!" });

            _StageRepo.Remove(oldStage);

            var result = await _StageRepo.SaveChangesAsync();

            if (result == 0) throw new Exception("Error deleting stage ...!");
        }


        public async Task<ActivationDto> StageActivation(Guid stageId)
        {
            Stage dbStage = (await _StageRepo.FindAsync(q => q.Id == stageId)).FirstOrDefault();

            if (dbStage == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Stage with id = {stageId} not found ...!" });

            if (dbStage.IsActive == true)
            {
                dbStage.IsActive = false;
                await _StageRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbStage.IsActive = true;

            await _StageRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }


    }
}
