using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ReportServices.Dtos
{
   public class TeacherReportFilterDto
    {
        public Guid TeacherId { get; set; }

        public string DateFrom { get; set; }
       
        public string DateTo { get; set; }

        public Guid? SectionId { get; set; }
        
        public Guid? GradeId { get; set; }

        public Guid? StageId { get; set; }

        public Guid? SubjectId { get; set; }

    }
}
