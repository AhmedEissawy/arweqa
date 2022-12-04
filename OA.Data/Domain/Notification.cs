using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class Notification : BaseEntity
    {
        public Guid StudentIdentityId { get; set; }

        public string StudentName { get; set; }

        public string Title { get; set; }

        public string Discription { get; set; }

        public DateTime Date { get; set; }

        public bool Seen { get; set; }

        public ApplicationUser User { get; set; }

    }
}
