using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.SemesterServices.Dtos
{
    public class SemesterResponseDto
    {
        public Guid SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Index { get; set; }
        public bool IsActive { get; set; }
    }
}
 