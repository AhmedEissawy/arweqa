using OA.Service.Implementation.RequestAttachmentServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.RequestServices.Dtos
{
    public class RequestResponseDto
    {
        public Guid RequestId { get; set; }

        public int RequestNo { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool Replied { get; set; }
       
        public bool RepliedInTime { get; set; }

        public Guid SubjectId { get; set; }

        public string SubjectName { get; set; }

        public Guid StudentId { get; set; }

        public Guid TeacherId { get; set; }

       // public Guid SectionId { get; set; }

        public string SectionName { get; set; }

        public Guid StageId { get; set; }

        public string StageName { get; set; }

        public Guid GradeId { get; set; }

        public string GradeName { get; set; }

        public List<RequestAttachmentDto> Attachments { get; set; }
    }
}
