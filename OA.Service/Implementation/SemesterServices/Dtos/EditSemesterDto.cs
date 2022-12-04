using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.SemesterServices.Dtos
{
    public class EditSemesterDto
    {

        public Guid SemesterId { get; set; }
        public string SemesterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Index { get; set; }
    }
}
