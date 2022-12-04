using System;
using System.Collections.Generic;

namespace OA.Data.Domain
{
    public class Unit : BaseEntity
    {
        public Unit()
        {
            Lessons = new HashSet<Lesson>();
        }
        public Guid SubjectId { get; set; }
        public Guid SemesterId { get; set; }
        public string UnitName { get; set; }
        public int Index { get; set; }
        public SubjectGrade Subject { get; set; }
        public Semester Semester { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}