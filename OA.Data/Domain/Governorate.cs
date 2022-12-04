using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
     public class Governorate : BaseEntity
    {
        public Governorate()
        {
            Students= new HashSet<Student>();
        }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}