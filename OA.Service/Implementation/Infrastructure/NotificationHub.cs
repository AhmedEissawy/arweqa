using Microsoft.AspNetCore.SignalR;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.Infrastructure
{
    public class NotificationHub : Hub<INotificationHub>
    {
        //public async Task SendMessage(NotificationDto notification)
        //{
        //    await Clients.All.PushNotification(notification);
        //}
    }

}
