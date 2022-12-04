using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OA.Data.Domain
{
    public class ExceptionLogger
    {
        [Key]
        public int Id { get; set; }
        public string Text1 { get; set; }

        public string Text2 { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public DateTime Date { get; set; }
    }
}
