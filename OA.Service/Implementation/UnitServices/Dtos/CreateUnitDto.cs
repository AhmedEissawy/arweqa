using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UnitServices.Dtos
{
    public class CreateUnitDto
    {
        public Guid SubjectId { get; set; }
        public Guid SemesterId { get; set; }
        public string UnitName { get; set; }
        public int Index { get; set; }
    }
}
