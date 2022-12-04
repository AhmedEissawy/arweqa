using AutoMapper;
using Microsoft.AspNetCore.Http;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using OA.Service.Implementation.LessonServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.LessonAttachmentServices
{
    public class LessonAttachmentService : ILessonAttachmentService
    {
        private readonly IMapper _Mapper;
        private readonly IFileHandler _FileHandler;
        private readonly ILessonAttachmentRepo _lessonAttachmentRepo;
        public LessonAttachmentService(ILessonAttachmentRepo lessonAttachmentRepo, IFileHandler fileHandler, IMapper mapper)
        {
            _lessonAttachmentRepo = lessonAttachmentRepo;
            _FileHandler = fileHandler;
            _Mapper = mapper;

        }




        public async Task<bool> AddLessonAttachments(List<LessonPdfDto> lessonPdf, List<LessonVideosDto> videos, Guid lessonId)
        {
            if (videos == null && lessonPdf == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No attachments found ...!" });

            List<LessonAttachment> lessonAttachments = new List<LessonAttachment>();

            if (lessonPdf != null && lessonPdf.Count != 0)
            {
                foreach (LessonPdfDto attachment in lessonPdf)
                {
                    var extension = attachment.Pdf.FileName.Split('.').Last();

                    LessonAttachment lessonFiles = new LessonAttachment();

                    string pdf = null;
                    string image = null;

                    pdf = await Upload(attachment.Pdf);

                    image = await ConvertAndUpload(attachment.Image);

                    lessonFiles.Id = Guid.NewGuid();
                    lessonFiles.LessonId = lessonId;
                    lessonFiles.Type = ((extension == "jpg") || (extension == "JPG") || (extension == "png") || (extension == "PNG") || (extension == "jpeg") || (extension == "JPEG") || (extension == "MOV") || (extension == "mov") || (extension == "HEIC") || (extension == "heic") || (extension == "plist") || (extension == "PLIST")) ? FileType.Image.ToString() : FileType.Link.ToString();
                    lessonFiles.Title = attachment.Title;
                    lessonFiles.File = pdf;
                    lessonFiles.FileImage = image;
                    lessonFiles.ContentTypeFor = ContentTypeFor.Egabat.ToString();

                    lessonAttachments.Add(lessonFiles);
                }
            }

            if (videos != null && videos.Count != 0)
            {

                foreach (LessonVideosDto attachment in videos)
                {
                    LessonAttachment lessonFiles = new LessonAttachment();

                    lessonFiles.Id = Guid.NewGuid();
                    lessonFiles.LessonId = lessonId;
                    lessonFiles.Title = attachment.Title;
                    lessonFiles.Type = FileType.VideoLink.ToString();
                    lessonFiles.File = attachment.VideoLink;
                    lessonFiles.ContentTypeFor = attachment.ContentTypeFor;

                    lessonAttachments.Add(lessonFiles);
                }
            }

            await _lessonAttachmentRepo.AddRangeAsync(lessonAttachments);


            bool succeeded = await _lessonAttachmentRepo.SaveChangesAsync() > 0 ? true : false;

            if (succeeded)
            {
                return true;
            }

            else
            {
                throw new Exception("Error saving The data ...!");
            }

        }





        public async Task<bool> EditLessonAttachments(List<LessonPdfDto> lessonPdf, List<LessonVideosDto> videos, Guid lessonId)
        {
            List<LessonAttachment> lessonAttachments = new List<LessonAttachment>();

            //if (lessonPdf != null && lessonPdf.Count != 0)
            //{
            //    foreach (LessonPdfDto attachment in lessonPdf)
            //    {
            //        var extension = attachment.Pdf.FileName.Split('.').Last();

            //        LessonAttachment lessonFiles = new LessonAttachment();

            //        string pdf = null;
            //        string image = null;

            //        pdf = await Upload(attachment.Pdf);

            //        image = await ConvertAndUpload(attachment.Image);

            //        lessonFiles.Id = Guid.NewGuid();
            //        lessonFiles.LessonId = lessonId;
            //        lessonFiles.Type = ((extension == "jpg") || (extension == "JPG") || (extension == "png") || (extension == "PNG") || (extension == "jpeg") || (extension == "JPEG") || (extension == "MOV") || (extension == "mov") || (extension == "HEIC") || (extension == "heic") || (extension == "plist") || (extension == "PLIST")) ? FileType.Image.ToString() : FileType.Link.ToString();
            //        lessonFiles.Title = attachment.Title;
            //        lessonFiles.File = pdf;
            //        lessonFiles.FileImage = image;
            //        lessonFiles.ContentTypeFor = ContentTypeFor.Egabat.ToString();

            //        lessonAttachments.Add(lessonFiles);
            //    }
            //}

            List<LessonAttachment> oldLessonAttachments = (await _lessonAttachmentRepo.FindAsync(q => q.LessonId == lessonId && q.Type == FileType.VideoLink.ToString())).ToList();

            _lessonAttachmentRepo.RemoveRange(oldLessonAttachments);

            if (videos != null && videos.Count != 0)
            {

                foreach (LessonVideosDto attachment in videos)
                {
                    LessonAttachment lessonFiles = new LessonAttachment();

                    lessonFiles.Id = Guid.NewGuid();
                    lessonFiles.LessonId = lessonId;
                    lessonFiles.Title = attachment.Title;
                    lessonFiles.Type = FileType.VideoLink.ToString();
                    lessonFiles.File = attachment.VideoLink;
                    lessonFiles.ContentTypeFor = attachment.ContentTypeFor;

                    lessonAttachments.Add(lessonFiles);
                }
            }

            bool succeeded = true;

            if (lessonAttachments != null && lessonAttachments.Count() != 0)
            {
                await _lessonAttachmentRepo.AddRangeAsync(lessonAttachments);

                succeeded = await _lessonAttachmentRepo.SaveChangesAsync() > 0 ? true : false;
            }



            if (succeeded)
            {
                return true;
            }

            else
            {
                throw new Exception("Error saving The data ...!");
            }

        }



        public async Task<int> DeleteLessonAttachment(Guid attachmentId)
        {
            LessonAttachment lessonAttachment = (await _lessonAttachmentRepo.FindAsync(q => q.Id == attachmentId)).FirstOrDefault();

            if (lessonAttachment == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The lessonAttachment with id = {attachmentId} not found ...!" });

            if (!string.IsNullOrEmpty(lessonAttachment.FileImage) && !string.IsNullOrWhiteSpace(lessonAttachment.FileImage) && lessonAttachment.FileImage != ImageAvatar.PDFAvatar)
            {
                bool pdfDeleted = _FileHandler.DeleteFile(lessonAttachment.FileImage, FolderName.Lessons.ToString());
            }

            if (!string.IsNullOrEmpty(lessonAttachment.File) && !string.IsNullOrWhiteSpace(lessonAttachment.File))
            {
                bool imageDeleted = _FileHandler.DeleteFile(lessonAttachment.File, FolderName.Lessons.ToString());
            }

            _lessonAttachmentRepo.Remove(lessonAttachment);

            int result = 0;

            try
            {
                result = await _lessonAttachmentRepo.SaveChangesAsync();
            }
            catch (Exception)
            {
                return result;
            }

            return result;
        }




        private async Task<string> Upload(IFormFile attachment)
        {
            _FileHandler.ValiadteFile(attachment);

            if (attachment.Length == 0) throw new Exception("Error saving lesson attachment ...!");

            return await _FileHandler.SaveFile(attachment, FolderName.Lessons.ToString());
        }



        private async Task<string> ConvertAndUpload(IFormFile attachment)
        {
            if (attachment.Length == 0) throw new Exception("Error saving answer attachment ...!");

            return await _FileHandler.SaveImageConverter(attachment, FolderName.Lessons.ToString());
        }

    }
}
