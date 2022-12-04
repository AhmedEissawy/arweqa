using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface ISemesterRepo : IGenericRepository<Semester>
    {
        Task<List<Semester>> GetSemesters();
    }
}
