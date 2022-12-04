using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.GradeServices.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.GradeServices
{
    public class GradeService : IGradeService
    {
        private readonly IMapper _Mapper;
        private readonly IGradeRepo _GradeRepo;
        public GradeService(IMapper mapper, IGradeRepo gradeRepo)
        {
            _Mapper = mapper;
            _GradeRepo = gradeRepo;
        }



        public async Task<GradeResponseDto> AddGrade(CreateGradeDto grade)
        {
            if (grade.GradeName == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The grade name cannot be empty ...!" });

            Grade newGrade = _Mapper.Map<Grade>(grade);

            newGrade.Id = Guid.NewGuid();

            await _GradeRepo.AddAsync(newGrade);

            return await _GradeRepo.SaveChangesAsync() > 0 ? _Mapper.Map<GradeResponseDto>(newGrade) : throw new Exception("Error saving The data ...!");

        }



        public async Task<List<GradeResponseDto>> GetGradesByStageIdAdmin(Guid stageId)
        {
            List<Grade> grades = await _GradeRepo.GetGradesByStageIdAdmin(stageId);

            return _Mapper.Map<List<GradeResponseDto>>(grades);
        }

        public async Task<List<GradeResponseDto>> GetGradesByStageId(Guid stageId)
        {
            List<Grade> grades = await _GradeRepo.GetGradesByStageId(stageId);

            return _Mapper.Map<List<GradeResponseDto>>(grades);
        }



        public async Task<(List<GradeResponseDto>, int count)> GetGrades(FilterDto filterDto)
        {
            (List<Grade> grades, int count) = await _GradeRepo.GetGrades(filterDto);

            return (_Mapper.Map<List<GradeResponseDto>>(grades), count);
        }



        public async Task<GradeResponseDto> GetGradeById(Guid gradeId)
        {
            Grade dbGrade = await _GradeRepo.GetGradeById(gradeId);

            if (dbGrade == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The grade with id = {gradeId} not found ...!" });

            return _Mapper.Map<GradeResponseDto>(dbGrade);

        }



        public async Task<GradeResponseDto> EditGrade(EditGradeDto grade)
        {
            Grade oldGrade = (await _GradeRepo.FindAsync(q => q.Id == grade.GradeId)).FirstOrDefault();

            if (oldGrade == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The stage with id = {grade.GradeId} not found ...!" });

            oldGrade.GradeName = grade.GradeName;
            oldGrade.StageId = grade.StageId;
            oldGrade.Index = grade.Index;

            return await _GradeRepo.SaveChangesAsync() > 0 ? _Mapper.Map<GradeResponseDto>(oldGrade) : throw new Exception("Error saving The data ...!");

        }



        public async Task DeleteGrade(Guid gradeId)
        {
            Grade oldGrade = (await _GradeRepo.FindAsync(q => q.Id == gradeId)).FirstOrDefault();

            if (oldGrade == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The stage with id = {gradeId} not found ...!" });

            _GradeRepo.Remove(oldGrade);

            var result = await _GradeRepo.SaveChangesAsync();

            if (result == 0) throw new Exception("Error deleting Grade ...!");
        }


        public async Task<ActivationDto> GradeActivation(Guid gradeId)
        {
            Grade dbGrade = (await _GradeRepo.FindAsync(q => q.Id == gradeId)).FirstOrDefault();

            if (dbGrade == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Grade with id = {gradeId} not found ...!" });

            if (dbGrade.IsActive == true)
            {
                dbGrade.IsActive = false;
                await _GradeRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbGrade.IsActive = true;

            await _GradeRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }

        public async Task<List<GradeResponseDto>> GetAllGrades()
        {
             var grades = await _GradeRepo.GetAllAsync();

            return _Mapper.Map<List<GradeResponseDto>>(grades);
        }
    }
}
