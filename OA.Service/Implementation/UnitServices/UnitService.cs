using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.UnitServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.UnitServices
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepo _unitRepo;
        private readonly IMapper _Mapper;
        public UnitService(IUnitRepo unitRepo , IMapper mapper)
        {
            _unitRepo = unitRepo;
            _Mapper = mapper;
        }


        public async Task<List<UnitResponseDto>> GetSubjectUnitsAdmin(UnitFilterDto filterDto)
        {
            List<Unit> units = await _unitRepo.GetUnitsAdmin(filterDto);

            return _Mapper.Map<List<UnitResponseDto>>(units);
        }


        public async Task<UnitResponseDto> GetUnitById(Guid unitId)
        {
            Unit dbUnit = await _unitRepo.GetUnitById(unitId);

            if (dbUnit == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Unit with id = {unitId} not found ...!" });

            return _Mapper.Map<UnitResponseDto>(dbUnit);
        }


       



        public async Task<UnitResponseDto> AddUnit(CreateUnitDto unit)
        {
            if (unit.UnitName == null || unit.SubjectId == Guid.Empty || unit.SemesterId == Guid.Empty) throw new RestException(HttpStatusCode.BadRequest, new { message = $" Missing Data ...!" });

            Unit newUnit = _Mapper.Map<Unit>(unit);

            newUnit.Id = Guid.NewGuid();

            await _unitRepo.AddAsync(newUnit);

            return await _unitRepo.SaveChangesAsync() > 0 ? _Mapper.Map<UnitResponseDto>(newUnit) : throw new Exception("Error saving The data ...!");
        }


        public async Task<UnitResponseDto> EditUnit(EditUnitDto unit)
        {
            Unit oldUnit = (await _unitRepo.FindAsync(q => q.Id == unit.UnitId)).FirstOrDefault();

            if (oldUnit == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Unit with id = {unit.UnitId} not found ...!" });

            oldUnit.SubjectId = unit.SubjectId;
            oldUnit.SemesterId = unit.SemesterId;
            oldUnit.UnitName = unit.UnitName ?? unit.UnitName;
            oldUnit.Index = unit.Index;

            return await _unitRepo.SaveChangesAsync() > 0 ? _Mapper.Map<UnitResponseDto>(oldUnit) : throw new Exception("Error saving The data ...!");
        }


        public async Task<(object, int)> DeleteUnit(Guid unitId)
        {
            Unit oldUnit = (await _unitRepo.FindAsync(q => q.Id == unitId)).FirstOrDefault();

            if (oldUnit == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Unit with id = {unitId} not found ...!" });

            _unitRepo.Remove(oldUnit);

            var result = 0;

            try
            {
                result = await _unitRepo.SaveChangesAsync();
            }
            catch (Exception)
            {
                return (new { message = "لا يمكن حذف هذه الوحدة لإرتباطها بالدروس " }, result);
            }

            return ("", result);
        }



        public async Task<ActivationDto> UnitActivation(Guid unitId)
        {
            Unit dbUnit = (await _unitRepo.FindAsync(q => q.Id == unitId)).FirstOrDefault();

            if (dbUnit == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Unit with id = {unitId} not found ...!" });

            if (dbUnit.IsActive == true)
            {
                dbUnit.IsActive = false;
                await _unitRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbUnit.IsActive = true;

            await _unitRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }


    }
}
