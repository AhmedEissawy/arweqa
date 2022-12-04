using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.LibraryServices.Dtos;
using OA.Service.Implementation.SocialLinkServices.Dtos;
using OA.Service.Interfaces;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{

    public class SocialLinkController : ApiControllersBase
    {
        private readonly ISocialLinkService _socialLinkService;
        public SocialLinkController(ISocialLinkService socialLinkService)
        {
            _socialLinkService = socialLinkService;
        }



        /// <summary>
        /// Mobile & Web
        /// </summary>
        /// 
        [AllowAnonymous]
        [HttpGet]
        [Route("api/SocialLink/GetSocialLinks")]
        public async Task<IActionResult> GetSocialLinks()
        {
            return Ok(await _socialLinkService.GetSocialLinks());
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/SocialLink/EditSocialLinks")]
        public async Task<IActionResult> EditSocialLinks(SocialLinkDto socialLinks)
        {
            await _socialLinkService.EditSocialLinks(socialLinks);

            return Ok();
        }

       
    }
}
