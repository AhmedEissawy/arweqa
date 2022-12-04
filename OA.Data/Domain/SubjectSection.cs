using System;

namespace OA.Data.Domain
{
    public class SubjectSection : BaseEntity
    {
        public Guid SectionId { get; set; }
        public Guid SubjectGradeId { get; set; }

        public virtual Section Section { get; set; }
        public virtual SubjectGrade  SubjectGrade { get; set; }
    }
}