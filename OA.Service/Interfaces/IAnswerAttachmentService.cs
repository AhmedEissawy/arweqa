using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IAnswerAttachmentService
    {
         Task<bool> UploadAnswerAttachment(IFormFileCollection attachments, Guid answerId);
    }
}
