using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Dtos
{
    public class FilterGradeAndSectionDto
    {
        public Guid SectionId { get; set; }

        public Guid GradeId { get; set; }
    }
}
