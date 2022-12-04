using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Service.Implementation.UserServices.Dtos
{
    public class RegistrationDto
    {
        [Required]
        public string UserName { get; set; }
       
        public string PhoneNumber { get; set; }

        public Guid? SectionId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
