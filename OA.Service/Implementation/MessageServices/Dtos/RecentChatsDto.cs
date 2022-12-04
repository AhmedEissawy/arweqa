using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.MessageServices.Dtos
{
    public class RecentChatsDto
    {
        public string SenderName { get; set; }

        public string SenderIdentityId { get; set; }

        public DateTime Date { get; set; }

    }
}
