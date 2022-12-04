using Microsoft.AspNetCore.SignalR;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.Service.Implementation.Infrastructure
{
    public class LiveChatHub:Hub
    {
        private readonly ILessonLiveVideoRepo _lessonLiveVideoRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILessonLiveConnectionsRepo _connectionsRepo;
        private readonly ActiveUserTracker _activeUser;
        private readonly IHubContext<ActiveUsersHub> _activeHub;

        public LiveChatHub(
            ILessonLiveVideoRepo lessonLiveVideoRepo , 
            IUserRepo userRepo, 
            ILessonLiveConnectionsRepo connectionsRepo,ActiveUserTracker activeUser ,IHubContext<ActiveUsersHub> activeHub) 
        {
           _lessonLiveVideoRepo = lessonLiveVideoRepo;
          _userRepo = userRepo;
            _connectionsRepo = connectionsRepo;
            _activeUser = activeUser;
            _activeHub = activeHub;
        }
        public override async Task OnConnectedAsync()
        {
            await ConnectToRoom();

            await base.OnConnectedAsync();
        }

        private async Task ConnectToRoom()
        {
            var httpContext = Context.GetHttpContext();

            var roomId = httpContext.Request.Query.GetQueryParameterValue<string>("roomId");

            var room = await _lessonLiveVideoRepo.GetRoomByCode(roomId);




            var userId = Context.User?.FindFirst(a => a.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _userRepo.FindByIdAsync(Guid.Parse(userId));

           await _activeUser.UserConnected(new Dtos.ActiveStudentsDto(userId,user.UserFullName), Context.ConnectionId);

            var sectionOk = room.Lesson.Unit.Subject.SubjectSections.Any(a=>a.SectionId==user.SectionId);
            var gradeOk = room.Lesson.Unit.Subject.GradeId == user.GradeId;


            if (sectionOk && gradeOk)
            {
                await _lessonLiveVideoRepo.SaveChangesAsync();

                await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
                await AddConnectionToRoom(room, user.UserFullName, Context.ConnectionId);
            }
            else httpContext.Request.HttpContext.Response.StatusCode = 403;
        }

        private async Task AddConnectionToRoom(LessonVideoRoom room,string userName,string connectionId) 
        {
            room.Connections.Add(new LessonVideoRoomConnections(connectionId, userName));
            room.Attenendence += 1;
            await _lessonLiveVideoRepo.SaveChangesAsync();
           
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {

            var httpContext = Context.GetHttpContext();

            //  var roomId = httpContext.Request.Query.GetQueryParameterValue<string>("roomId");

            var room = await _lessonLiveVideoRepo.GetRoomByConnectionId(Context.ConnectionId);
            room.Attenendence -= 1;

            await _activeUser.UserDisconnected(new Dtos.ActiveStudentsDto(Context.User.FindFirst(a => a.Type == ClaimTypes.NameIdentifier)?.Value, "") { RoomId = room.RoomId },Context.ConnectionId);

            var connection = await _connectionsRepo.FindAsync(a => a.Connection_Id == Context.ConnectionId);

            _connectionsRepo.Remove(connection.FirstOrDefault());

            await _connectionsRepo.SaveChangesAsync();
            await _lessonLiveVideoRepo.SaveChangesAsync();

            
        }
    }
}
