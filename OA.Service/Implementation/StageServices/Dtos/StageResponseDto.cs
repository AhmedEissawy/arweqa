using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.StageServices.Dtos
{
    public class StageResponseDto
    {
        public Guid StageId { get; set; }

        public string StageName { get; set; }

        public int Index { get; set; }

        public bool IsActive { get; set; }


    }
}
