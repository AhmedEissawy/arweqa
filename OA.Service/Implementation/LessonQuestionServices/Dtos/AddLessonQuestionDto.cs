﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LessonQuestionServices.Dtos
{
    public class AddLessonQuestionDto
    {
        public Guid LessonId { get; set; }
        public string Question { get; set; }
        public IFormFile QuestionFile { get; set; }
        public int Index { get; set; }
    }

}
