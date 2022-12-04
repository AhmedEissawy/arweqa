using OA.Service.Implementation.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.Infrastructure
{
    public class ActiveUserTracker
    {
        private readonly Dictionary<ActiveStudentsDto, List<string>> activeUsers = new Dictionary<ActiveStudentsDto, List<string>>();

        public Task<bool> UserConnected(ActiveStudentsDto user, string connectionId)
        {
            bool isOnline = false;
            lock (activeUsers)
            {
                var temp = activeUsers.FirstOrDefault(x => x.Key.UserId == user.UserId && x.Key.RoomId == user.RoomId);

                if (temp.Key == null)//chua co online
                {
                    activeUsers.Add(user, new List<string> { connectionId });
                    isOnline = true;
                }
                else if (activeUsers.ContainsKey(temp.Key))
                {
                    if (!activeUsers[temp.Key].Any(a => a == connectionId))
                        activeUsers[temp.Key].Add(connectionId);
                }
            }

            return Task.FromResult(isOnline);
        }

        public Task<bool> UserDisconnected(ActiveStudentsDto user, string connectionId)
        {
            bool isOffline = false;
            lock (activeUsers)
            {
                var temp = activeUsers.FirstOrDefault(x => x.Key.UserId == user.UserId && x.Key.RoomId == user.RoomId);
                if (temp.Key == null)
                    return Task.FromResult(isOffline);

                activeUsers[temp.Key].Remove(connectionId);
                if (activeUsers[temp.Key].Count == 0)
                {
                    activeUsers.Remove(temp.Key);
                    isOffline = true;
                }
            }

            return Task.FromResult(isOffline);
        }

        public Task<ActiveStudentsDto[]> GetOnlineUsers(string roomId)
        {
            ActiveStudentsDto[] onlineUsers;
            lock (activeUsers)
            {
                onlineUsers = activeUsers.Where(u => u.Key.RoomId == roomId).Select(k => k.Key).ToArray();
            }

            return Task.FromResult(onlineUsers);
        }

        public Task<List<string>> GetConnectionsForUser(ActiveStudentsDto user)
        {
            List<string> connectionIds = new List<string>();
            lock (activeUsers)
            {
                var temp = activeUsers.SingleOrDefault(x => x.Key.UserId == user.UserId && x.Key.RoomId == user.RoomId);
                if (temp.Key != null)
                {
                    connectionIds = activeUsers.GetValueOrDefault(temp.Key);
                }
            }
            return Task.FromResult(connectionIds);
        }

        public Task<List<string>> GetConnectionsForUsername(Guid username)
        {
            List<string> connectionIds = new List<string>();
            lock (activeUsers)
            {
                // 1 user co nhieu lan dang nhap
                var listTemp = activeUsers.Where(x => x.Key.UserId == username).ToList();
                if (listTemp.Count > 0)
                {
                    foreach (var user in listTemp)
                    {
                        connectionIds.AddRange(user.Value);
                    }
                }
            }
            return Task.FromResult(connectionIds);
        }

    }
}
