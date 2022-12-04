using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using OA.Service.Implementation.LessonServices.Dtos;
using OA.Service.Implementation.UnitServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ILessonService
    {
        Task<List<LessonResponseDto>> GetUnitLessonsForAdmin(Guid unitId);
        Task<LessonDetailsDto> GetLessonDetailsForAdmin(Guid lessonId);
        Task<(LessonResponseDto, Guid)> AddLesson(CreateLessonDto lesson);
        Task<(LessonResponseDto, Guid)> EditLesson(EditLessonDto lesson);
        Task<(object, int)> DeleteLesson(Guid lessonId);
        Task<ActivationDto> LessonActivation(Guid lessonId);
        Task<List<MobileLessonFilesDto>> GetLessonFilesForStudent(Guid lessonId);
        Task<GetLessonVideosDto> GetLessonVideosForStudent(Guid lessonId);
        Task<IEnumerable<MobileUnitLessonResponseDto>> GetSubjectUnitsLessonsForStudent(Guid subjectId);
    }
}
