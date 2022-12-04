using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.AdvertisementServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    
    public class AdvertisementController : ApiControllersBase
    {
        private readonly IAdvertisementService _advertisementService;
        public AdvertisementController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Advertisement/GetAdvertisementsForMobile")]
        public async Task<IActionResult> GetAdvertisementsForMobile()
        {
            List<AdvertisementMobileResponseDto> advertisements =  await _advertisementService.GetAdvertisementsForMobile();

            return Ok(advertisements);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Advertisement/GetAdvertisements")]
        public async Task<IActionResult> GetAdvertisements()
        {
            List<AdvertisementResponseDto> advertisements = await _advertisementService.GetAdvertisements();

            return Ok(advertisements);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Advertisement/UploadAdvertisements")]
        public async Task<IActionResult> UploadAdvertisements([FromForm]List<AddAdvertisementDto> advertisements)
        {
           bool result = await _advertisementService.UploadAdvertisements(advertisements);

            return Ok(result);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Advertisement/DeleteAdvertisement/{advertisementId}")]
        public async Task<IActionResult> DeleteAdvertisement(Guid advertisementId)
        {
           int  result = await _advertisementService.DeleteAdvertisement(advertisementId);

            return Ok(result);
        }



    }
}
