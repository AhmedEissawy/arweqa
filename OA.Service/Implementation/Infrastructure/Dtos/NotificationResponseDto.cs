using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.Infrastructure.Dtos
{
    public class NotificationResponseDto
    {
        public int TotalCount { get; set; }
       
        public int NotSeenCount { get; set; }

        public List<NotificationDto> NotificationDetails { get; set; }
 
    }
}



