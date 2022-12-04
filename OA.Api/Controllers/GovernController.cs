using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.StudentServices.Dtos;
using OA.Service.Interfaces.Infrastructure;
using OA.Service.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.Govern;

namespace OA.Api.Controllers
{
    [AllowAnonymous]
    public class GovernController : ApiControllersBase
    {


       
        private readonly IGovernService _governService;
        private readonly IReportService _ReportService;
        private readonly IOtpService _otpService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;

        public GovernController(IGovernService governService, IHubContext<NotificationHub, INotificationHub> notificationHub, IReportService reportService,
            IOtpService otpService)
        {
            _governService = governService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
            _otpService = otpService;
        }


        [HttpPost]
        [Route("api/Govern/Create")]
        public async Task<IActionResult> Create([FromBody] CreateGovernDto governDto)
        {
            var createdGovern = await _governService.CreateGovern(governDto) ;

            return Ok(createdGovern);
        }

        [HttpGet]
        [Route("api/Govern/Get")]
        public async Task<IActionResult> Get()
        {
            var createdGovern = await _governService.GetGoverns();

            return Ok(createdGovern);
        }
    }
}