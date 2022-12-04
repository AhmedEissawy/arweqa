using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Service.Implementation.AnswerServices.Dtos;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;

namespace OA.Api.Controllers
{
    public class AnswerController : ApiControllersBase
    {
        private readonly IAnswerService _AnswerService;
        private readonly IReportService _ReportService;
        private readonly IAnswerAttachmentService _AnswerAttachmentService;
        private readonly INotificationService _NotificationService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        public AnswerController(IAnswerService answerService, IAnswerAttachmentService answerAttachmentService , INotificationService notificationService ,IHubContext<NotificationHub, INotificationHub> notificationHub ,IReportService reportService)
        {
            _AnswerService = answerService;
            _AnswerAttachmentService = answerAttachmentService;
            _NotificationService = notificationService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Answer/GetAnswerAttachmentByRequestId/{requestId}")]
        public async Task<IActionResult> GetAnswerAttachmentByRequestId(Guid requestId)
        {
            MobileFullAnswerResponseDto response = await _AnswerService.GetAnswerWithRequestAttachmentByRequestId(requestId);

            return Ok(response);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpPost]
        [Route("api/Answer/AddAnswerToRequest")]
        public async Task<IActionResult> AddAnswerToRequest([FromForm] CreateAnswerDto answer, [FromForm] IFormFileCollection Attachments)
        {

            var Response = await _AnswerService.AddAnswerToRequest(answer);

            if (Attachments.Count != 0)
            {
                await _AnswerAttachmentService.UploadAnswerAttachment(Attachments, Response.Item1.AnswerId);
            }

            _NotificationService.SendNotification(await _NotificationService.GetDeviceToken(Response.Item2), "تمت الإجابه على طلبك", $":تمت الإجابه على طلبك في مادة {Response.Item1.SubjectName}" , answer.RequestId);

            //DashboardReportDto report = await _ReportService.DashboardReport();
            //await _NotificationHub.Clients.All.PushDashboardReport(report);

            return Ok();
        }
        
        
        
        
        /// <summary>
        /// Mobile , Web
        /// </summary>
        [HttpDelete]
        [Route("api/Answer/DeleteAnswerFromRequest/{answerId}")]
        public async Task<IActionResult> DeleteAnswerFromRequest(Guid answerId)
        {

            var Response = await _AnswerService.DeleteAnswerFromRequest(answerId);
                    
            _NotificationService.SendNotification(await _NotificationService.GetDeviceToken(Response.Item2), "تم حذف الإجابه", $":تم حذف إجابتك على الطلب في مادة {Response.Item1}" , Guid.Empty);

            return NoContent();
        }



    }
}