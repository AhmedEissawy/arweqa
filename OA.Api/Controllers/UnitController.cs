using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.UnitServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    public class UnitController : ApiControllersBase
    {
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Unit/GetSubjectUnitsAdmin")]
        public async Task<IActionResult> GetSubjectUnitsAdmin(UnitFilterDto unitFilter)
        {
            List<UnitResponseDto> units = await _unitService.GetSubjectUnitsAdmin(unitFilter);

            return Ok(units);
        }




        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Unit/GetUnitById/{unitId}")]
        public async Task<IActionResult> GetUnitById(Guid unitId)
        {
            UnitResponseDto unit = await _unitService.GetUnitById(unitId);

            return Ok(unit);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Unit/AddUnit")]
        public async Task<IActionResult> AddUnit(CreateUnitDto unit)
        {
            UnitResponseDto createdUnit = await _unitService.AddUnit(unit);

            return Ok(createdUnit);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Unit/EditUnit")]
        public async Task<IActionResult> EditUnit(EditUnitDto unit)
        {
            UnitResponseDto editedUnit = await _unitService.EditUnit(unit);

            return Ok(editedUnit);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Unit/DeleteUnit/{unitId}")]
        public async Task<IActionResult> DeleteUnit(Guid unitId)
        {
            var result = await _unitService.DeleteUnit(unitId);

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
        [Route("api/Unit/UnitActivation/{unitId}")]
        public async Task<IActionResult> UnitActivation(Guid unitId)
        {
            ActivationDto unitStatus = await _unitService.UnitActivation(unitId);

            return Ok(unitStatus);
        }



    }
}
