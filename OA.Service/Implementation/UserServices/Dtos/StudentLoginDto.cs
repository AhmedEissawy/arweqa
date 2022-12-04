using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Service.Implementation.UserServices.Dtos
{
   public class StudentLoginDto
    {
        [EmailAddress]
        public string Email { get; set; }

       // public string Mobile { get; set; }
      
        public string Password { get; set; }

        public string DeviceToken { get; set; }
    }
}