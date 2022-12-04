
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;

namespace OA.Service.Implementation.UserServices.Dtos
{
    public class LoginDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string DeviceToken { get; set; }

     
    }
}
