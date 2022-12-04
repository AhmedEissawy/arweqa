
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.MessageServices.Dtos;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _Mapper;
        private IHostingEnvironment _env;
        public string result;
        private readonly IUserRepo _UserRepo;
        private readonly INotificationRepo _NotificationRepo;
        public NotificationService(IUserRepo userRepo, IHostingEnvironment env, INotificationRepo notificationRepo, IMapper mapper)
        {
            _UserRepo = userRepo;
            _env = env;
            _NotificationRepo = notificationRepo;
            _Mapper = mapper;
        }



        public async Task SaveDeviceToken(SaveTokenDto deviceToken)
        {
            if (string.IsNullOrEmpty(deviceToken.DeviceToken) || string.IsNullOrWhiteSpace(deviceToken.DeviceToken))
            {
                throw new RestException(HttpStatusCode.BadRequest, new { message = $" No Device Token found ...!" });
            }

            string userId = _UserRepo.GetUserClaims().Id;

            ApplicationUser user = await _UserRepo.FindByIdAsync(Guid.Parse(userId));

            if (user == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The user with id = {userId} not found ...!" });

            user.DeviceToken = deviceToken.DeviceToken;

            await _UserRepo.SaveChangesAsync();

        }


        public async Task RemoveDeviceToken()
        {
            string userId = _UserRepo.GetUserClaims().Id;

            ApplicationUser user = await _UserRepo.FindByIdAsync(Guid.Parse(userId));

            if (user == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The user with id = {userId} not found ...!" });

            user.DeviceToken = null;

            await _UserRepo.SaveChangesAsync();

        }




        public async Task<NotificationResponseDto> GetNotifications(PaginationDto pagination)
        {
            var notificationData = await _NotificationRepo.GetNotifications(pagination.PageSize, pagination.PageNo);

            NotificationResponseDto notificationResponse = new NotificationResponseDto();

            notificationResponse.NotificationDetails = _Mapper.Map<List<NotificationDto>>(notificationData.Item1);

            notificationResponse.TotalCount = notificationData.totalCount;
            notificationResponse.NotSeenCount = notificationData.notSeenCount;

            return notificationResponse;

        }


        public async Task NotificationSeen(Guid notificationId)
        {
            Data.Domain.Notification notification = (await _NotificationRepo.FindAsync(q => q.Id == notificationId)).FirstOrDefault();

            if (notification != null)
            {
                if (!notification.Seen)
                {
                    notification.Seen = true;
                    await _NotificationRepo.SaveChangesAsync();
                }
            }

        }



        public async Task<string> GetDeviceToken(Guid userId)
        {
            string deviceToken = await _UserRepo.GetDeviceToken(userId);

            if (deviceToken == null)
            {
                deviceToken = " No DeviceToken ...!";


            }
            //throw new RestException(System.Net.HttpStatusCode.BadRequest, new { Message = $" Device Token Not exist!" });

            return deviceToken;

        }



        public void SendNotification(string DeviceToken, string Title, string Message, Guid requestId)
        {

            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            //serverKey - Key from Firebase cloud messaging server  
            tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAJABXd-g:APA91bFBwlL1QEwh8QEdycxgxjDrql-Rr_LAwOE9sNqTV-d5BzpyXV_mr4lqnHifa6USePGHFZZqy4d40GJyVqFB3tMvYdQxquOmA6KGzsYF6Hw_PwmbrPRpvxXxLo2fekKj-xfgeqnG"));
            //Sender Id - From firebase project setting  
            // tRequest.Headers.Add(string.Format("Sender: id={0}", "154624554984"));
            tRequest.ContentType = "application/json";

            var requestvalue = "chat";

            if (requestId != Guid.Empty)
            {
                requestvalue = requestId.ToString();
            }


            var payload = new

            {

                to = DeviceToken,
                priority = "high",
                content_available = true,

                notification = new
                {
                    body = Message,
                    title = Title,
                    badge = 1,

                    sound = "notification"

                },

                data = new
                {
                    request = requestvalue
                }
            };

            string postbody = JsonConvert.SerializeObject(payload).ToString();
            Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        if (dataStreamResponse != null)
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                //result.Response = sResponseFromServer;
                            }

                        }

                    }
                }
            }

        }



    }
}
