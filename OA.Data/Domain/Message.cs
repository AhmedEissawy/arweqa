using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class Message : BaseEntity
    {         
        public Guid SenderIdentityId { get; set; }

        public Guid ReceiverIdentityId { get; set; }
   
        public string SenderName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsTeacher { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Attachment { get; set; }
      
        public bool IsFile { get; set; }
        
        public string Type { get; set; }

        public ApplicationUser SenderIdentity { get; set; }

        public ApplicationUser ReceiverIdentity { get; set; }

    }
}
