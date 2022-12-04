using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class RequestAttachmentRepo : GenericRepository<RequestAttachment>, IRequestAttachmentRepo
    {
        private readonly ProjectContext _dbContext;
        public RequestAttachmentRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<RequestAttachment>> GetRequestAttachments(Guid requestId)
        {
            List<RequestAttachment> requests = await _dbContext.RequestAttachments.Include(q => q.Request).Where(q => q.RequestId == requestId).ToListAsync();

            return requests;
        }


    }
}
