using System;

namespace OA.Data.Domain
{
    public class RequestAttachment : BaseEntity
    {
        public Guid RequestId { get; set; }

        public string File { get; set; }

        public string Type { get; set; }

        public Request Request { get; set; }

    }
}
