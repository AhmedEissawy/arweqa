using Microsoft.AspNetCore.Http;
using OA.Service.Implementation.AdvertisementServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IAdvertisementService
    {
        Task<List<AdvertisementMobileResponseDto>> GetAdvertisementsForMobile();
        Task<List<AdvertisementResponseDto>> GetAdvertisements();
        Task<bool> UploadAdvertisements(List<AddAdvertisementDto> newAdvertisement);
        Task<int> DeleteAdvertisement(Guid advertisementId);
    }
}
