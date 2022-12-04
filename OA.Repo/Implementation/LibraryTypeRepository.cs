using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class LibraryTypeRepository : GenericRepository<LibraryType>, ILibraryTypeRepository
    {
        private readonly ProjectContext _dbContext;
        public LibraryTypeRepository(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LibraryType>> GetLibraryTypes()
        {
            return await _dbContext.LibraryTypes.Where(q => !q.Deleted).ToListAsync();
        }

    }
}

