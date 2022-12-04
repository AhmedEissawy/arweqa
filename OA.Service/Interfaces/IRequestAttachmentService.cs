using Microsoft.AspNetCore.Http;
using OA.Service.Implementation.RequestAttachmentServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IRequestAttachmentService
    {
        Task<bool> UploadRequestAttachment(IFormFileCollection attachments, Guid requestId);
        Task<List<RequestAttachmentDto>> GetRequestAttachments(Guid requestId);     

    }
}
