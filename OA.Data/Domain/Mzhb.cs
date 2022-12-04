using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
    public class Mzhb : BaseEntity
    {
        public Mzhb()
        {
            Students = new HashSet<Student>();
            SubjectMzhbs = new HashSet<SubjectMzhb>();
        }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SubjectMzhb> SubjectMzhbs { get; set; }
    }
}