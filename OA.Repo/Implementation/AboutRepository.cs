using OA.Data.Domain;
using OA.Repo.Interfaces;

namespace OA.Repo.Implementation
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        private readonly ProjectContext _dbContext;
        public AboutRepository(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
