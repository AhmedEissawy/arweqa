using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class UnitRepo : GenericRepository<Unit>, IUnitRepo
    {
        private readonly ProjectContext _dbContext;
        public UnitRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<Unit>> GetUnitsAdmin(UnitFilterDto filterDto)
        {
            IQueryable<Unit> units = _dbContext.Units.Include(q => q.Subject).Include(q => q.Semester).Where(q => !q.Subject.Deleted && !q.Deleted && !q.Semester.Deleted && q.SubjectId == filterDto.SubjectId);
          
            if (filterDto.SemesterId != null && filterDto.SemesterId != Guid.Empty)
            {
                units.Where(q => q.SemesterId == filterDto.SemesterId);
            }
          
            return await units.OrderBy(q => q.Index).ToListAsync();
        }



        public async Task<Unit> GetUnitById(Guid unitId)
        {
            return await _dbContext.Units.Include(q => q.Subject).Include(q => q.Semester).FirstOrDefaultAsync(q => q.Id == unitId);
        }
    }
}
