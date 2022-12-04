using Microsoft.AspNetCore.SignalR;
using OA.Service.Implementation.Infrastructure.Dtos;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OA.Service.Implementation.Infrastructure
{
    public class ActiveUsersHub:Hub
    {
        private readonly ActiveUserTracker _activeUser;

        public ActiveUsersHub(ActiveUserTracker activeUser)
        {
            _activeUser = activeUser;
        }

        public override async Task OnConnectedAsync()
        {
            var isOnline = await _activeUser.UserConnected(new ActiveStudentsDto(getUserId(),getUserName()), Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var isOffline = await _activeUser.UserDisconnected(new ActiveStudentsDto(getUserId(), getUserName()), Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }


        private string getUserId() 
        {
            return Context.User.FindFirst(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        private string getUserName() 
        {
            return Context.User.FindFirst(a => a.Type == ClaimTypes.GivenName)?.Value;
        }
    }
}
