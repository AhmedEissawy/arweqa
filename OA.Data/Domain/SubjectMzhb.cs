using System;

namespace OA.Data.Domain
{
    public class SubjectMzhb : BaseEntity
    {
        public Guid SubjectGradeId { get; set; }
        public Guid MzhbId { get; set; }

        public virtual SubjectGrade SubjectGrade { get; set; }
        public virtual Mzhb  Mzhb { get; set; }
    }
}