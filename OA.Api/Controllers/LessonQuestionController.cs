using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.LessonQuestionServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{

    public class LessonQuestionController : ApiControllersBase
    {
        private readonly ILessonQuestionService _lessonQuestionService;
        public LessonQuestionController(ILessonQuestionService lessonQuestionService)
        {
            _lessonQuestionService = lessonQuestionService;
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/LessonQuestion/LessonQuestions/{lessonId}")]
        public async Task<IActionResult> LessonQuestions(Guid lessonId)
        {

            List<LessonQuestionDto> response = await _lessonQuestionService.LessonQuestions(lessonId);

            return Ok(response);
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/LessonQuestion/AddLessonQuestion")]
        public async Task<IActionResult> AddLessonQuestion([FromForm] AddLessonQuestionDto lessonQuestion)
        {
            Guid lessonQuestionId = await _lessonQuestionService.AddLessonQuestion(lessonQuestion);

            return Ok(lessonQuestionId);
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/LessonQuestion/AddLessonQuestionAnswer")]
        public async Task<IActionResult> AddLessonQuestionAnswer([FromForm] AddLessonQuestionAnswerDto lessonQuestionAnswer)
        {
            Guid response = await _lessonQuestionService.AddLessonQuestionAnswer(lessonQuestionAnswer);

            return Ok(response);
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpPut]
        [Route("api/LessonQuestion/EditLessonQuestion")]
        public async Task<IActionResult> EditLessonQuestion([FromForm] EditLessonQuestionDto lessonQuestion)
        {
            await _lessonQuestionService.EditLessonQuestion(lessonQuestion);

            return Ok();
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/LessonQuestion/DeleteLessonQuestionAnswer/{answerId}")]
        public async Task<IActionResult> DeleteLessonQuestionAnswer(Guid answerId)
        {
            await _lessonQuestionService.DeleteLessonQuestionAnswer(answerId);

            return NoContent();
        }


        /// <summary>
        /// Web
        /// </summary>
        [HttpDelete]
        [Route("api/LessonQuestion/DeleteLessonQuestion/{questionId}")]
        public async Task<IActionResult> DeleteLessonQuestion(Guid questionId)
        {
            await _lessonQuestionService.DeleteLessonQuestion(questionId);

            return NoContent();
        }


    }
}
