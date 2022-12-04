using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class Request : BaseEntity
    {
        public Request()
        {
            Answers = new HashSet<Answer>();
            RequestFiles = new HashSet<RequestAttachment>();
        }
        public int RequestNo { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool Replied { get; set; }
       
        public bool RepliedInTime { get; set; }
        
        public Guid SubjectId { get; set; }

        public Guid StudentId { get; set; }
                
        public Guid TeacherId { get; set; }
        
        public SubjectGrade Subject { get; set; }

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<RequestAttachment> RequestFiles { get; set; }
    }
}
