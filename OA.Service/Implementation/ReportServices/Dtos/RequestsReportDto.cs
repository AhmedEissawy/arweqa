using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ReportServices.Dtos
{
    public class RequestsReportDto
    {
        public string RequestId { get; set; }
       
        public string RequestNo { get; set; }
      
        public DateTime Date { get; set; }
        
        public bool Replied { get; set; }

        public bool RepliedInTime { get; set; }

        public string SectionName { get; set; }
       
        public string GradeName { get; set; }
      
        public string TeacherName { get; set; }

        public string SubjectName { get; set; }

        public string StudentName { get; set; }

    }
}
