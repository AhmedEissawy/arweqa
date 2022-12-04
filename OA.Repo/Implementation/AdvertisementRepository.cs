using OA.Data.Domain;
using OA.Repo.Interfaces;

namespace OA.Repo.Implementation
{
    public class AdvertisementRepository : GenericRepository<Advertisement>, IAdvertisementRepository
    {
        private readonly ProjectContext _dbContext;
        public AdvertisementRepository(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}