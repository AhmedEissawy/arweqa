using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ExtraRequestServices.Dtos
{
    public class GetStudentExtraRequestDto
    {
        public Guid StudentId { get; set; }

        public Guid SubjectId { get; set; }
    }
}
