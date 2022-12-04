using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IUnitRepo : IGenericRepository<Unit>
    {
        Task<List<Unit>> GetUnitsAdmin(UnitFilterDto filterDto);
        Task<Unit> GetUnitById(Guid unitId);
    }
}
