using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Implementation
{
    public class AnswerAttachmentRepo : GenericRepository<AnswerAttachment>, IAnswerAttachmentRepo
    {
        private readonly ProjectContext _dbContext;
        public AnswerAttachmentRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
