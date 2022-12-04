using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Implementation
{
    public class MzhbRepo : GenericRepository<Mzhb>, IMzhbRepo
    {
        public MzhbRepo(ProjectContext context) : base(context)
        {
        }
    }

}