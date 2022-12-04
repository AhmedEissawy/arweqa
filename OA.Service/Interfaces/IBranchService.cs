using OA.Service.Implementation.BranchServices.Dtos;
using OA.Service.Implementation.Govern.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IBranchService
    {
        Task<ResponseBranchDto> CreateBranch(CreateBranchDto model);
        Task<List<ResponseBranchDto>> GetBranchs();
    }
}