using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class Grade : BaseEntity
    {
        public Grade()
        {
            SubjectGrades = new HashSet<SubjectGrade>();
            Users = new HashSet<ApplicationUser>();
            Libraries = new HashSet<Library>();
            Students = new HashSet<Student>();
        }
 
        public string GradeName { get; set; }

        public int Index { get; set; }

        public Guid StageId { get; set; }

        public Stage Stage { get; set; }

        public ICollection<Library> Libraries { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<SubjectGrade> SubjectGrades { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
