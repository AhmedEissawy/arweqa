using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Dtos
{
    public class ReportFilter : PaginationDto
    {
        public int? RequestNo { get; set; }

        public string TeacherName { get; set; }

        public string StudentName { get; set; }

        public string DateFrom { get; set; }

        public string DateTo { get; set; }

        public bool? Replied { get; set; }

        public Guid? SectionId { get; set; }

        public Guid? GradeId { get; set; }

        public Guid? StageId { get; set; }

        public Guid? SubjectId { get; set; }
    }
}
