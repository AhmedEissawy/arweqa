using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
    public class SubjectGrade :BaseEntity
    {
        public SubjectGrade()
        {
            Answers = new HashSet<Answer>();
            Requests = new HashSet<Request>();
            TeacherSubjects = new HashSet<TeacherSubject>();
            ExtraRequests = new HashSet<ExtraRequest>();
            Units = new HashSet<Unit>();
            SubjectSections = new HashSet<SubjectSection>();
            SubjectMzhbs = new HashSet<SubjectMzhb>();
            SubjectBranches = new HashSet<SubjectBranch>();
        }

        //public Guid SectionId { get; set; }

        public Guid GradeId { get; set; }

        public string SubjectName { get; set; }
       
        public string SubjectImage { get; set; }
       
        public string SubjectSmallImage { get; set; }

        public int Index { get; set; }

      //  public Section Section { get; set; }

        public Grade Grade { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public ICollection<ExtraRequest> ExtraRequests { get; set; }
        public ICollection<Unit> Units { get; set; }

        public virtual ICollection<SubjectSection> SubjectSections { get; set; }
        public virtual ICollection<SubjectMzhb> SubjectMzhbs { get; set; }
        public virtual ICollection<SubjectBranch>  SubjectBranches { get; set; }
    }
}