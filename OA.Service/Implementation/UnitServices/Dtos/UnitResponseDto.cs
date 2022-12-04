using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UnitServices.Dtos
{
    public class UnitResponseDto
    {   
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Guid SemesterId { get; set; }
        public string SemesterName { get; set; }
        public bool IsActive { get; set; }
        public int Index { get; set; }
    }
}
