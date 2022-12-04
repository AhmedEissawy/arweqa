using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
    public class SocialLink : BaseEntity
    {
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string WhatsApp { get; set; }
    }
}
