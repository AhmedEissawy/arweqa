using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UserServices.Dtos
{
    public class ResetPasswordDto
    {
        public string UserIdentityId { get; set; }

        public string NewPassword { get; set; }

    }
}
