using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Configurations
{
    public class ProceduresConfigurations
    {
        public static void Configuration(ModelBuilder builder)
        {
            //builder.Entity<ProcDashboardReport>(p => p.HasNoKey());

        }
    }
}
