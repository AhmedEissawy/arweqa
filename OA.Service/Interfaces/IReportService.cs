using OA.Repo.Dtos;
using OA.Service.Implementation.ReportServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IReportService
    {
        Task<RequestsReportDataDto> GetRequestsReport(ReportFilterDto filter);

        Task<RequestAnswerReportDto> GetRequestReportDetails(Guid requestId);
       
        Task<DashboardReportDto> DashboardReport();

        Task ChangeImageExtension(ImageExtensionDto file);

        Task<TeacherRequestReportDto> GetTeacherRequestReport(TeacherReportFilterDto filter);

        Task<TeacherRequestReportDto> TeacherViewRequestReport(TeacherReportMobileFilterDto filter);
    }
}
