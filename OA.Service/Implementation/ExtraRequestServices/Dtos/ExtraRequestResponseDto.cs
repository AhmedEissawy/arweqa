using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ExtraRequestServices.Dtos
{
    public class ExtraRequestResponseDto
    {
        public Guid ExtraRequestId { get; set; }

        public Guid StudentId { get; set; }

        public Guid SubjectId { get; set; }

        public int RequestCount { get; set; }

    }
}
