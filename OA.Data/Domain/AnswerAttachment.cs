using System;

namespace OA.Data.Domain
{
    public class AnswerAttachment : BaseEntity
    {

        public Guid AnswerId { get; set; }

        public string File { get; set; }

        public string Type { get; set; }

        public Answer Answer { get; set; }

    }
}
