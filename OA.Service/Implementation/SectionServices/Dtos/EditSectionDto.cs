using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.SectionServices.Dtos
{
    public class EditSectionDto
    {
        public Guid SectionId { get; set; }

        public string SectionName { get; set; }

        public int Index { get; set; }
    }
}
