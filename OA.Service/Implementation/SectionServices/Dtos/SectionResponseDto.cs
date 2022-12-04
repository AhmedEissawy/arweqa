using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.SectionServices.Dtos
{
    public class SectionResponseDto
    {
        public Guid SectionId { get; set; }

        public string SectionName { get; set; }

        public bool IsActive { get; set; }
        public int Index { get; set; }

    }
}
