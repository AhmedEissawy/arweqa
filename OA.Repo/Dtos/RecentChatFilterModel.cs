using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Dtos
{
    public class RecentChatFilterModel
    {
        public Guid? SectionId { get; set; }
        public Guid? StageId { get; set; }
        public Guid? GradeId { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public int PageNo { get; set; } 
        public int PageSize { get; set; }
    }
}
