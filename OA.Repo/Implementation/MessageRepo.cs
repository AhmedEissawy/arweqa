using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class MessageRepo : GenericRepository<Message>, IMessageRepo
    {
        private readonly ProjectContext _dbContext;
        public MessageRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<Message>> GetMessages(Guid IdentityId)
        {

            List<Message> messages = await _dbContext.Messages.Where(q => q.SenderIdentityId == IdentityId || q.ReceiverIdentityId == IdentityId).OrderBy(q => q.Date).ToListAsync();

            return messages;
        }


        public async Task<(List<Message> message, int rowcount)> GetRecentChats(RecentChatFilterModel filterModel)
        {
            int skip = filterModel.PageSize * (filterModel.PageNo - 1);

            IQueryable<Message> messages = _dbContext.Messages.Include(q => q.SenderIdentity).Include(q => q.ReceiverIdentity).ThenInclude(q => q.Grade).Where(q => (q.IsAdmin && q.ReceiverIdentityId != Guid.Parse("F8AC7BBA-E741-4FA1-8EC2-EE6722A51749")) || (!q.IsAdmin && q.SenderIdentityId != Guid.Parse("F8AC7BBA-E741-4FA1-8EC2-EE6722A51749"))).AsQueryable();

            if (filterModel.SectionId != null && filterModel.SectionId != Guid.Empty)
            {
                messages = messages.Where(t => t.SenderIdentity.SectionId == filterModel.SectionId || t.ReceiverIdentity.SectionId == filterModel.SectionId);
            }

            if (filterModel.StageId != null && filterModel.StageId != Guid.Empty)
            {
                messages = messages.Where(t => t.SenderIdentity.Grade.StageId == filterModel.StageId || t.ReceiverIdentity.Grade.StageId == filterModel.StageId);
            }

            if (filterModel.GradeId != null && filterModel.GradeId != Guid.Empty)
            {
                messages = messages.Where(t => t.SenderIdentity.GradeId == filterModel.GradeId || t.ReceiverIdentity.GradeId == filterModel.GradeId);
            }

            if (!string.IsNullOrEmpty(filterModel.StudentName) && !string.IsNullOrWhiteSpace(filterModel.StudentName))
            {
                messages = messages.Where(t => t.SenderIdentity.UserFullName.ToLower().Contains(filterModel.StudentName.ToLower()) || t.ReceiverIdentity.UserFullName.ToLower().Contains(filterModel.StudentName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filterModel.StudentNumber) && !string.IsNullOrWhiteSpace(filterModel.StudentNumber))
            {
                messages = messages.Where(t => t.SenderIdentity.PhoneNumber.Contains(filterModel.StudentNumber) || t.ReceiverIdentity.PhoneNumber.Contains(filterModel.StudentNumber));
            }

            List<Message> Chats = await messages.ToListAsync();

            List<Message> filterChats = new List<Message>();

            foreach (Message Chat in Chats)
            {
                Message message = new Message()
                {
                    SenderName = Chat.IsAdmin ? Chat.ReceiverIdentity.UserFullName : Chat.SenderIdentity.UserFullName,
                    SenderIdentityId = Chat.IsAdmin ? Chat.ReceiverIdentityId : Chat.SenderIdentityId,
                    Description = Chat.Description,
                    Date = Chat.Date,
                    IsAdmin = Chat.IsAdmin,
                    IsTeacher = Chat.IsTeacher,
                    Attachment = Chat.Attachment,
                    IsFile = Chat.IsFile,
                    Type = Chat.Type,
                };

                filterChats.Add(message);
            }

            filterChats = filterChats.GroupBy(q => q.SenderIdentityId).Select(q => q.FirstOrDefault()).ToList();

            int rowCount = filterChats.Count();

            filterChats = filterChats.OrderByDescending(q => q.Date).Skip(skip).Take(filterModel.PageSize).ToList();

            return (filterChats, rowCount);
        }



        public async Task<List<Message>> GetStudentChatHistory(Guid studentIdentityId)
        {

            List<Message> messages = await _dbContext.Messages.Where(q => q.SenderIdentityId == studentIdentityId || q.ReceiverIdentityId == studentIdentityId).OrderBy(q => q.Date).ToListAsync();

            return messages;
        }



    }
}
