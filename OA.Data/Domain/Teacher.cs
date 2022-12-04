using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class Teacher : BaseEntity
    {

        public Teacher()
        {
            Answers = new HashSet<Answer>();
            Requests = new HashSet<Request>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        public bool PremiumSubscription { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }

}

