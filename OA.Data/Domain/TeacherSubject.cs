using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class TeacherSubject :BaseEntity
    {
        public TeacherSubject()
        {
            SubjectPermessions = new HashSet<TeacherSubjectPermession>();
        }

       
        public Guid TeacherId { get; set; }
      
        public Guid SubjectId { get; set; }
              
        public int Role { get; set; }

        public Teacher Teacher { get; set; }

        public SubjectGrade Subject { get; set; }
        public virtual ICollection<TeacherSubjectPermession> SubjectPermessions { get; set; }

    }
    public class TeacherSubjectPermession :BaseEntity
    {
        public Guid Teacher_Subject_Id { get; set; }

        public string Permession { get; set; }
        public virtual TeacherSubject TeacherSubject { get; set; }
    }
}
