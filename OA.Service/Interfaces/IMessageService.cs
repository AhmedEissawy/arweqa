using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.MessageServices.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IMessageService
    {
        Task<NotificationDto> UserSendMessage(CreateMessageDto message);
        Task<List<MobileMessageResponseDto>> GetUserMessages();
        Task<AdminMessageResponseDto> AdminReplay(AdminReplayDto message);
        Task<(List<string>,string)> AdminGroupMessage(AdminGroupMessageDto message);
        Task<(List<RecentChatsDto> chats, int rowCount)> GetRecentChats(RecentChatFilterDto recentChatFilter);
        Task<List<AdminMessageResponseDto>> GetStudentChatHistory(string studentIdentityId);
    }
}
