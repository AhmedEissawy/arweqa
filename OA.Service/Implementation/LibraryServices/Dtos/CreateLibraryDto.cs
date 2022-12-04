using Microsoft.AspNetCore.Http;
using System;

namespace OA.Service.Implementation.LibraryServices.Dtos
{
    public class CreateLibraryDto
    {
        public Guid GradeId { get; set; }
        public Guid SemesterId { get; set; }
        public string CategoryCode { get; set; }
        public string Name { get; set; }
        public bool IsPremium { get; set; }
        public IFormFile FileImage { get; set; }
        public IFormFile File { get; set; }
        public int Index { get; set; }
    }
}
