using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.MessageServices.Dtos;
using System;
using System.Threading.Tasks;

namespace OA.Service.Interfaces.Infrastructure
{
    public interface INotificationService
    {
        void SendNotification(string DeviceToken, string Title, string Message, Guid requestId);
        Task<string> GetDeviceToken(Guid userId);
        Task<NotificationResponseDto> GetNotifications(PaginationDto pagination);
        Task NotificationSeen(Guid notificationId);
        Task SaveDeviceToken(SaveTokenDto deviceToken);
        Task RemoveDeviceToken();

    }
}
