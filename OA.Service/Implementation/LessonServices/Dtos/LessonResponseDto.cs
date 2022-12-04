using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LessonServices.Dtos
{
    public class LessonResponseDto
    {
        public Guid LessonId { get; set; }
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public string LessonName { get; set; }
        public bool IsActive { get; set; }
        public int Index { get; set; }

    }
}
