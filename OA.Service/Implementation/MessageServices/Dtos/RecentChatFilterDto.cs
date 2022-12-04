using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.MessageServices.Dtos
{
    public class RecentChatFilterDto 
    {
        public Guid? SectionId { get; set; }
        public Guid? StageId { get; set; }
        public Guid? GradeId { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 30;
    }
}
