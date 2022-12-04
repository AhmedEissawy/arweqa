using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.LibraryServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    public class LibraryController : ApiControllersBase
    {

        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Library/GetLibraryTypes")]
        public async Task<IActionResult> GetLibraryTypes()
        {
            List<string> libraryTypes = await _libraryService.GetLibraryTypes();

            return Ok(libraryTypes);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Library/GetLibrariesForAdmin/{gradeId}")]
        public async Task<IActionResult> GetLibrariesForAdmin(Guid gradeId)
        {
            List<LibraryResponseDto> librarys = await _libraryService.GetLibrariesForAdmin(gradeId);

            return Ok(librarys);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Library/GetLibraryFilesForStudent/{libraryCode}")]
        public async Task<IActionResult> GetLibraryFilesForStudent(string libraryCode)
        {
            List<MobileLibraryResponseDto> libraryFiles = await _libraryService.GetLibraryFilesForStudent(libraryCode);

            return Ok(libraryFiles);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Library/AddLibrary")]
        public async Task<IActionResult> AddLibrary([FromForm] CreateLibraryDto library)
        {
            await _libraryService.AddLibrary(library);

            return Ok();
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Library/DeleteLibrary/{libraryId}")]
        public async Task<IActionResult> DeleteLibrary(Guid libraryId)
        {
            await _libraryService.DeleteLibrary(libraryId);

            return Ok();
        }


    }
}
