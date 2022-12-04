using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.UnitServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IUnitService
    {
        Task<List<UnitResponseDto>> GetSubjectUnitsAdmin(UnitFilterDto unitFilter);
        Task<UnitResponseDto> GetUnitById(Guid unitId);
        Task<UnitResponseDto> AddUnit(CreateUnitDto unit);
        Task<UnitResponseDto> EditUnit(EditUnitDto unit);
        Task<(object, int)> DeleteUnit(Guid unitId);
        Task<ActivationDto> UnitActivation(Guid unitId);
    }
}
