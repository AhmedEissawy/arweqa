using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UnitServices.Dtos
{
    public class EditUnitDto
    {
        public Guid UnitId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid SemesterId { get; set; }
        public string UnitName { get; set; }
        public int Index { get; set; }
    }
}
