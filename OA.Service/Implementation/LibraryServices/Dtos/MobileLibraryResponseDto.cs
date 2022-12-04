using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.LibraryServices.Dtos
{
    public class MobileLibraryResponseDto
    {
        public string SemesterName { get; set; }
        public string CategoryCode { get; set; }
        public string Name { get; set; }
        public string FileImage { get; set; }
        public string File { get; set; }
        public string FileType { get; set; }
    }
}
