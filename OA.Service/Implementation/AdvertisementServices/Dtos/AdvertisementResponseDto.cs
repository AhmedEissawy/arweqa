using System;

namespace OA.Service.Implementation.AdvertisementServices.Dtos
{
    public class AdvertisementResponseDto
    {
        public Guid AdvertisementId { get; set; }
     
        public string Image { get; set; }

        public int Index { get; set; }

        public int SlideNumber { get; set; }
        public string Url { get; set; }

    }
}
