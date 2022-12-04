using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.RequestServices.Dtos
{
    public class MobileRequestResponseDto
    {
        public Guid RequestId { get; set; }

        public int RequestNo { get; set; }
       
        public string GradeName { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool Replied { get; set; }

        public string SubjectName { get; set; }

        
    }
}
