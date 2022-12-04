using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
    public class Branch : BaseEntity
    {
        public Branch() 
        {
            Students= new HashSet<Student>();
            SubjectBranches= new HashSet<SubjectBranch>();
        }

        public string Name { get; set; }   

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SubjectBranch> SubjectBranches { get; set; }
    }
}