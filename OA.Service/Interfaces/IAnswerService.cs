using OA.Service.Implementation.AnswerServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IAnswerService
    {
        Task<MobileFullAnswerResponseDto> GetAnswerWithRequestAttachmentByRequestId(Guid requestId);
        Task<(AnswerResponseDto , Guid)> AddAnswerToRequest(CreateAnswerDto answer);
        Task<(string, Guid)> DeleteAnswerFromRequest(Guid answerId);

    }
}
