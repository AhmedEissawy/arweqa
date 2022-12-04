using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class StageRepo : GenericRepository<Stage>, IStageRepo
    {
        private readonly ProjectContext _dbContext;
        public StageRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Stage>> GetAllStagesAdmin()
        {
            List<Stage> stages = await _dbContext.Stages.OrderBy(q => q.Index).ToListAsync();

            return stages;
        }  
        
        public async Task<List<Stage>> GetStages()
        {
            List<Stage> stages = await _dbContext.Stages.Where(q => q.IsActive && !q.Deleted).OrderBy(q => q.Index).ToListAsync();

            return stages;
        }
    }
}
