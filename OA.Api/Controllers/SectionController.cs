using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SectionServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    [AllowAnonymous]
    public class SectionController : ApiControllersBase
    {
        private readonly ISectionService _SectionService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        private readonly IReportService _ReportService;
        public SectionController(ISectionService sectionService, IHubContext<NotificationHub, INotificationHub> notificationHub, IReportService reportService)
        {
            _SectionService = sectionService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
        }



        /// <summary>
        /// Web  
        /// </summary>
        [HttpGet]
        [Route("api/Section/GetAllSectionsAdmin")]
        public async Task<IActionResult> GetAllSectionsAdmin()
        {
            List<SectionResponseDto> sections = await _SectionService.GetAllSectionsAdmin();

            return Ok(sections);
        }


        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Section/GetSections")]
        public async Task<IActionResult> GetSections()
        {
            List<SectionResponseDto> sections = await _SectionService.GetSections();

            return Ok(sections);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Section/GetSectionById/{sectionId}")]
        public async Task<IActionResult> GetSectionById(Guid sectionId)
        {
            SectionResponseDto section = await _SectionService.GetSectionById(sectionId);

            return Ok(section);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Section/AddSection")]
        public async Task<IActionResult> AddSection(CreateSectionDto section)
        {
            SectionResponseDto createdSection = await _SectionService.AddSection(section);

            //DashboardReportDto report = await _ReportService.DashboardReport();
            //await _NotificationHub.Clients.All.PushDashboardReport(report);

            return Ok(createdSection);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Section/EditSection")]
        public async Task<IActionResult> EditStage(EditSectionDto section)
        {
            SectionResponseDto editedSection = await _SectionService.EditSection(section);

            return Ok(editedSection);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Section/DeleteSection/{sectionId}")]
        public async Task<IActionResult> DeleteStage(Guid sectionId)
        {
           var result = await _SectionService.DeleteSection(sectionId);

            if (result.Item2 == 0)
            {
                return BadRequest(result.Item1);
            }
           return Ok(result.Item1);
        }


        /// <summary>
        /// Web  
        /// </summary>
        [HttpPut]
        [Route("api/Section/SectionActivation/{sectionId}")]
        public async Task<IActionResult> SectionActivation(Guid sectionId)
        {
            ActivationDto sectionStatus = await _SectionService.SectionActivation(sectionId);

            return Ok(sectionStatus);
        }


    }
}
