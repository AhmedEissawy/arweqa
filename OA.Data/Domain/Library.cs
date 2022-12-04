using System;
using System.Collections.Generic;

namespace OA.Data.Domain
{
    public class Library : BaseEntity
    {

        public Guid GradeId { get; set; }
        public Guid SemesterId { get; set; }
        public string CategoryCode { get; set; }
        public string Name { get; set; }
        public string FileImage { get; set; }
        public string File { get; set; }
        public string FileType { get; set; }
        public bool IsPremium { get; set; }
        public int Index { get; set; }
        public LibraryType Category { get; set; }
        public Grade Grade { get; set; }
        public Semester Semester { get; set; }

    }
}
