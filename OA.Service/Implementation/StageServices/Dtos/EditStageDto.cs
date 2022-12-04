using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.StageServices.Dtos
{
    public class EditStageDto
    {
        public Guid StageId { get; set; }

        public string StageName { get; set; }

        public int Index { get; set; }
    }
}
