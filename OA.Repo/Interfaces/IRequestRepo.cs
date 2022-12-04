using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IRequestRepo : IGenericRepository<Request>
    {
        Task<TeacherSubject> GetTeacherInRole(Guid subjectId);
        Task<(List<Request>, int)> GetRequestsReport(ReportFilter filter);
        Task<List<Request>> CheckRequestAvailability(Guid studentId, Guid subjectId);
        Task<Request> GetRequestById(Guid requestId);
        Task<List<Request>> GetTeacherRequests(Guid teacherId);
        Task<List<RequestAttachment>> GetTeacherRequestById(Guid requestId);
        Task<List<Request>> GetStudentRequests(Guid studentId);
        Task<int> GenerateRquesrtNumber();
        Task<List<Request>> GetTeacherRequestReport(TeacherReportFilter filter);
        Task<List<Request>> TeacherViewRequestReport(TeacherReportMobileFilterDto filterData, Guid teacherId);
        Task<Request> GetRequestAttachmentById(Guid requestId);
    }
}


