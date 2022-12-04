using System;
using System.Collections.Generic;

namespace OA.Data.Domain
{
    public class Student : BaseEntity
    {
        public Student()
        {
            Answers = new HashSet<Answer>();
            Requests = new HashSet<Request>();
            ExtraRequests = new HashSet<ExtraRequest>();
            StudentLessonQuestionAnswers = new HashSet<StudentLessonQuestionAnswer>();
        }

        // New Properties To Student

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string City { get; set; }
        public string Institue_Name { get; set; }


        public Guid GovernorateId { get; set; }
        public Guid? MzhbId { get; set; }
        public Guid SectionId { get; set; }
        public Guid StageId { get; set; }
        public Guid GradeId { get; set; }
        public Guid? BranchId { get; set; }
        

        public bool PremiumSubscription { get; set; }
        public string ProfileImage { get; set; } = "";

        public virtual ApplicationUser User { get; set; }
        public virtual Governorate Governorate { get; set; }
        public virtual Mzhb Mzhb { get; set; }
        public virtual Section Section { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Stage Stage { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<Request> Requests { get; set; }

        public ICollection<ExtraRequest> ExtraRequests { get; set; }
        public ICollection<StudentLessonQuestionAnswer> StudentLessonQuestionAnswers { get; set; }

    }
}