using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.BranchServices.Dtos
{
    public class ResponseBranchDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }
    }
}
