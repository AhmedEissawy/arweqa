using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.MessageServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    public class MessageController : ApiControllersBase
    {
        private readonly IMessageService _MessageService;
        private readonly INotificationService _NotificationService;
        private readonly IHubContext<NotificationHub, INotificationHub> _NotificationHub;
        public MessageController(IMessageService messageService, INotificationService notificationService, IHubContext<NotificationHub, INotificationHub> notificationHub)
        {
            _MessageService = messageService;

            _NotificationService = notificationService;

            _NotificationHub = notificationHub;

        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Message/SendNotification/{deviceToken}")]
        public IActionResult SendNotification(string deviceToken)
        {
            _NotificationService.SendNotification(deviceToken, "Hello :) ", "Test Notification", Guid.Empty);

            return Ok();
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpPost]
        [Route("api/Message/SaveDeviceToken")]
        public async Task<IActionResult> SaveDeviceToken(SaveTokenDto deviceToken)
        {
            await _NotificationService.SaveDeviceToken(deviceToken);
            return Ok();
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Message/AdminReplay")]
        public async Task<IActionResult> AdminReplay([FromForm] AdminReplayDto replay)
        {
            if (User.IsInRole("الدعم الفني") || User.IsInRole("SuperAdmin"))
            {
                AdminMessageResponseDto CreatedMessage = await _MessageService.AdminReplay(replay);

                _NotificationService.SendNotification(await _NotificationService.GetDeviceToken(replay.ReceiverIdentityId), "رساله من الدعم الفني", replay.Message, Guid.Empty);

                return Ok(CreatedMessage);
            }
            else
            {
                return Unauthorized();
            }


        }

        [HttpPost("api/Message/SendGroupMessage")]
        public async Task<IActionResult> SendGroupMessage([FromForm]AdminGroupMessageDto messageDto)
        {
            if (User.IsInRole("الدعم الفني") || User.IsInRole("SuperAdmin"))
            {
               var tokens = await _MessageService.AdminGroupMessage(messageDto);

                foreach (var token in tokens.Item1)
                {
                    _NotificationService.SendNotification(token, "رساله من الدعم الفني", tokens.Item2, Guid.Empty);
                }

                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpPost]
        [Route("api/Message/GetRecentChats")]
        public async Task<IActionResult> GetRecentChats(RecentChatFilterDto recentChatFilter)
        {
            if (User.IsInRole("SuperAdmin") || User.IsInRole("الدعم الفني"))
            {
                (List<RecentChatsDto> chats, int rowCount) = await _MessageService.GetRecentChats(recentChatFilter);
                return Ok(new { Chats = chats, RowCount = rowCount });
            }
            else
            {
                return Unauthorized();
            }

        }



        /// <summary>
        /// Web
        /// </summary>
        [HttpGet]
        [Route("api/Message/GetStudentChatHistory/{studentIdentityId}")]
        public async Task<IActionResult> GetStudentChatHistory(string studentIdentityId)
        {
            if (User.IsInRole("الدعم الفني") || User.IsInRole("SuperAdmin"))
            {
                List<AdminMessageResponseDto> messages = await _MessageService.GetStudentChatHistory(studentIdentityId);

                return Ok(messages);
            }
            else
            {
                return Unauthorized();
            }

        }




        /// <summary>
        /// Mobile
        /// </summary>
        [HttpPost]
        [Route("api/Message/UserSendMessage")]
        public async Task<IActionResult> UserSendMessage(CreateMessageDto newMessage)
        {
            NotificationDto notification = await _MessageService.UserSendMessage(newMessage);


            await _NotificationHub.Clients.All.PushNotification(notification);

            return Ok();
        }




        /// <summary>
        /// Mobile
        /// </summary>
        [HttpGet]
        [Route("api/Message/GetUserMessages")]
        public async Task<IActionResult> GetUserMessages()
        {
            List<MobileMessageResponseDto> messages = await _MessageService.GetUserMessages();
            

            return Ok(messages);
        }



      
    }
}
