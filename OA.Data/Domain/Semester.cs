using System;
using System.Collections.Generic;

namespace OA.Data.Domain
{
    public class Semester : BaseEntity
    {
        public Semester()
        {
            Units = new HashSet<Unit>();
            Libraries = new HashSet<Library>();
        }

        public string SemesterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Index { get; set; }
        public ICollection<Unit> Units { get; set; }
        public ICollection<Library> Libraries { get; set; }
    }
}

