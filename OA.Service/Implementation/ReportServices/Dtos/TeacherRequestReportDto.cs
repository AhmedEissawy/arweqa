using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ReportServices.Dtos
{
    public class TeacherRequestReportDto
    {
        public int Request { get; set; }

        public int RepliedRequest { get; set; }
        
        public int RepliedInTimeRequest { get; set; }

        public int NotRepliedRequest { get; set; }
    }
}
