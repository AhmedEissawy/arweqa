using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Enums;
using OA.Repo.Helpers;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.MessageServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Service.Implementation.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly IFileHandler _FileHandler;
        private readonly IMapper _Mapper;
        private readonly IUserRepo _UserRepo;
        private readonly IMessageRepo _MessageRepo;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly INotificationRepo _NotificationRepo;
        private readonly IStudentRepo _StudentRepo;
        private readonly ITeacherRepo _TeacherRepo;
        public MessageService(UserManager<ApplicationUser> userManager, IMapper mapper, IUserRepo userRepo, IMessageRepo messageRepo, IStudentRepo studentRepo, ITeacherRepo teacherRepo, INotificationRepo notificationRepo, IFileHandler fileHandler)
        {
            _Mapper = mapper;
            _UserRepo = userRepo;
            _MessageRepo = messageRepo;
            _UserManager = userManager;
            _StudentRepo = studentRepo;
            _TeacherRepo = teacherRepo;
            _NotificationRepo = notificationRepo;
            _FileHandler = fileHandler;
        }



        public async Task<NotificationDto> UserSendMessage(CreateMessageDto message)
        {
            string userId = _UserRepo.GetUserClaims().Id;

            string senderName = "الدعم الفني";

            ApplicationUser user = await _UserRepo.FindByIdAsync(Guid.Parse(userId));

            ApplicationUser admin = await _UserRepo.FindChatAdmin();

            Message newMessage = _Mapper.Map<Message>(message);

            if (message.IsTeacher)
            {
                ApplicationUser teacher = await _UserManager.FindByIdAsync(userId);

                if (teacher != null)
                {
                    senderName = teacher.UserFullName;
                }
            }

            if (user.UserType != UserType.Teacher.ToString() && user.UserType != UserType.Admin.ToString())
            {
                if (user != null)
                {
                    senderName = user.UserFullName;
                }
            }

            newMessage.Id = Guid.NewGuid();
            newMessage.SenderIdentityId = Guid.Parse(userId);
            newMessage.SenderName = senderName;
            newMessage.ReceiverIdentityId = admin.Id;
            newMessage.Date = Helper.kuwaitTimeNow();

            await _MessageRepo.AddAsync(newMessage);

            Notification notification = new Notification()
            {
                Id = Guid.NewGuid(),
                StudentIdentityId = newMessage.SenderIdentityId,
                StudentName = newMessage.SenderName,
                Title = "رساله من طالب",
                Discription = message.Message,
                Date = Helper.kuwaitTimeNow()
            };

            await _NotificationRepo.AddAsync(notification);

            return await _MessageRepo.SaveChangesAsync() > 0 ? _Mapper.Map<NotificationDto>(notification) : throw new Exception("Error saving The data ...!");

        }



        public async Task<AdminMessageResponseDto> AdminReplay(AdminReplayDto message)
        {
            string userId = _UserRepo.GetUserClaims().Id;

            Message newMessage = _Mapper.Map<Message>(message);

            newMessage.Id = Guid.NewGuid();
            newMessage.SenderIdentityId = Guid.Parse(userId);
            newMessage.SenderName = "الدعم الفني";
            newMessage.ReceiverIdentityId = message.ReceiverIdentityId;
            newMessage.Date = Helper.kuwaitTimeNow();
            newMessage.IsTeacher = false;
            newMessage.IsAdmin = true;

            if (message.Attachment != null && message.Attachment.Length != 0)
            {
                string savedAttachment = await Upload(message.Attachment, "Messages");
                newMessage.Attachment = savedAttachment;
                newMessage.Type = message.Attachment.ContentType.StartsWith("image") ? "Image" : "Link";
                newMessage.IsFile = true;
            }
            else
            {
                newMessage.Attachment = "لايوجد مرفقات";
                newMessage.Type = "Text";
                newMessage.IsFile = false;
            }

            await _MessageRepo.AddAsync(newMessage);

            int result = await _MessageRepo.SaveChangesAsync();

            if (result != 0)
            {
                return _Mapper.Map<AdminMessageResponseDto>(newMessage);
            }
            else
            {
                throw new Exception("Error saving The data ...!");
            }

        }



        public async Task<(List<RecentChatsDto> chats, int rowCount)> GetRecentChats(RecentChatFilterDto recentChatFilter)
        {
            string userId = _UserRepo.GetUserClaims().Id;

            ApplicationUser user = await _UserRepo.FindByIdAsync(Guid.Parse(userId));

            RecentChatFilterModel filterModel = _Mapper.Map<RecentChatFilterModel>(recentChatFilter);

            if (!(await _UserManager.IsInRoleAsync(user, "SuperAdmin")))
            {
                filterModel.SectionId = user.SectionId.Value;
            }

            (List<Message> chats, int rowCount) = await _MessageRepo.GetRecentChats(filterModel);

            return (_Mapper.Map<List<RecentChatsDto>>(chats), rowCount);
        }



        public async Task<List<AdminMessageResponseDto>> GetStudentChatHistory(string studentIdentityId)
        {
            List<Message> chatHistory = await _MessageRepo.GetStudentChatHistory(Guid.Parse(studentIdentityId));

            return _Mapper.Map<List<AdminMessageResponseDto>>(chatHistory);
        }




        public async Task<List<MobileMessageResponseDto>> GetUserMessages()
        {
            string userId = _UserRepo.GetUserClaims().Id;

            List<Message> messages = await _MessageRepo.GetMessages(Guid.Parse(userId));

            return _Mapper.Map<List<MobileMessageResponseDto>>(messages);
        }


        public async Task<List<AdminMessageResponseDto>> GetAdminMessages()
        {
            string userId = _UserRepo.GetUserClaims().Id;

            List<Message> messages = await _MessageRepo.GetMessages(Guid.Parse(userId));

            return _Mapper.Map<List<AdminMessageResponseDto>>(messages);
        }


        private async Task<string> Upload(IFormFile attachment, string folderName)
        {
            _FileHandler.ValiadteFile(attachment);

            if (attachment.Length == 0) throw new Exception("Error saving attachment ...!");

            return await _FileHandler.SaveFile(attachment, folderName);

        }

        public async Task<(List<string>,string)> AdminGroupMessage(AdminGroupMessageDto message)
        {

            Guid? grade= null, stage = null, section = null;

            if ( !string.IsNullOrEmpty(message.GradeId)&& message.GradeId !="null")
                grade = Guid.Parse(message.GradeId);

            if (!string.IsNullOrEmpty(message.SectionId )&&message.SectionId!="null")
                section = Guid.Parse(message.SectionId);

            if (!string.IsNullOrEmpty(message.StageId) && message.StageId != "null") 
                stage = Guid.Parse(message.StageId);
            var Students = await _StudentRepo.GetStudentsForGroup(new FilterDto
            {
                GradeId=grade,
                StageId=stage,
                SectionId=section,
                IsActive=message.IsActive
               
            });

            if (Students is null || !Students.Any())
                return (null, "");
            string savedAttachment = "";
            if (message.Attachment != null && message.Attachment.Length != 0)
            {
                 savedAttachment = await Upload(message.Attachment, "Messages");
               
            }

            string userId = _UserRepo.GetUserClaims().Id;

            foreach (var item in Students)
            {
                var newMessage = new Message() { SenderIdentityId = Guid.Parse(userId), ReceiverIdentityId = item.Id, SenderName = "الدعم الفني" };
              
                newMessage.Date = Helper.kuwaitTimeNow();
                newMessage.IsTeacher = false;
                newMessage.IsAdmin = true;
                newMessage.Description = message.Message;
                
                if (message.Attachment != null && message.Attachment.Length != 0)
                {
                    newMessage.Attachment = savedAttachment;
                    newMessage.Type = message.Attachment.ContentType.StartsWith("image") ? "Image" : "Link";
                    newMessage.IsFile = true;
                }
                else
                {
                    newMessage.Attachment = "لايوجد مرفقات";
                    newMessage.Type = "Text";
                    newMessage.IsFile = false;
                }

               await _MessageRepo.AddAsync(newMessage);
            }
            await _MessageRepo.SaveChangesAsync();

            return(Students.Select(a=>a.User.DeviceToken).ToList(),message.Message);


        }
    }

}
