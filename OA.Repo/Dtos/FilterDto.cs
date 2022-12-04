using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Dtos
{
    public class FilterDto : PaginationDto
    {
        
        public string Name { get; set; }

        public string Mobile { get; set; }

        public Guid? SectionId { get; set; }

        public Guid? StageId { get; set; }

        public Guid? GradeId { get; set; }

        public Guid? SubjectId { get; set; }

        public bool? IsActive { get; set; }

    }
}