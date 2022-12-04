using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.StudentServices.Dtos;
using OA.Service.Implementation.UserServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    [AllowAnonymous]
    public class StudentController : ApiControllersBase
    {
        private readonly IUserService _UserService;
        private readonly IStudentService _StudentService;
        private readonly IReportService _ReportService;
        private readonly IOtpService _otpService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        public StudentController(IStudentService studentService, IUserService userService, IHubContext<NotificationHub, INotificationHub> notificationHub, IReportService reportService,
            IOtpService otpService)
        {
            _StudentService = studentService;
            _UserService = userService;
            _NotificationHub = notificationHub;
            _ReportService = reportService;
           _otpService = otpService;
        }



        /// <summary>
        /// Web 
        /// </summary>
        [HttpPost]
        [Route("api/Student/GetStudents")]
        public async Task<IActionResult> GetStudents(FilterDto filter)
        {
            (List<StudentResponseDto> students, int count) = await _StudentService.GetStudents(filter);

            return Ok(new { rowCount = count, Students = students });
        }
      
        
        [HttpPost("api/Student/GetStudentsCount")]
        public async Task<IActionResult> GetUsersCount(FilterDto filter)
        {
            return Ok(await _StudentService.GetStudentsCount(filter));
        }




        /// <summary>
        /// Web 
        /// </summary>
        [HttpGet]
        [Route("api/Student/GetStudentById/{studentId}")]
        public async Task<IActionResult> GetStudentById(Guid studentId)
        {
            StudentResponseDto student = await _StudentService.GetStudentById(studentId);

            return Ok(student);
        }



        /// <summary>
        /// Mobile 
        /// </summary>
        [HttpGet]
        [Route("api/Student/StudentViewProfile")]
        public async Task<IActionResult> StudentViewProfile()
        {
            StudentResponseDto student = await _StudentService.StudentViewProfile();

            return Ok(student);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Student/Login")]
        public async Task<IActionResult> Login(StudentLoginDto student)
        {
            StudentLoginResponseDto loginData = await _UserService.StudentLogin(student);

            return Ok(loginData);

        }



        /// <summary>
        /// Mobile  
        /// </summary>
        /// 
       
        [HttpPost]
        [Route("api/Student/StudentRegistration")]
        public async Task<IActionResult> StudentRegistration([FromForm]CreateStudentDto student)
        {
            StudentResponseDto createdStudent = await _StudentService.AddStudent(student);

            //DashboardReportDto report = await _ReportService.DashboardReport();
            //await _NotificationHub.Clients.All.PushDashboardReport(report);

            return Ok(createdStudent);

        }

        [HttpPost]
        [Route("api/Student/Register")]
        public async Task<IActionResult> Register([FromForm] RegisterStudentDto student)
        {
            StudentResponseDto createdStudent = await _StudentService.RegisterStudent(student);

            //DashboardReportDto report = await _ReportService.DashboardReport();
            //await _NotificationHub.Clients.All.PushDashboardReport(report);

            return Ok(createdStudent);

        }



        /// <summary>
        /// Mobile 
        /// </summary>
        [HttpPut]
        [Route("api/Student/StudentEditProfile")]
        public async Task<IActionResult> StudentEditProfile([FromForm]EditStudentDto student)
        {
            StudentResponseDto editedStudent = await _StudentService.StudentEditProfile(student);

            return Ok(editedStudent);
        }



        /// <summary>
        /// Web 
        /// </summary>
        [HttpPut]
        [Route("api/Student/AdminStudentEditProfile")]
        public async Task<IActionResult> AdminStudentEditProfile(AdminEditStudentDto student)
        {
            StudentResponseDto editedStudent = await _StudentService.AdminStudentEditProfile(student);

            return Ok(editedStudent);
        }


        /// <summary>
        /// Web  
        /// </summary>
        [HttpPut]
        [Route("api/Student/PremiumStudentActivation/{studentId}")]
        public async Task<IActionResult> PremiumStudentActivation(Guid studentId)
        {
            ActivationDto studentStatus = await _StudentService.PremiumStudentActivation(studentId);

            return Ok(studentStatus);
        }


        /// <summary>
        /// Web  
        /// </summary>
        [HttpPut]
        [Route("api/Student/StudentActivation/{studentId}")]
        public async Task<IActionResult> StudentActivation(Guid studentId)
        {
            ActivationDto studentStatus = await _StudentService.StudentActivation(studentId);

            return Ok(studentStatus);
        }



        /// <summary>
        /// Web  & Mobile
        /// </summary>
        [HttpDelete]
        [Route("api/Student/DeleteStudent")]
        public async Task<IActionResult> DeleteStudent([FromQuery]Guid? studentId)
        {
            await _StudentService.DeleteStudent(studentId);

            return NoContent();
        }
        /// <summary>
        /// Student - Web
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        ///
        [AllowAnonymous]
        [HttpGet("api/Student/SendVerification")]
        public async Task<IActionResult> SendVerfication(string phone) 
        {
            return Ok(await _otpService.SendConfirmationCode(phone));
        }
        [AllowAnonymous]
        [HttpPost("api/Student/VerifyOtp")]
        public async Task<IActionResult> VerifyOtp([FromBody]VerificationDto verification) 
        {
            return Ok(await _otpService.ValidateConfirmationCode(verification.Phone, verification.Code));
        }



    }
}