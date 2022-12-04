using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IMessageRepo : IGenericRepository<Message>
    {
        Task<List<Message>> GetMessages(Guid IdentityId);
        Task<(List<Message> message, int rowcount)> GetRecentChats(RecentChatFilterModel filterModel);
        Task<List<Message>> GetStudentChatHistory(Guid studentIdentityId);
       
    }
}
