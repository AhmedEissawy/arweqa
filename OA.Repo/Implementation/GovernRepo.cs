using OA.Data.Domain;
using OA.Repo.Interfaces;

namespace OA.Repo.Implementation
{
    public class GovernRepo : GenericRepository<Governorate>, IGovernRepo
    {
        public GovernRepo(ProjectContext context) : base(context)
        {
        }
    }
}
