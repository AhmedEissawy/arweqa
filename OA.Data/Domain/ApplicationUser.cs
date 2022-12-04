using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace OA.Data.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            MessageReceivers = new HashSet<Message>();

            MessageSenders = new HashSet<Message>();

            Notifications = new HashSet<Notification>();
        }
     

        public string UserFullName { get; set; }

        public string OldIdentityId { get; set; }

        public string UserImage { get; set; }

        public string UserType { get; set; }

        public string DeviceToken { get; set; }

        public Guid? GradeId { get; set; }

        public Guid? SectionId { get; set; }

        public bool IsActive { get; set; }

        public bool Deleted { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public Guid? LastModifiedBy { get; set; }

        public DateTime? LastModifyDate { get; set; }

        public Grade Grade { get; set; }

        public Section Section { get; set; }

        public Teacher Teacher { get; set; }

        public virtual Student Student { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<Message> MessageReceivers { get; set; }

        public ICollection<Message> MessageSenders { get; set; }

    }
}
