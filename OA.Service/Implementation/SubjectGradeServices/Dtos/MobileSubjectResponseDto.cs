using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.SubjectGradeServices.Dtos
{
    public class MobileSubjectResponseDto
    {
        public Guid SubjectId { get; set; }

        public string SubjectName { get; set; }

        public string SubjectImage { get; set; }
     
        public string SubjectSmallImage { get; set; }

    }
}
