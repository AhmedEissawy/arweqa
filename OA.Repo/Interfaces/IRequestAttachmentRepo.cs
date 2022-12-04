using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IRequestAttachmentRepo : IGenericRepository<RequestAttachment>
    {
        Task<List<RequestAttachment>> GetRequestAttachments(Guid requestId);
    }
}
