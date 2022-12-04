using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SubjectGradeServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    [AllowAnonymous]
    public class SubjectController : ApiControllersBase
    {
        private readonly ISubjectGradeService _SubjectService;
        private readonly IReportService _ReportService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        public SubjectController(ISubjectGradeService subjectService, IHubContext<NotificationHub, INotificationHub> notificationHub, IReportService reportService)
        {
            _SubjectService = subjectService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;

        }



        /// <summary>
        /// Web 
        /// </summary>
        [HttpGet]
        [Route("api/Subject/GetSubjectsByGradeAndSection")]
        public async Task<IActionResult> GetSubjectsByGradeAndSection([FromQuery]FilterGradeAndSectionDto filterDto)
        {
            List<SubjectResponseDto> subjects = await _SubjectService.GetSubjectsByGradeAndSection(filterDto);

            return Ok(subjects);
        }



        /// <summary>
        /// Web 
        /// </summary>
        [HttpGet]
        [Route("api/Subject/GetSubjectById/{subjectId}")]
        public async Task<IActionResult> GetSubjectById(Guid subjectId)
        {
            SubjectResponseDto subject = await _SubjectService.GetSubjectById(subjectId);

            return Ok(subject);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Subject/GetSubjects")]
        public async Task<IActionResult> GetSubjects(FilterDto filter)
        {
            (List<SubjectResponseDto> subjects, int rowCount) = await _SubjectService.GetSubjects(filter);

            return Ok(new { Subjects = subjects, RowCount = rowCount });
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Subject/GetStudentSubjects")]
        public async Task<IActionResult> GetStudentSubjects()
        {
            List<MobileSubjectResponseDto> subjects = await _SubjectService.GetStudentSubjects();

            return Ok(subjects);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Subject/GeStudentSubjectsForLessons")]
        public async Task<IActionResult> GeStudentSubjectsForLessons()
        {
            List<MobileSubjectResponseDto> subjects = await _SubjectService.GeStudentSubjectsForLessons();

            return Ok(subjects);
        }



        /// <summary>
        /// Web 
        /// </summary>
        [HttpPost]
        [Route("api/Subject/AddSubject")]
        public async Task<IActionResult> AddSubject([FromForm]CreateSubjectDto subject)
        {
            SubjectResponseDto createdSubject = await _SubjectService.AddSubject(subject);
           
            //DashboardReportDto report = await _ReportService.DashboardReport();
            //await _NotificationHub.Clients.All.PushDashboardReport(report);

            return Ok(createdSubject);
        }



        /// <summary>
        /// Web 
        /// </summary>
        [HttpPut]
        [Route("api/Subject/EditSubject")]
        public async Task<IActionResult> EditSubject([FromForm] EditSubjectDto subject)
        {
            SubjectResponseDto editedSubject = await _SubjectService.EditSubject(subject);

            return Ok(editedSubject);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Subject/DeleteSubject/{subjectId}")]
        public async Task<IActionResult> DeleteSubject(Guid subjectId)
        {
            await _SubjectService.DeleteSubject(subjectId);

            return NoContent();
        }



        /// <summary>
        /// Web  
        /// </summary>
        [HttpPut]
        [Route("api/Subject/SubjectActivation/{subjectId}")]
        public async Task<IActionResult> SubjectActivation(Guid subjectId)
        {
            ActivationDto subjectStatus = await _SubjectService.SubjectActivation(subjectId);

            return Ok(subjectStatus);
        }


       


    }
}