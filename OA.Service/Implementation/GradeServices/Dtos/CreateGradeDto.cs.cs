using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.GradeServices.Dtos
{
    public class CreateGradeDto
    {
        public Guid StageId { get; set; }

        public string GradeName { get; set; }

        public int Index { get; set; }

    }
}
