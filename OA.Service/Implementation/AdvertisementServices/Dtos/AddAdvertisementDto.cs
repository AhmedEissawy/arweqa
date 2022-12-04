using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.AdvertisementServices.Dtos
{
    public class AddAdvertisementDto
    {
        public IFormFile Advertisement { get; set; }
        public int Index { get; set; }
        public int SlideNumber { get; set; }

        public string Url { get; set; }
    }
}
