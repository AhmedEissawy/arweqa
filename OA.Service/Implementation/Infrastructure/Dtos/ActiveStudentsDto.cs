using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.Infrastructure.Dtos
{
    public class ActiveStudentsDto
    {
        public ActiveStudentsDto()
        {

        }

        public ActiveStudentsDto(string userId,string UserName)
        {
            UserId = Guid.Parse(userId);
            StudentName = UserName;
        }
        public Guid UserId { get; set; }
        public string StudentName { get; set; }
        public string RoomId { get; set; }
    }
}
