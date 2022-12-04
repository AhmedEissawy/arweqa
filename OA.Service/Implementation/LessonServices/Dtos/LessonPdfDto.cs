using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LessonServices.Dtos
{
    public class LessonPdfDto
    {
        public string Title { get; set; }
        public IFormFile Pdf { get; set; }
        public IFormFile Image { get; set; }
    }
}