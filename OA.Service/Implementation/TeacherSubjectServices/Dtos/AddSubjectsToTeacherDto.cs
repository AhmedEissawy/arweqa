using OA.Service.Implementation.TeacherServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.TeacherSubjectServices.Dtos
{
    public class AddSubjectsToTeacherDto
    {
        public Guid TeacherId { get; set; }
      
        public List<TeacherSubjectPermession> Subjects { get; set; }
        public List<TeacherSubjectPermession> UpdatedPermessions { get; set; } = null;


        
    }
}
