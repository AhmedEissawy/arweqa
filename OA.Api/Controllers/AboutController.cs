using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.AboutServices.Dtos;
using OA.Service.Interfaces;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    public class AboutController : ApiControllersBase
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        /// <summary>
        /// Mobile
        /// </summary>
        /// 
        [AllowAnonymous]
        [HttpGet]
        [Route("api/About/AboutUs/{key}")]
        public async Task<IActionResult> AboutUs(string key)
        {
            return Ok(await _aboutService.AboutUs(key));
        }


        /// <summary>
        ///  Web
        /// </summary>
        [HttpGet]
        [Route("api/About/GetAboutUs")]
        public async Task<IActionResult> GetAboutUs()
        {
            return Ok(await _aboutService.GetAboutUs());
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/About/EditAboutUs")]
        public async Task<IActionResult> EditAboutUs(AboutDto aboutUs)
        {
            await _aboutService.EditAboutUs(aboutUs);

            return Ok();
        }


    }
}
