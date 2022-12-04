using System;

namespace OA.Service.Implementation.SemesterServices.Dtos
{
    public class CreateSemesterDto
    {
        public string SemesterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Index { get; set; }
    }
}
