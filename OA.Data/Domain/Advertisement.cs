using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Data.Domain
{
    public class Advertisement : BaseEntity
    {
        public string File { get; set; }

        public int Index { get; set; }

        public int SlideNumber { get; set; }
        public string Url { get; set; }
    }
}
