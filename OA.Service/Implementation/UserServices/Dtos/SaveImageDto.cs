using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.UserServices.Dtos
{
    public class SaveImageDto
    {
        public IFormFile Image { get; set; }

    }
}
