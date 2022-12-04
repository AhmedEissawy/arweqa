using Microsoft.AspNetCore.Http;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Implementation.RequestServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IRequestService
    {
        Task<List<MobileRequestResponseDto>> GetStudentRequests();
        Task<List<MobileRequestResponseDto>> GetTeacherRequests();
        Task<MobileTeacherRequestResponseDto> GetTeacherRequestById(Guid requestId);
        Task<RequestResponseDto> GetRequestById(Guid requestId);
        Task<(RequestResponseDto , Guid)> AddRequest(CreateRequestDto request);
        Task RequestRedirect(RequestRedirectDto requestRedirect);
        Task<(Guid studentId, Guid teacherId, int RequestNo, string SubjectName)> DeleteRequest(Guid requestId);
        Task DeleteFullRequest(Guid requestId);
    }
}

