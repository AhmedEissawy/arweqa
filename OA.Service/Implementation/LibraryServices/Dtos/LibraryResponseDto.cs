using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LibraryServices.Dtos
{
    public class LibraryResponseDto
    {
        public Guid LibraryId { get; set; }
        public Guid GradeId { get; set; }
        public string GradeName { get; set; }
        public Guid SemesterId { get; set; }
        public string SemesterName { get; set; }
        public string CategoryCode { get; set; }
        public string Name { get; set; }
        public string FileImage { get; set; }
        public string File { get; set; }
        public bool IsPremium { get; set; }
        public int Index { get; set; }
    }
}
