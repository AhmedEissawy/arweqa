using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.MzhbServices.Dtos
{
    public class MzhbResponseDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Message { get; set; }
    }
}