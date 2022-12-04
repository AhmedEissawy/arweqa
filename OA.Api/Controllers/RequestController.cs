using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Implementation.RequestAttachmentServices.Dtos;
using OA.Service.Implementation.RequestServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    public class RequestController : ApiControllersBase
    {
        private readonly INotificationService _NotificationService;
        private readonly IRequestService _RequestService;
        private readonly IReportService _ReportService;
        private readonly IRequestAttachmentService _RequestAttachmentService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        private readonly IFileHandler _FileHandler;
        public RequestController(IRequestService requestService, IRequestAttachmentService requestAttachmentService, INotificationService notificationService, IHubContext<NotificationHub, INotificationHub> notificationHub, IReportService reportService, IFileHandler fileHandler)
        {
            _RequestService = requestService;
            _RequestAttachmentService = requestAttachmentService;
            _NotificationService = notificationService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
            _FileHandler = fileHandler;
        }


        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Request/GetStudentRequests")]
        public async Task<IActionResult> GetStudentRequests()
        {

            List<MobileRequestResponseDto> requests = await _RequestService.GetStudentRequests();

            return Ok(requests);
        }




        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Request/GetRequestAttachments/{requestId}")]
        public async Task<IActionResult> GetRequestAttachments(Guid requestId)
        {
            List<RequestAttachmentDto> requests = await _RequestAttachmentService.GetRequestAttachments(requestId);

            return Ok(requests);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Request/GetTeacherRequests")]
        public async Task<IActionResult> GetTeacherRequests()
        {

            List<MobileRequestResponseDto> requests = await _RequestService.GetTeacherRequests();

            return Ok(requests);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Request/GetRequestById/{requestId}")]
        public async Task<IActionResult> GetRequestById(Guid requestId)
        {
            RequestResponseDto request = await _RequestService.GetRequestById(requestId);

            return Ok(request);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Request/GetTeacherRequestById/{requestId}")]
        public async Task<IActionResult> GetTeacherRequestById(Guid requestId)
        {
            MobileTeacherRequestResponseDto request = await _RequestService.GetTeacherRequestById(requestId);

            return Ok(request);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpPost]
        [Route("api/Request/AddRequest")]
        public async Task<IActionResult> AddRequest([FromForm] CreateRequestDto request, [FromForm] IFormFileCollection Attachments)
        {
            var Response = await _RequestService.AddRequest(request);

            if (Attachments.Count != 0)
            {
                await _RequestAttachmentService.UploadRequestAttachment(Attachments, Response.Item1.RequestId);
            }

            _NotificationService.SendNotification(await _NotificationService.GetDeviceToken(Response.Item2), "طلب جديد", $"{Response.Item1.RequestNo}: رقم الطلب   {""}لديك طلب في مادة :{Response.Item1.SubjectName}", Response.Item1.RequestId);

            DashboardReportDto report = await _ReportService.DashboardReport();
            await _NotificationHub.Clients.All.PushDashboardReport(report);

            return Ok();
        }




        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Request/RequestRedirect")]
        public async Task<IActionResult> RequestRedirect(RequestRedirectDto requestRedirect)
        {
            await _RequestService.RequestRedirect(requestRedirect);

            return Ok();
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpDelete]
        [Route("api/Request/DeleteRequest/{requestId}")]
        public async Task<IActionResult> DeleteRequest(Guid requestId)
        {
            (Guid studentId, Guid teacherId, int RequestNo ,string SubjectName) Response = await _RequestService.DeleteRequest(requestId);

            _NotificationService.SendNotification(await _NotificationService.GetDeviceToken(Response.teacherId), "تم حذف الطلب", $"{Response.RequestNo}: رقم الطلب   {""}تم حذف الطلب في مادة :{Response.SubjectName}",Guid.Empty);
            _NotificationService.SendNotification(await _NotificationService.GetDeviceToken(Response.studentId), "تم حذف الطلب", $"{Response.RequestNo}: رقم الطلب   {""}تم حذف الطلب في مادة :{Response.SubjectName}", Guid.Empty);

            return NoContent();
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Request/DeleteFullRequest/{requestId}")]
        public async Task<IActionResult> DeleteFullRequest(Guid requestId)
        {
            await _RequestService.DeleteFullRequest(requestId);

            return NoContent();
        }


    }
}