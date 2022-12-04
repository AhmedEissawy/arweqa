using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.Govern;
using OA.Service.Interfaces;
using System.Threading.Tasks;
using OA.Service.Implementation.MzhbServices.Dtos;

namespace OA.Api.Controllers
{
    [AllowAnonymous]
    public class MzhbController : ApiControllersBase
    {
        private readonly IMzhbService _mzhbService;

        public MzhbController(IMzhbService mzhbService)
        {
            _mzhbService = mzhbService;
        }

        [HttpPost]
        [Route("api/Mzhb/Create")]
        public async Task<IActionResult> Create([FromBody] MzhbCreateDto mzhb)
        {
            var createdMzhb = await _mzhbService.CreateMzhb(mzhb);

            return Ok(createdMzhb);
        }

        [HttpGet]
        [Route("api/Mzhb/Get")]
        public async Task<IActionResult> Get()
        {
            var createdMzhb = await _mzhbService.GetMzhbs();

            return Ok(createdMzhb);
        }

    }
}