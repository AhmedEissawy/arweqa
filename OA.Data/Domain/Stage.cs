using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Text;

namespace OA.Data.Domain
{
    public class Stage : BaseEntity
    {
        public Stage()
        {
            Grades = new HashSet<Grade>();
        }

        public string StageName { get; set; }

        public int Index { get; set; }

        public ICollection<Grade> Grades { get; set; }

    }
}
