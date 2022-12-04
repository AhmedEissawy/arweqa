using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Repo.Implementation
{
    public class BranchRepo : GenericRepository<Branch>, IBranchRepo
    {
        public BranchRepo(ProjectContext context) : base(context)
        {
        }
    }
}