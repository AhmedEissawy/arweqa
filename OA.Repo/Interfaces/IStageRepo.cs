using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IStageRepo : IGenericRepository<Stage>
    {
        Task<List<Stage>> GetAllStagesAdmin();

        Task<List<Stage>> GetStages();
    }
}
