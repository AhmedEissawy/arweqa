using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Implementation.TeacherServices.Dtos;
using OA.Service.Implementation.TeacherSubjectServices.Dtos;
using OA.Service.Implementation.UserServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;

namespace OA.Api.Controllers
{
    public class TeacherController : ApiControllersBase
    {
        private readonly IUserService _UserService;
        private readonly ITeacherService _TeacherService;
        private readonly IReportService _ReportService;
        private readonly ITeacherSubjectService _TeacherSubjectService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        public TeacherController(ITeacherService teacherService, ITeacherSubjectService teacherSubjectService, IUserService userService, IHubContext<NotificationHub, INotificationHub> notificationHub, IReportService reportService)
        {
            _TeacherService = teacherService;
            _TeacherSubjectService = teacherSubjectService;
            _UserService = userService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Teacher/Login")]
        public async Task<IActionResult> Login(LoginDto teacher)
        {
            TeacherLoginResponseDto loginData = await _UserService.TeacherLogin(teacher);

            return Ok(loginData);

        }


        /// <summary>
        /// Web 
        /// </summary>
        [HttpPost]
        [Route("api/Teacher/GetTeachers")]
        public async Task<IActionResult> GetTeachers(FilterDto filter)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                (List<TeacherResponseDto> teachers, int count) = await _TeacherService.GetTeachers(filter);

                return Ok(new { Teachers = teachers, RowCount = count });
            }
            else
            {
                return Unauthorized();
            }
        }



        /// <summary>
        /// Web 
        /// </summary>
        [HttpGet]
        [Route("api/Teacher/GetTeacherById/{teacherId}")]
        public async Task<IActionResult> GetTeacherById(Guid teacherId)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                TeacherResponseDto teacher = await _TeacherService.GetTeacherById(teacherId);

                return Ok(teacher);
            }
            else
            {
                return Unauthorized();
            }
        }



        /// <summary>
        /// Mobile  
        /// </summary>
        [HttpGet]
        [Route("api/Teacher/TeacherViewProfile")]
        public async Task<IActionResult> TeacherViewProfile()
        {
            TeacherResponseDto teacher = await _TeacherService.TeacherViewProfile();

            return Ok(teacher);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Teacher/AddTeacher")]
        public async Task<IActionResult> AddTeacher(CreateTeacherDto teacher)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                AddSubjectsToTeacherDto teacherSubjects = await _TeacherService.AddTeacher(teacher);

                await _TeacherSubjectService.AddSubjectToTeacher(teacherSubjects);

                //DashboardReportDto report = await _ReportService.DashboardReport();
                //await _NotificationHub.Clients.All.PushDashboardReport(report);

                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Teacher/EditTeacherProfile")]
        public async Task<IActionResult> EditTeacherProfile(EditTeacherDto teacher)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                TeacherResponseDto editedTeacher = await _TeacherService.EditTeacherProfile(teacher);

                return Ok(editedTeacher);
            }
            else
            {
                return Unauthorized();
            }

        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Teacher/AddSubjectsToTeacher")]
        public async Task<IActionResult> AddSubjectsToTeacher(AddSubjectsToTeacherDto subject)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                await _TeacherSubjectService.AddSubjectToTeacher(subject);

                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Teacher/RemoveSubjectFromTeacher/{teacherSubjectId}")]
        public async Task<IActionResult> RemoveSubjectFromTeacher(Guid teacherSubjectId)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                await _TeacherSubjectService.RemoveSubjectFromTeacher(teacherSubjectId);

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Teacher/TeacherActivation/{teacherId}")]
        public async Task<IActionResult> TeacherActivation(Guid teacherId)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                ActivationDto teacherStatus = await _TeacherService.TeacherActivation(teacherId);

                return Ok(teacherStatus);
            }
            else
            {
                return Unauthorized();
            }
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Teacher/PremiumTeacherActivation/{teacherId}")]
        public async Task<IActionResult> PremiumTeacherActivation(Guid teacherId)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                ActivationDto teacherStatus = await _TeacherService.PremiumTeacherActivation(teacherId);

                return Ok(teacherStatus);
            }
            else
            {
                return Unauthorized();
            }
        }




        /// <summary>
        /// Web  
        /// </summary>
        [HttpPost]
        [Route("api/Teacher/TeacherResetPassword")]
        public async Task<IActionResult> TeacherResetPassword(ResetPasswordDto newPassword)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                await _UserService.ResetPassword(newPassword);

                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }


        /// <summary>
        /// Web  
        /// </summary>
        [HttpDelete]
        [Route("api/Teacher/DeleteTeacher/{teacherId}")]
        public async Task<IActionResult> DeleteTeacher(Guid teacherId)
        {
            if (User.IsInRole("المعلمين") || User.IsInRole("SuperAdmin"))
            {
                await _TeacherService.DeleteTeacher(teacherId);

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet("api/Teacher/GetSubjectPermessions")]
        public async Task<IActionResult> GetSubjectPermessions()
        {
            return Ok(await _TeacherSubjectService.GetSubjectPermissions());
        }

        [HttpPatch("api/Teacher/DeleteOrAddSubjectPermession")]
        public async Task<IActionResult> DeleteOrAddSubjectPermession(Guid teacherId, Guid subjectId, string permession, bool status) 
        {
            return Ok(await _TeacherSubjectService.DeleteOrAddSubjectPermession(teacherId,subjectId,permession,status));
        }




}
}