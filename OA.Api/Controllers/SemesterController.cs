using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SemesterServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    public class SemesterController : ApiControllersBase
    {
        private readonly ISemesterService _semesterService;
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Semester/GetSemesters")]
        public async Task<IActionResult> GetSemesters()
        {
            List<SemesterResponseDto> semesters = await _semesterService.GetSemesters();

            return Ok(semesters);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Semester/GetSemesterById/{semesterId}")]
        public async Task<IActionResult> GetSemesterById(Guid semesterId)
        {
            SemesterResponseDto semester = await _semesterService.GetSemesterById(semesterId);

            return Ok(semester);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Semester/AddSemester")]
        public async Task<IActionResult> AddSemester(CreateSemesterDto semester)
        {
            SemesterResponseDto createdSemester = await _semesterService.AddSemester(semester);

            return Ok(semester);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Semester/EditSemester")]
        public async Task<IActionResult> EditSemester(EditSemesterDto semester)
        {
            SemesterResponseDto editedSemester = await _semesterService.EditSemester(semester);

            return Ok(editedSemester);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Semester/DeleteSemester/{semesterId}")]
        public async Task<IActionResult> DeleteSemester(Guid semesterId)
        {
            var result = await _semesterService.DeleteSemester(semesterId);

            if (result.Item2 == 0)
            {
                return BadRequest(result.Item1);
            }
            return Ok(result.Item1);
        }



        /// <summary>
        ///   Web
        /// </summary>
        [HttpPut]
        [Route("api/Semester/SemesterActivation/{semesterId}")]
        public async Task<IActionResult> SemesterActivation(Guid semesterId)
        {
            ActivationDto semesterStatus = await _semesterService.SemesterActivation(semesterId);

            return Ok(semesterStatus);
        }


    }
}
