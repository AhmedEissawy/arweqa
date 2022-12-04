using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.LessonAttachmentServices.Dtos;
using OA.Service.Implementation.LessonServices.Dtos;
using OA.Service.Implementation.UnitServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.LessonServices
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepo _lessonRepo;
        private readonly IMapper _Mapper;
        private readonly IFileHandler _fileHandler;
        private readonly ILessonAttachmentRepo _lessonAttachmentRepo;
        private readonly ILessonLiveVideoRepo _liveVideoRepo;

        public LessonService(ILessonRepo lessonRepo, IMapper mapper, IFileHandler fileHandler, ILessonAttachmentRepo lessonAttachmentRepo,ILessonLiveVideoRepo liveVideoRepo)
        {
            _lessonAttachmentRepo = lessonAttachmentRepo;
            _liveVideoRepo = liveVideoRepo;
            _lessonRepo = lessonRepo;
            _fileHandler = fileHandler;
            _Mapper = mapper;
        }



        public async Task<List<LessonResponseDto>> GetUnitLessonsForAdmin(Guid unitId)
        {
            List<Lesson> Lessons = await _lessonRepo.GetLessonsAdmin(unitId);

            return _Mapper.Map<List<LessonResponseDto>>(Lessons);
        }



        public async Task<LessonDetailsDto> GetLessonDetailsForAdmin(Guid lessonId)
        {
            LessonDetailsDto lessonDetails = new LessonDetailsDto();
            lessonDetails.LessonAttachments = new LessonAttachmentResponseDto();
            lessonDetails.LessonAttachments.Files = new List<LessonFilesDto>();
            lessonDetails.LessonAttachments.Videos = new List<LessonVideosDto>();
            lessonDetails.LessonAttachments.Rooms = new List<LessonVideoRoomDto>();

            Lesson dbLesson = await _lessonRepo.GetLessonDetailsForAdmin(lessonId);

            if (dbLesson == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Lesson with id = {lessonId} not found ...!" });

            lessonDetails.Lesson = _Mapper.Map<LessonResponseDto>(dbLesson);

            foreach (var attachment in dbLesson.LessonAttachments)
            {
                if (attachment.Type == FileType.VideoLink.ToString())
                {
                    LessonVideosDto video = new LessonVideosDto()
                    {
                        Title = attachment.Title,
                        VideoLink = attachment.File,
                        ContentTypeFor = attachment.ContentTypeFor
                    };

                    lessonDetails.LessonAttachments.Videos.Add(video);

                }
                else
                {
                    LessonFilesDto lessonFile = new LessonFilesDto()
                    {
                        FileId = attachment.Id,
                        Name = attachment.Title,
                        Type = attachment.Type,
                        File = attachment.File,
                        FileImage = attachment.FileImage
                    };
                    lessonDetails.LessonAttachments.Files.Add(lessonFile);
                }

            }

            foreach (var item in dbLesson.Rooms)
            {
                lessonDetails.LessonAttachments.Rooms.Add(new LessonVideoRoomDto { LiveDate = item.LiveDate.ToShortDateString() });

            }

            return lessonDetails;
        }


        public async Task<IEnumerable<MobileUnitLessonResponseDto>> GetSubjectUnitsLessonsForStudent(Guid subjectId)
        {
            List<Lesson> lessons = await _lessonRepo.GetSubjectUnitsForStudent(subjectId);

            IEnumerable<MobileUnitLessonResponseDto> groupedLessonsByUnit = lessons.OrderBy(q => q.Unit.Index).GroupBy(q => q.Unit.UnitName).Select(u => new MobileUnitLessonResponseDto()
            {
                UnitName = u.Key,

                Lessons = u.OrderByDescending(a=>a.Index).Select(l => new MobileLessonResponseDto()
                {
                    LessonId = l.Id,
                    LessonName = l.LessonName
                    
                }).ToList()

            });

            return groupedLessonsByUnit;
        }


        public async Task<List<MobileLessonFilesDto>> GetLessonFilesForStudent(Guid lessonId)
        {
            List<MobileLessonFilesDto> lessonFiles = new List<MobileLessonFilesDto>();

            Lesson dbLesson = await _lessonRepo.GetLessonDetailsForStudent(lessonId);

            if (dbLesson == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Lesson with id = {lessonId} not found ...!" });

            foreach (var attachment in dbLesson.LessonAttachments)
            {
                if (attachment.Type != FileType.VideoLink.ToString())
                {
                    MobileLessonFilesDto lessonFile = new MobileLessonFilesDto()
                    {
                        Type = attachment.Type,
                        Title = attachment.Title,
                        File = attachment.File,
                        FileImage = attachment.FileImage == null ? ImageAvatar.PDFAvatar : attachment.FileImage
                    };
                    lessonFiles.Add(lessonFile);
                }

            }

            return lessonFiles;
        }


        public async Task<GetLessonVideosDto> GetLessonVideosForStudent(Guid lessonId)
        {
            List<LessonVideosDto> lessonVideos = new List<LessonVideosDto>();

            var data = new GetLessonVideosDto();
           

            Lesson dbLesson = await _lessonRepo.GetLessonDetailsForStudent(lessonId);

            if (dbLesson == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Lesson with id = {lessonId} not found ...!" });

            foreach (var attachment in dbLesson.LessonAttachments)
            {
                if (attachment.Type == FileType.VideoLink.ToString())
                {
                    LessonVideosDto video = new LessonVideosDto()
                    {
                        Title = attachment.Title,
                        VideoLink = attachment.File,
                        ContentTypeFor = attachment.ContentTypeFor
                    };

                    lessonVideos.Add(video);
                }
            }
            data.LiveVideos = dbLesson.Rooms.Select(a => new LessonVideoRoomDto { LiveDate = a.LiveDate.ToString() }).ToList();
            data.Videos = lessonVideos;

            return data;
        }


        public async Task<(LessonResponseDto, Guid)> AddLesson(CreateLessonDto lesson)
        {
            if (string.IsNullOrEmpty(lesson.LessonName) || lesson.UnitId == Guid.Empty) throw new RestException(HttpStatusCode.BadRequest, new { message = $" Missing Data ...!" });

            Lesson newLesson = _Mapper.Map<Lesson>(lesson);

            newLesson.Id = Guid.NewGuid();
            foreach (var item in newLesson.Rooms)
            {
                item.RoomId=RandomString(6);
            }

            await _lessonRepo.AddAsync(newLesson);

            return (await _lessonRepo.SaveChangesAsync() > 0 ? _Mapper.Map<LessonResponseDto>(newLesson) : throw new Exception("Error saving The data ...!"), newLesson.Id);
        }


        public async Task<(LessonResponseDto, Guid)> EditLesson(EditLessonDto lesson)
        {
            if (string.IsNullOrEmpty(lesson.LessonName) || lesson.UnitId == Guid.Empty) throw new RestException(HttpStatusCode.BadRequest, new { message = $" Missing Data ...!" });

            Lesson oldLesson = await _lessonRepo.GetLessonDetailsForAdmin(lesson.LessonId);

            if (oldLesson == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Lesson with id = {lesson.LessonId} not found ...!" });

            if (lesson.Rooms != null)
            {
                _liveVideoRepo.RemoveRange(oldLesson.Rooms);
               
                foreach (var item in lesson.Rooms)
                {
                    oldLesson.Rooms.Add(new LessonVideoRoom { LiveDate = DateTime.Parse(item.LiveDate), RoomId = RandomString(6) });
                }
                await _liveVideoRepo.SaveChangesAsync();
            }
            oldLesson.Index = lesson.Index;
            oldLesson.LessonName = lesson.LessonName;
            oldLesson.UnitId = lesson.UnitId;
         
            
            await _lessonRepo.SaveChangesAsync();

            return (_Mapper.Map<LessonResponseDto>(oldLesson) , oldLesson.Id);
        }


        public async Task<(object, int)> DeleteLesson(Guid lessonId)
        {
            Lesson oldLesson = await _lessonRepo.GetLessonDetailsForAdmin(lessonId);

            if (oldLesson == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Lesson with id = {lessonId} not found ...!" });

            if (oldLesson.LessonAttachments != null && oldLesson.LessonAttachments.Count != 0)
            {
                foreach (LessonAttachment attachment in oldLesson.LessonAttachments)
                {
                    if (!(string.IsNullOrEmpty(attachment.File)) || !(string.IsNullOrWhiteSpace(attachment.File)) && attachment.Type != FileType.VideoLink.ToString())
                    {
                        bool pdfDeleted = _fileHandler.DeleteFile(attachment.File, FolderName.Lessons.ToString());
                    }
                    if (!(string.IsNullOrEmpty(attachment.FileImage)) || !(string.IsNullOrWhiteSpace(attachment.FileImage)) && attachment.Type != FileType.VideoLink.ToString() && attachment.FileImage != ImageAvatar.PDFAvatar)
                    {
                        bool imageDeleted = _fileHandler.DeleteFile(attachment.FileImage, FolderName.Lessons.ToString());
                    }
                }
            }


            _lessonAttachmentRepo.RemoveRange(oldLesson.LessonAttachments);
            _lessonRepo.Remove(oldLesson);

            var result = 0;

            try
            {
                result = await _lessonRepo.SaveChangesAsync();
            }
            catch (Exception)
            {
                return (new { message = "Error Removing Lesson !!!" }, result);
            }

            return ("", result);
        }



        public async Task<ActivationDto> LessonActivation(Guid lessonId)
        {
            Lesson dbLesson = (await _lessonRepo.FindAsync(q => q.Id == lessonId)).FirstOrDefault();

            if (dbLesson == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Lesson with id = {lessonId} not found ...!" });

            if (dbLesson.IsActive == true)
            {
                dbLesson.IsActive = false;
                await _lessonRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbLesson.IsActive = true;

            await _lessonRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
