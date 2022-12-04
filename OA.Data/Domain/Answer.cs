using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class Answer : BaseEntity
    {
        public Answer()
        {
            AnswerFiles = new HashSet<AnswerAttachment>();
        }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public Guid TeacherId { get; set; }

        public Guid StudentId { get; set; }

        public Guid SubjectId { get; set; }

        public Guid RequestId { get; set; }

        public SubjectGrade Subject { get; set; }

        public Teacher Teacher { get; set; }

        public Student Student { get; set; }

        public Request Request { get; set; }

        public ICollection<AnswerAttachment> AnswerFiles { get; set; }
    }

}
