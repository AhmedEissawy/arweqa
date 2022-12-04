using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.Infrastructure.Dtos
{
   public class RealTimeReportDto
    {
        public int StudentCount { get; set; }
        public int TeacherCount { get; set; }
        public int RequestCount { get; set; }
        public int RepliedRequest { get; set; }
    }
}
