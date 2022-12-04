using AutoMapper;
using Microsoft.AspNetCore.Http;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.RequestAttachmentServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.RequestAttachmentServices
{
    public class RequestAttachmentService : IRequestAttachmentService
    {
        private readonly IMapper _Mapper;
        private readonly IFileHandler _FileHandler;
        private readonly IRequestAttachmentRepo _RequestAttachmentRepo;
        public RequestAttachmentService(IRequestAttachmentRepo requestAttachmentRepo, IFileHandler fileHandler, IMapper mapper)
        {
            _RequestAttachmentRepo = requestAttachmentRepo;
            _FileHandler = fileHandler;
            _Mapper = mapper;

        }



        public async Task<List<RequestAttachmentDto>> GetRequestAttachments(Guid requestId)
        {
            List<RequestAttachment> requests = await _RequestAttachmentRepo.GetRequestAttachments(requestId);

            return _Mapper.Map<List<RequestAttachmentDto>>(requests);
        }



        public async Task<bool> UploadRequestAttachment(IFormFileCollection attachments, Guid requestId)
        {
            if (attachments.Count == 0 || attachments == null || requestId == Guid.Empty) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No attachments found ...!" });

            List<RequestAttachment> requestAttachments = new List<RequestAttachment>();

            foreach (var attachment in attachments)
            {
                RequestAttachment requestFiles = new RequestAttachment();

                string savedAttachment = null;

                requestFiles.Id = Guid.NewGuid();
                requestFiles.RequestId = requestId;
                var extension = attachment.FileName.Split('.').Last();

                requestFiles.Type = ((extension == "jpg") || (extension == "JPG") || (extension == "png") || (extension == "PNG") || (extension == "jpeg") || (extension == "JPEG") || (extension == "MOV") || (extension == "mov") || (extension == "HEIC") || (extension == "heic") || (extension == "plist") || (extension == "PLIST")) ? FileType.Image.ToString() : FileType.Link.ToString();


                if (requestFiles.Type == FileType.Link.ToString())
                {
                    savedAttachment = await Upload(attachment);
                }
                else
                {
                    savedAttachment = await ConvertAndUpload(attachment);
                }

                requestFiles.File = savedAttachment;

                requestAttachments.Add(requestFiles);

            }
            await _RequestAttachmentRepo.AddRangeAsync(requestAttachments);

            bool succeeded = await _RequestAttachmentRepo.SaveChangesAsync() > 0 ? true : false;

            if (succeeded)
            {
                return true;
            }

            else
            {
                throw new Exception("Error saving The data ...!");
            }

        }





        private async Task<string> Upload(IFormFile attachment)
        {
            _FileHandler.ValiadteFile(attachment);

            if (attachment.Length == 0) throw new Exception("Error saving request attachment ...!");

            return await _FileHandler.SaveFile(attachment, FolderName.Requests.ToString());

        }


        private async Task<string> ConvertAndUpload(IFormFile attachment)
        {
            if (attachment.Length == 0) throw new Exception("Error saving request attachment ...!");

            return await _FileHandler.SaveImageConverter(attachment, FolderName.Requests.ToString());
        }



    }
}
