using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.UserServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;

namespace OA.Api.Controllers
{
    public class AdminController : ApiControllersBase
    {
        private readonly IUserService _UserService;
        private readonly INotificationService _NotificationService;
        public AdminController(IUserService userService, INotificationService notificationService)
        {
            _UserService = userService;
            _NotificationService = notificationService;
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("api/Admin/Registration")]
        public async Task<IActionResult> Registration(RegistrationDto model)
        {
            var user = await _UserService.CreateUser(model);

            return Ok(user);
        }



        [AllowAnonymous]
        [HttpPost]
        [Route("api/Admin/Login")]
        public async Task<IActionResult> Login(LoginDto logindata)
        {
            var token = await _UserService.Login(logindata);
            return Ok(token);
        }



        [HttpPost]
        [Route("api/Admin/LoginEx")]
        public async Task<IActionResult> LoginEx(LoginDto logindata)
        {
            var token = await _UserService.Login(logindata);
            return Ok(token);
        }



        [HttpDelete]
        [Route("api/Admin/RemoveDeviceToken")]
        public async Task<IActionResult> RemoveDeviceToken()
        {
            await _NotificationService.RemoveDeviceToken();

            return NoContent();
        }



        [HttpGet]
        [Route("api/Admin/GetAdmins")]
        public async Task<IActionResult> GetAdmins()
        {

            if (User.IsInRole("SuperAdmin"))
            {
                List<AdminResponseDto> admins = await _UserService.GetAdmins();

                return Ok(admins);
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpGet]
        [Route("api/Admin/GetAdminById/{adminId}")]
        public async Task<IActionResult> GetAdminById(Guid adminId)
        {

             AdminResponseDto admin = await _UserService.GetAdminById(adminId);

             return Ok(admin);
           
        }



        [HttpPut]
        [Route("api/Admin/EditAadminPrpfile")]
        public async Task<IActionResult> EditAadminPrpfile(EditAdminProfileDto admin)
        {
            await _UserService.EditAdminProfile(admin);

            return Ok();

        }



        [HttpDelete]
        [Route("api/Admin/RemoveAdmin/{id}")]
        public async Task<IActionResult> RemoveAdmin(string id)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                await _UserService.RemoveAdmin(id);

                return NoContent();
            }
            else
            {
                return Unauthorized();
            }
        }




        [HttpPost]
        [Route("api/Admin/ResetPassword")]
        public async Task<IActionResult> GetAllUsers(ResetPasswordDto resetPassword)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                await _UserService.ResetPassword(resetPassword);

                return Ok();
            }

            else
            {
                return Unauthorized();
            }
        }


    }
}