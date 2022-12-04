using OA.Service.Implementation.RequestAttachmentServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.RequestServices.Dtos
{
    public class GetTeacherRequestAttachments
    {
        public int RequestNo { get; set; }

        public string Description { get; set; }

        public ICollection<RequestAttachmentDto> RequestAttachments { get; set; }
    }
}
