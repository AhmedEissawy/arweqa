using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.RoleServices.Dtos
{
    public class EditAdminRolesDto
    {
        public string AdminId { get; set; }

        public List<AdminRolesResponseDto> Roles { get; set; }
    }
}
