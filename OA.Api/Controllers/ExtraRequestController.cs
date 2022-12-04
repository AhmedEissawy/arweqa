using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.ExtraRequestServices.Dtos;
using OA.Service.Interfaces;

namespace OA.Api.Controllers
{
    public class ExtraRequestController : ApiControllersBase
    {
        private readonly IExtraRequestService _ExtraRequestService;
        public ExtraRequestController(IExtraRequestService extraRequestService)
        {
            _ExtraRequestService = extraRequestService;
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/ExtraRequest/GetStudentExtraRequest")]
        public async Task<IActionResult> GetStudentExtraRequest(GetStudentExtraRequestDto extraRequest)
        {
            ExtraRequestResponseDto dbExtraRequest = await _ExtraRequestService.GetStudentExtraRequest(extraRequest);

            return Ok(dbExtraRequest);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/ExtraRequest/AddExtraRequestToStudent")]
        public async Task<IActionResult> AddExtraRequestToStudent(CreateExtraRequestDto extraRequest)
        {
            ExtraRequestResponseDto createdExtraRequest = await _ExtraRequestService.AddExtraRequestToStudent(extraRequest);

            return Ok(createdExtraRequest);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/ExtraRequest/EditStudentExtraRequest")]
        public async Task<IActionResult> EditStudentExtraRequest(EditExtraRequestDto extraRequest)
        {
            ExtraRequestResponseDto editedExtraRequest = await _ExtraRequestService.EditStudentExtraRequest(extraRequest);

            return Ok(editedExtraRequest);
        }



    }
}
