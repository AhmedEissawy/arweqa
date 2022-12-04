using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public bool Deleted { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public Guid? LastModifiedBy { get; set; }

        public DateTime? LastModifyDate { get; set; }
    }
}
