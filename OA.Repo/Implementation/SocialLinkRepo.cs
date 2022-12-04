using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Implementation
{
    public class SocialLinkRepo : GenericRepository<SocialLink>, ISocialLinkRepo
    {
        private readonly ProjectContext _dbContext;
        public SocialLinkRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    
    }
}
