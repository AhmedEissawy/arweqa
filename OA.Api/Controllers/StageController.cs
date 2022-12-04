using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Implementation.StageServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;

namespace OA.Api.Controllers
{
    [AllowAnonymous]
    public class StageController : ApiControllersBase
    {
        private readonly IStageService _StageService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        private readonly IReportService _ReportService;
        public StageController(IStageService stageService , IHubContext<NotificationHub, INotificationHub> notificationHub ,IReportService reportService)
        {
            _StageService = stageService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Stage/GetAllStagesAdmin")]
        public async Task<IActionResult> GetAllStagesAdmin()
        {
            List<StageResponseDto> stages = await _StageService.GetAllStagesAdmin();

            return Ok(stages);
        }


        /// <summary>
        /// Mobile 
        /// </summary>
        [HttpGet]
        [Route("api/Stage/GetStages")]
        public async Task<IActionResult> GetStages()
        {
            List<StageResponseDto> stages = await _StageService.GetStages();

            return Ok(stages);
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Stage/GetStageById/{stageId}")]
        public async Task<IActionResult> GetStageById(Guid stageId)
        {
            StageResponseDto stage = await _StageService.GetStageById(stageId);

            return Ok(stage);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Stage/AddStage")]
        public async Task<IActionResult> AddStage(CreateStageDto stage)
        {
            StageResponseDto createdStage = await _StageService.AddStage(stage);

            //DashboardReportDto report = await _ReportService.DashboardReport();
            //await _NotificationHub.Clients.All.PushDashboardReport(report);

            return Ok(createdStage);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Stage/EditStage")]
        public async Task<IActionResult> EditStage(EditStageDto stage)
        {
            StageResponseDto editedStage = await _StageService.EditStage(stage);

            return Ok(editedStage);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Stage/DeleteStage/{stageId}")]
        public async Task<IActionResult> DeleteStage(Guid stageId)
        {
            await _StageService.DeleteStage(stageId);

            return NoContent();
        }



        /// <summary>
        /// Web  
        /// </summary>
        [HttpPut]
        [Route("api/Stage/StageActivation/{stageId}")]
        public async Task<IActionResult> StageActivation(Guid stageId)
        {
            ActivationDto stageStatus = await _StageService.StageActivation(stageId);

            return Ok(stageStatus);
        }



    }
}