using OA.Service.Implementation.AnswerAttachmentServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.AnswerServices.Dtos
{
    public class AnswerResponseDto
    {
        public Guid AnswerId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public Guid TeacherId { get; set; }

        public Guid StudentId { get; set; }

        public Guid SubjectId { get; set; }
     
        public string SubjectName { get; set; }

        public Guid RequestId { get; set; }

      //  public Guid SectionId { get; set; }

        public string SectionName { get; set; }

        public Guid StageId { get; set; }

        public string StageName { get; set; }

        public Guid GradeId { get; set; }

        public string GradeName { get; set; }

        public List<AnswerAttachmentDto> Attachments { get; set; }

    }
}
