using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Repo.Dtos;
using OA.Service.Implementation.GradeServices.Dtos;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;

namespace OA.Api.Controllers
{
    [AllowAnonymous]
    public class GradeController : ApiControllersBase
    {
        private readonly IGradeService _GradeService;
        private readonly IReportService _ReportService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        public GradeController(IGradeService gradeService , IHubContext<NotificationHub, INotificationHub> notificationHub ,IReportService reportService)
        {
            _GradeService = gradeService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
        }

       
      
        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Grade/GetGrades")]
        public async Task<IActionResult> GetGrades(FilterDto filterDto)
        {
            (List<GradeResponseDto> grades , int count) = await _GradeService.GetGrades(filterDto);

            return Ok( new { Grades = grades, RowCount = count });
        }

        [HttpGet]
        [Route("api/Grade/GetAllGrades")]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await _GradeService.GetAllGrades();

            return Ok(grades);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Grade/GetGradeById/{gradeId}")]
        public async Task<IActionResult> GetGradeById(Guid gradeId)
        {
            GradeResponseDto grade = await _GradeService.GetGradeById(gradeId);

            return Ok(grade);
        }



        /// <summary>
        /// Web   
        /// </summary>
        [HttpGet]
        [Route("api/Grade/GetGradesByStageIdAdmin/{stageId}")]
        public async Task<IActionResult> GetGradesByStageIdAdmin(Guid stageId)
        {
            List<GradeResponseDto> grades = await _GradeService.GetGradesByStageIdAdmin(stageId);

            return Ok(grades);
        }



        /// <summary>
        /// Mobile 
        /// </summary>
        [HttpGet]
        [Route("api/Grade/GetGradesByStageId/{stageId}")]
        public async Task<IActionResult> GetGradesByStageId(Guid stageId)
        {
            List<GradeResponseDto> grades = await _GradeService.GetGradesByStageId(stageId);

            return Ok(grades);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Grade/AddGrade")]
        public async Task<IActionResult> AddGrade(CreateGradeDto grade)
        {
            GradeResponseDto createdGrade = await _GradeService.AddGrade(grade);

            //DashboardReportDto report = await _ReportService.DashboardReport();
            //await _NotificationHub.Clients.All.PushDashboardReport(report);

            return Ok(createdGrade);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Grade/EditGrade")]
        public async Task<IActionResult> EditGrade(EditGradeDto grade)
        {
            GradeResponseDto editedGrade = await _GradeService.EditGrade(grade);

            return Ok(editedGrade);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Grade/DeleteGrade/{gradeId}")]
        public async Task<IActionResult> DeleteGrade(Guid gradeId)
        {
            await _GradeService.DeleteGrade(gradeId);

            return NoContent();
        }


        /// <summary>
        /// Web  
        /// </summary>
        [HttpPut]
        [Route("api/Grade/GradeActivation/{gradeId}")]
        public async Task<IActionResult> GradeActivation(Guid gradeId)
        {
            ActivationDto gradeStatus = await _GradeService.GradeActivation(gradeId);

            return Ok(gradeStatus);
        }


    }
}