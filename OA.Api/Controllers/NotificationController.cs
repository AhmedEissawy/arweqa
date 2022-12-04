using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    public class NotificationController : ApiControllersBase
    {
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        private readonly INotificationService _NotificationService;
        public NotificationController(INotificationService notificationService, IHubContext<NotificationHub, INotificationHub> notificationHub)
        {
            _NotificationService = notificationService;

            _NotificationHub = notificationHub;
        }



        [HttpPost]
        [Route("api/Notification/GetNotifications")]
        public async Task<IActionResult> GetNotifications(PaginationDto pagination)
        {
            NotificationResponseDto notificationResponse = await _NotificationService.GetNotifications(pagination);

            return Ok(notificationResponse);

        }



        [HttpPut]
        [Route("api/Notification/NotificationSeen/{notificationId}")]
        public async Task<IActionResult> NotificationSeen(Guid notificationId)
        {
            await _NotificationService.NotificationSeen(notificationId);

            return Ok();

        }



        /// <summary>
        /// For Test Only 
        /// </summary>
        [HttpGet]
        [Route("api/Notification/PushNotification")]
        public async Task<IActionResult> PushNotification()
        {
            NotificationDto notification = new NotificationDto()
            {
                Id = Guid.NewGuid(),
                StudentIdentityId = "",
                StudentName = "Student Name Test ",
                Title = " Test Notification ",
                Discription = "Discription Discription Discription",
                Date = DateTime.UtcNow.AddMinutes(120)
            };

            await _NotificationHub.Clients.All.PushNotification(notification);

            return Ok(notification);
        }


    }
}
