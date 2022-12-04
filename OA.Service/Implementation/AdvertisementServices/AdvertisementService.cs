using Microsoft.AspNetCore.Http;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.AdvertisementServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.AdvertisementServices
{
    public class AdvertisementService : IAdvertisementService
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IFileHandler _FileHandler;
        public AdvertisementService(IAdvertisementRepository advertisementRepository, IFileHandler fileHandler)
        {
            _advertisementRepository = advertisementRepository;
            _FileHandler = fileHandler;
        }



        public async Task<List<AdvertisementMobileResponseDto>> GetAdvertisementsForMobile()
        {
            List<Advertisement> dbAdvertisement = await _advertisementRepository.GetAllAsync();

            List<AdvertisementMobileResponseDto> advertisements = new List<AdvertisementMobileResponseDto>();

            advertisements = dbAdvertisement.OrderBy(q => q.Index).Select(q => new AdvertisementMobileResponseDto()
            {
                Image = q.File,
                SlideNumber = q.SlideNumber,
                Url=q.Url

            }).ToList();

            return advertisements;
        }


        public async Task<List<AdvertisementResponseDto>> GetAdvertisements()
        {
            List<Advertisement> dbAdvertisement = await _advertisementRepository.GetAllAsync();

            List<AdvertisementResponseDto> advertisements = new List<AdvertisementResponseDto>();

            advertisements = dbAdvertisement.OrderBy(q => q.Index).Select(q => new AdvertisementResponseDto()
            {
                AdvertisementId = q.Id,
                Image = q.File,
                Index = q.Index,
                SlideNumber = q.SlideNumber,
                Url=q.Url
            }).ToList();

            return advertisements;
        }



        public async Task<bool> UploadAdvertisements(List<AddAdvertisementDto> newAdvertisement)
        {
            if (newAdvertisement.Count() == 0 || newAdvertisement == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No advertisements found ...!" });

            List<Advertisement> advertisements = new List<Advertisement>();

            foreach (AddAdvertisementDto attachment in newAdvertisement)
            {
                Advertisement advertisement = new Advertisement();

                advertisement.Id = Guid.NewGuid();
                advertisement.File = await ConvertAndUpload(attachment.Advertisement);
                advertisement.SlideNumber = attachment.SlideNumber;
                advertisement.Index = attachment.Index;
                advertisement.Url = attachment.Url;

                advertisements.Add(advertisement);
            }

            await _advertisementRepository.AddRangeAsync(advertisements);

            bool succeeded = await _advertisementRepository.SaveChangesAsync() > 0 ? true : false;

            if (succeeded)
            {
                return true;
            }

            else
            {
                throw new Exception("Error saving The data ...!");
            }

        }




        public async Task<int> DeleteAdvertisement(Guid advertisementId)
        {
            Advertisement advertisement = (await _advertisementRepository.FindAsync(q => q.Id == advertisementId)).FirstOrDefault();

            if (advertisement == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Advertisement with id = {advertisementId} not found ...!" });

            if (!string.IsNullOrEmpty(advertisement.File) && !string.IsNullOrWhiteSpace(advertisement.File))
            {
                bool advertisementDeleted = _FileHandler.DeleteFile(advertisement.File, FolderName.Advertisements.ToString());
            }

            _advertisementRepository.Remove(advertisement);

            int result = 0;

            try
            {
                result = await _advertisementRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return result;
            }

            return result;
        }



        private async Task<string> ConvertAndUpload(IFormFile attachment)
        {
            if (attachment.Length == 0) throw new Exception("Error saving answer attachment ...!");

            return await _FileHandler.SaveImageConverter(attachment, FolderName.Advertisements.ToString());
        }
    }
}
