using Microsoft.AspNetCore.Http;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.AnswerAttachmentServices
{
    public class AnswerAttachmentService : IAnswerAttachmentService
    {
        private readonly IFileHandler _FileHandler;
        private readonly IAnswerAttachmentRepo _AnswerAttachmentRepo;
        public AnswerAttachmentService(IAnswerAttachmentRepo answerAttachmentRepo, IFileHandler fileHandler)
        {
            _AnswerAttachmentRepo = answerAttachmentRepo;
            _FileHandler = fileHandler;

        }



        public async Task<bool> UploadAnswerAttachment(IFormFileCollection attachments, Guid answerId)
        {
            if (attachments.Count == 0 || attachments == null || answerId == Guid.Empty) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No attachments found ...!" });

            List<AnswerAttachment> answerAttachments = new List<AnswerAttachment>();

            foreach (var attachment in attachments)
            {
                AnswerAttachment answerFiles = new AnswerAttachment();

                string savedAttachment = null;


                answerFiles.Id = Guid.NewGuid();
                answerFiles.AnswerId = answerId;
                var extension = attachment.FileName.Split('.').Last();
                answerFiles.Type = ((extension == "jpg") || (extension == "JPG") || (extension == "png") || (extension == "PNG") || (extension == "jpeg") || (extension == "JPEG") || (extension == "MOV") || (extension == "mov") || (extension == "HEIC") || (extension == "heic") || (extension == "plist") || (extension == "PLIST")) ? FileType.Image.ToString() : FileType.Link.ToString();

                if (answerFiles.Type == FileType.Link.ToString())
                {
                    savedAttachment = await Upload(attachment);
                }
                else
                {
                    savedAttachment = await ConvertAndUpload(attachment);
                }

                answerFiles.File = savedAttachment;

                answerAttachments.Add(answerFiles);

            }

            await _AnswerAttachmentRepo.AddRangeAsync(answerAttachments);

            bool succeeded = await _AnswerAttachmentRepo.SaveChangesAsync() > 0 ? true : false;

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

            if (attachment.Length == 0) throw new Exception("Error saving answer attachment ...!");

            return await _FileHandler.SaveFile(attachment, FolderName.Answers.ToString());

        }


        private async Task<string> ConvertAndUpload(IFormFile attachment)
        {
            if (attachment.Length == 0) throw new Exception("Error saving answer attachment ...!");

            return await _FileHandler.SaveImageConverter(attachment, FolderName.Answers.ToString());
        }


    }
}