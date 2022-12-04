using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class SemesterRepo : GenericRepository<Semester>, ISemesterRepo
    {
        private readonly ProjectContext _dbContext;
        public SemesterRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Semester>> GetSemesters()
        {
            return await _dbContext.Semesters.Where(q => !q.Deleted).OrderBy(q => q.Index).ToListAsync();
        }

    }
}
