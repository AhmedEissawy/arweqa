using System;

namespace OA.Data.Domain
{
    public class SubjectBranch : BaseEntity
    {
        public Guid BranchId { get; set; }
        public Guid SubjectGradeId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual SubjectGrade SubjectGrade { get; set; }
    }
}