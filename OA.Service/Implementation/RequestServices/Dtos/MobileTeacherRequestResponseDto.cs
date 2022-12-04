using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.RequestServices.Dtos
{
    public class MobileTeacherRequestResponseDto
    {
        public string Description { get; set; }
      
        public string StageName { get; set; }
       
        public string GradeName { get; set; }

        public int RequestNo { get; set; }

        public List<string> Images { get; set; }
    }
}
