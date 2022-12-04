using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
   public class ExtraRequest : BaseEntity
    {
        public Guid StudentId { get; set; }

        public Guid SubjectId { get; set; }
      
        public int RequestCount { get; set; }
             
        public SubjectGrade Subject { get; set; }

        public Student Student { get; set; }

    }
}
