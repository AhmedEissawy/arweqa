using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ReportServices.Dtos
{
    public class DashboardReportDto
    {
        public int Section { get; set; }
        
        public int Stage { get; set; }
        
        public int Grade { get; set; }
       
        public int Subject { get; set; }
      
        public int Student { get; set; }
     
        public int Teacher { get; set; }
            
        public int Request { get; set; }
        
        public int RepliedRequest { get; set; }
       
        public int RepliedInTimeRequest { get; set; }
        
        public int NotRepliedRequest { get; set; }
    }
}
