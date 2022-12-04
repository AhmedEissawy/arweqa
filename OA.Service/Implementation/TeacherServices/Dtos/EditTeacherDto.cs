using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.TeacherServices.Dtos
{
    public class EditTeacherDto
    {
        public Guid TeacherId { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public bool PremiumSubscription { get; set; }



    }

}
