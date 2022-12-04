using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service.Implementation.StudentLessonQuestionAnswerServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{

    public class StudentLessonQuestionController : ApiControllersBase
    {
        private readonly IStudentLessonQuestionAnswerService _studentLessonQuestionAnswerService;
        public StudentLessonQuestionController(IStudentLessonQuestionAnswerService studentLessonQuestionAnswerService)
        {
            _studentLessonQuestionAnswerService = studentLessonQuestionAnswerService;
        }


        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/StudentLessonQuestion/GetStudentLessonQuestions/{lessonId}")]
        public async Task<IActionResult> GetStudentLessonQuestions(Guid lessonId)
        {

            List<StudentLessonQuestionDto> response = await _studentLessonQuestionAnswerService.GetStudentLessonQuestions(lessonId);

            return Ok(response);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpPost]
        [Route("api/StudentLessonQuestion/AnswerLessonQuestions")]
        public async Task<IActionResult> AnswerLessonQuestions(List<StudentLessonQuestionAnswerDto> lessonQuestionAnswers)
        {
            List<StudentAnswerResultDto> response = await _studentLessonQuestionAnswerService.AnswerLessonQuestions(lessonQuestionAnswers);

            return Ok(response);
        }

              
    }
}
