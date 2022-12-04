using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UserServices.Dtos
{
    public class EditAdminProfileDto
    {
        public string AdminId { get; set; }

        public string AdminName { get; set; }

        public Guid? SectionId { get; set; }

        public string Email { get; set; }
    }
}
