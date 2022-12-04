using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.Infrastructure.Dtos
{
    public class NotificationDto
    {
        public Guid Id { get; set; }

        public string StudentIdentityId { get; set; }

        public string StudentName { get; set; }

        public string Title { get; set; }

        public string Discription { get; set; }

        public bool Seen { get; set; }

        public DateTime Date { get; set; }

    }
}
