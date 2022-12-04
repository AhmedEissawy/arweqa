using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OA.Data.Domain
{
    public class Section : BaseEntity
    {
        public Section()
        {
            SubjectGrades = new HashSet<SubjectGrade>();
            Users = new HashSet<ApplicationUser>();
            SubjectSections = new HashSet<SubjectSection>();
            Students = new HashSet<Student>();
        }

        public string SectionName { get; set; }
        public int Index { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<SubjectGrade> SubjectGrades { get; set; }

       // public virtual SubjectGrade SubjectGrade { get; set; }

        public virtual ICollection<SubjectSection> SubjectSections { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}