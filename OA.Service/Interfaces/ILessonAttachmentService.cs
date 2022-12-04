using Microsoft.AspNetCore.Http;
using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using OA.Service.Implementation.LessonServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ILessonAttachmentService
    {
        Task<bool> AddLessonAttachments(List<LessonPdfDto> files, List<LessonVideosDto> videos, Guid lessonId);
        Task<bool> EditLessonAttachments(List<LessonPdfDto> files, List<LessonVideosDto> videos, Guid lessonId);
        Task<int> DeleteLessonAttachment(Guid attachmentId);
    }
}
