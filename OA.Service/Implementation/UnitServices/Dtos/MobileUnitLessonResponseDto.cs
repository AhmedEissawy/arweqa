using OA.Service.Implementation.LessonServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UnitServices.Dtos
{
    public class MobileUnitLessonResponseDto
    {
        public string UnitName { get; set; }
        public List<MobileLessonResponseDto> Lessons { get; set; }
        
    }
}
