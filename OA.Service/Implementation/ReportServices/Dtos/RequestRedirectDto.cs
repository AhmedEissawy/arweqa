using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ReportServices.Dtos
{
    public class RequestRedirectDto
    {
        public Guid RequestId { get; set; }

        public Guid NewTeacherId { get; set; }

    }
}
