using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Interfaces.Infrastructure;
using OA.Service.Interfaces;
using System.Threading.Tasks;
using OA.Service.Implementation.BranchServices.Dtos;

namespace OA.Api.Controllers
{
    [AllowAnonymous]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private readonly IReportService _ReportService;
        private readonly IOtpService _otpService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;

        public BranchController(IBranchService branchService, IHubContext<NotificationHub, INotificationHub> notificationHub, IReportService reportService,
            IOtpService otpService)
        {
            _branchService = branchService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
            _otpService = otpService;
        }


        [HttpPost]
        [Route("api/Branch/Create")]
        public async Task<IActionResult> Create([FromBody] CreateBranchDto branchDto)
        {
            var createdBranch = await _branchService.CreateBranch(branchDto);

            return Ok(createdBranch);
        }

        [HttpGet]
        [Route("api/Branch/Get")]
        public async Task<IActionResult> Get()
        {
            var createdBranches = await _branchService.GetBranchs();

            return Ok(createdBranches);
        }
    }
}