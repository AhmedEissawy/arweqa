using Microsoft.AspNetCore.Mvc;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using OA.Service.Implementation.LessonServices.Dtos;
using OA.Service.Implementation.UnitServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    public class LessonController : ApiControllersBase
    {

        private readonly ILessonService _lessonService;
        private readonly ILessonAttachmentService _lessonAttachmentService;
        public LessonController(ILessonService lessonService, ILessonAttachmentService lessonAttachmentService)
        {
            _lessonService = lessonService;
            _lessonAttachmentService = lessonAttachmentService;
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Lesson/GetUnitLessonsForAdmin/{unitId}")]
        public async Task<IActionResult> GetUnitLessonsForAdmin(Guid unitId)
        {
            List<LessonResponseDto> lessons = await _lessonService.GetUnitLessonsForAdmin(unitId);

            return Ok(lessons);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Lesson/GetUnitLessonByIdForAdmin/{lessonId}")]
        public async Task<IActionResult> GetUnitLessonByIdForAdmin(Guid lessonId)
        {
            LessonDetailsDto lesson = await _lessonService.GetLessonDetailsForAdmin(lessonId);

            return Ok(lesson);
        }


        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Lesson/GetSubjectUnitsLessons/{subjectId}")]
        public async Task<IActionResult> GetSubjectUnitsLessons(Guid subjectId)
        {
            IEnumerable<MobileUnitLessonResponseDto> units = await _lessonService.GetSubjectUnitsLessonsForStudent(subjectId);

            return Ok(units);
        }


        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Lesson/GetLessonFilesForStudent/{lessonId}")]
        public async Task<IActionResult> GetLessonFilesForStudent(Guid lessonId)
        {
            List<MobileLessonFilesDto> lessonFiles = await _lessonService.GetLessonFilesForStudent(lessonId);

            return Ok(lessonFiles);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Lesson/GetLessonVideosForStudentWeb/{lessonId}")]
        public async Task<IActionResult> GetLessonVideosForStudentWeb(Guid lessonId)
        {
            var lessonVideos = await _lessonService.GetLessonVideosForStudent(lessonId);

            return Ok(lessonVideos);
        }
        [HttpGet]
        [Route("api/Lesson/GetLessonVideosForStudent/{lessonId}")]
        public async Task<IActionResult> GetLessonVideosForStudent(Guid lessonId)
        {
            var lessonVideos = await _lessonService.GetLessonVideosForStudent(lessonId);

            return Ok(lessonVideos.Videos);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Lesson/AddLesson")]
        public async Task<IActionResult> AddLesson([FromForm] CreateLessonDto lesson)
        {
            if(lesson.pdf != null)
            foreach (var item in lesson.pdf.ToList())
            {
                    if (item.Pdf == null)
                    {
                        lesson.pdf.Remove(item);
                        continue;
                    }
                    string result = item?.Pdf?.FileName?.Split('.').Last();

                    if (result.ToLower() != FileType.PDF.ToString().ToLower()) throw new RestException(HttpStatusCode.BadRequest, new { message = $" Lesson Files Type Must Be PDF Only ...!" });
                }

            var Response = await _lessonService.AddLesson(lesson);

            if (lesson.pdf != null || lesson.Videos != null)
            {
                await _lessonAttachmentService.AddLessonAttachments(lesson.pdf, lesson.Videos, Response.Item2);
            }

            return Ok();
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/Lesson/EditLesson")]
        public async Task<IActionResult> EditLesson([FromForm] EditLessonDto lesson)
        {
            if(lesson.pdf != null)
            foreach (var item in lesson.pdf)
            {
                //string result = item.Pdf.FileName.Split('.').Last();

                /*if (result.ToLower() != FileType.PDF.ToString().ToLower()) throw new RestException(HttpStatusCode.BadRequest, new { message = $" Lesson Files Type Must Be PDF Only ...!" })*/;
            }

            var Response = await _lessonService.EditLesson(lesson);

            await _lessonAttachmentService.EditLessonAttachments(lesson.pdf, lesson.Videos, Response.Item2);

            return Ok();
        }




        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Lesson/DeleteLessonAttachment/{attachmentId}")]
        public async Task<IActionResult> DeleteLessonAttachment(Guid attachmentId)
        {
            var result = await _lessonAttachmentService.DeleteLessonAttachment(attachmentId);

            return Ok(result);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/Lesson/DeleteLesson/{lessonId}")]
        public async Task<IActionResult> DeleteLesson(Guid lessonId)
        {
            var result = await _lessonService.DeleteLesson(lessonId);

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
        [Route("api/Lesson/LessonActivation/{lessonId}")]
        public async Task<IActionResult> LessonActivation(Guid lessonId)
        {
            ActivationDto lessonStatus = await _lessonService.LessonActivation(lessonId);

            return Ok(lessonStatus);
        }

    }
}
